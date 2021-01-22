using Microsoft.EntityFrameworkCore;
using SmartSolucionesCuba.SAPRESSC.Core.Security.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Web.SecurityLocal.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Helpers
{
    public sealed class BusinessDataInitializationHelper : SAPRESSC.Core.Persistence.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(DbContext dbContext)
        {
            #region Account Roles definitios

            var roleDbSet = dbContext.Set<Role>();

            if (!roleDbSet.Any(role => role.Code.Equals(Cloud.Security.Authorization.Roles.AccountViewer)))
            {
                roleDbSet.Add(Cloud.Security.Authorization.Roles.AccountViewer.ToRoleEntity());
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Cloud.Security.Authorization.Roles.AccountCreator)))
            {
                roleDbSet.Add(Cloud.Security.Authorization.Roles.AccountCreator.ToRoleEntity());
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Cloud.Security.Authorization.Roles.AccountEditor)))
            {
                roleDbSet.Add(Cloud.Security.Authorization.Roles.AccountEditor.ToRoleEntity());
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Cloud.Security.Authorization.Roles.AccountRemover)))
            {
                roleDbSet.Add(Cloud.Security.Authorization.Roles.AccountRemover.ToRoleEntity());
            }

            #endregion

            #region Extension definitios

            var extensionDbSet = dbContext.Set<Persistence.Entities.Extension>();

            var extensionDescriptors = Support.Extend.Providers.ExtensionDescriptorProvider.Instance.GetDescriptors();

            var templateDescriptors = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors();
            var transitionDescriptors = Support.Extend.Motion.Providers.TransitionDescriptorProvider.Instance.GetDescriptors();
            var overlayDescriptors = Support.Extend.Overlaying.Providers.OverlayDescriptorProvider.Instance.GetDescriptors();

            foreach (var extensionDescriptor in extensionDescriptors)
            {
                var extensionNamespace = extensionDescriptor.GetType().Assembly.FullName.Split(",")[0];

                var spectedExtensionTemplateDescriptors = templateDescriptors.Where(d => d.GetType().Assembly.FullName.StartsWith(extensionNamespace)).ToArray();
                var spectedExtensionTransitionDescriptors = transitionDescriptors.Where(d => d.GetType().Assembly.FullName.StartsWith(extensionNamespace)).ToArray();
                var spectedExtensionOverlayDescriptors = overlayDescriptors.Where(d => d.GetType().Assembly.FullName.StartsWith(extensionNamespace)).ToArray();

                var extension = extensionDbSet
                    .Include(e => e.Templates)
                    .Include(e => e.Transitions)
                    .Include(e => e.Overlays)
                    .FirstOrDefault(e => e.Id == extensionDescriptor.Id);

                if (extension == null)
                {
                    extension = new Persistence.Entities.Extension
                    {
                        Id = extensionDescriptor.Id,
                        Enabled = true,
                        Templates = spectedExtensionTemplateDescriptors.Select(d => new Persistence.Entities.Template { Id = d.Id, Enabled = true }).ToList(),
                        Transitions = spectedExtensionTransitionDescriptors.Select(d => new Persistence.Entities.Transition { Id = d.Id, Enabled = true }).ToList(),
                        Overlays = spectedExtensionOverlayDescriptors.Select(d => new Persistence.Entities.Overlay { Id = d.Id, Enabled = true }).ToList()
                    };

                    extensionDbSet.Add(extension);
                }
                else
                {
                    var spectedExtensionTemplates = spectedExtensionTemplateDescriptors.Select(d => new Persistence.Entities.Template { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionTemplateDescriptors = extension.Templates.Except(spectedExtensionTemplates, Comparison.TemplateEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionTemplateDescriptors.AddRange(spectedExtensionTemplates.Except(extension.Templates, Comparison.TemplateEntityCollectionEqualityComparisonHelper.Instance));

                    var templateDbSet = dbContext.Set<Persistence.Entities.Template>();

                    foreach (var templateDescriptor in divergentExtensionTemplateDescriptors)
                    {
                        var persistedTemplate = extension.Templates.FirstOrDefault(e => e.Id == templateDescriptor.Id);

                        if (persistedTemplate != null)
                        {
                            extension.Templates.Remove(persistedTemplate);

                            templateDbSet.Remove(persistedTemplate);
                        }
                        else
                        {
                            extension.Templates.Add(new Persistence.Entities.Template { Id = templateDescriptor.Id, Enabled = true });
                        }
                    }

                    var spectedExtensionTransitions = spectedExtensionTransitionDescriptors.Select(d => new Persistence.Entities.Transition { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionTransitionDescriptors = extension.Transitions.Except(spectedExtensionTransitions, Comparison.TransitionEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionTransitionDescriptors.AddRange(spectedExtensionTransitions.Except(extension.Transitions, Comparison.TransitionEntityCollectionEqualityComparisonHelper.Instance));

                    var transitionDbSet = dbContext.Set<Persistence.Entities.Transition>();

                    foreach (var transitionDescriptor in divergentExtensionTransitionDescriptors)
                    {
                        var persistedTransition = extension.Transitions.FirstOrDefault(e => e.Id == transitionDescriptor.Id);

                        if (persistedTransition != null)
                        {
                            extension.Transitions.Remove(persistedTransition);

                            transitionDbSet.Remove(persistedTransition);
                        }
                        else
                        {
                            extension.Transitions.Add(new Persistence.Entities.Transition { Id = transitionDescriptor.Id, Enabled = true });
                        }
                    }

                    var spectedExtensionOverlays = spectedExtensionOverlayDescriptors.Select(d => new Persistence.Entities.Overlay { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionOverlayDescriptors = extension.Overlays.Except(spectedExtensionOverlays, Comparison.OverlayEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionOverlayDescriptors.AddRange(spectedExtensionOverlays.Except(extension.Overlays, Comparison.OverlayEntityCollectionEqualityComparisonHelper.Instance));

                    var overlayDbSet = dbContext.Set<Persistence.Entities.Overlay>();

                    foreach (var overlayDescriptor in divergentExtensionOverlayDescriptors)
                    {
                        var persistedOverlay = extension.Overlays.FirstOrDefault(e => e.Id == overlayDescriptor.Id);

                        if (persistedOverlay != null)
                        {
                            extension.Overlays.Remove(persistedOverlay);

                            overlayDbSet.Remove(persistedOverlay);
                        }
                        else
                        {
                            extension.Overlays.Add(new Persistence.Entities.Overlay { Id = overlayDescriptor.Id, Enabled = true });
                        }
                    }

                    if (divergentExtensionTemplateDescriptors.Count() > 0 || divergentExtensionTransitionDescriptors.Count() > 0 || divergentExtensionOverlayDescriptors.Count() > 0)
                    {
                        extensionDbSet.Update(extension);
                    }
                }
            }

            #endregion

            if (dbContext is SAPRESSC.Core.Persistence.EF.Context.ITraceableDbContext)
            {
                (dbContext as SAPRESSC.Core.Persistence.EF.Context.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}

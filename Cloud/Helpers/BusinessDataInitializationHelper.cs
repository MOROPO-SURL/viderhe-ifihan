using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.VIDERHE.Cloud.Helpers.Comparison;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Cloud.Security.Authorization;
using System.Linq;

namespace MOROPO.VIDERHE.Cloud.Helpers
{
    public sealed class BusinessDataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(DbContext dbContext)
        {
            #region Account Permission definitions

            var roleDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            if (!roleDbSet.Any(role => role.Code.Equals(Permission.AccountViewer)))
            {
                roleDbSet.Add(Permission.AccountViewer.ToPermissionEntity(PermissionFamily.AccountManagement));
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Permission.AccountCreator)))
            {
                roleDbSet.Add(Permission.AccountCreator.ToPermissionEntity(PermissionFamily.AccountManagement));
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Permission.AccountEditor)))
            {
                roleDbSet.Add(Permission.AccountEditor.ToPermissionEntity(PermissionFamily.AccountManagement));
            }

            if (!roleDbSet.Any(role => role.Code.Equals(Permission.AccountRemover)))
            {
                roleDbSet.Add(Permission.AccountRemover.ToPermissionEntity(PermissionFamily.AccountManagement));
            }

            #endregion

            #region Extension definitions

            var extensionDbSet = dbContext.Set<Extension>();

            var templateDbSet = dbContext.Set<Template>();

            var transitionDbSet = dbContext.Set<Transition>();

            var overlayDbSet = dbContext.Set<Overlay>();

            var extensionDescriptors = Support.Extend.Providers.ExtensionDescriptorProvider.Instance.GetDescriptors();

            var templateDescriptors = Support.Extend.Templating.Providers.TemplateDescriptorProvider.Instance.GetDescriptors();
            var transitionDescriptors = Support.Extend.Transitioning.Providers.TransitionDescriptorProvider.Instance.GetDescriptors();
            var overlayDescriptors = Support.Extend.Overlaying.Providers.OverlayDescriptorProvider.Instance.GetDescriptors();

            foreach (var extensionDescriptor in extensionDescriptors)
            {
                var extensionVersion = extensionDescriptor.GetType().Assembly.GetName().Version.ToString();

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
                    extension = new Extension
                    {
                        Id = extensionDescriptor.Id,
                        Enabled = true,
                        Version = extensionVersion,
                        Templates = spectedExtensionTemplateDescriptors.Select(d => new Template { Id = d.Id, Enabled = true }).ToList(),
                        Transitions = spectedExtensionTransitionDescriptors.Select(d => new Transition { Id = d.Id, Enabled = true }).ToList(),
                        Overlays = spectedExtensionOverlayDescriptors.Select(d => new Overlay { Id = d.Id, Enabled = true }).ToList()
                    };

                    extensionDbSet.Add(extension);
                }
                else
                {
                    var spectedExtensionTemplates = spectedExtensionTemplateDescriptors.Select(d => new Template { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionTemplateDescriptors = extension.Templates.Except(spectedExtensionTemplates, TemplateEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionTemplateDescriptors.AddRange(spectedExtensionTemplates.Except(extension.Templates, TemplateEntityCollectionEqualityComparisonHelper.Instance));

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
                            var templateEntity = new Template { Id = templateDescriptor.Id, Enabled = true };

                            templateDbSet.Add(templateEntity);

                            extension.Templates.Add(templateEntity);
                        }
                    }

                    var spectedExtensionTransitions = spectedExtensionTransitionDescriptors.Select(d => new Transition { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionTransitionDescriptors = extension.Transitions.Except(spectedExtensionTransitions, TransitionEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionTransitionDescriptors.AddRange(spectedExtensionTransitions.Except(extension.Transitions, TransitionEntityCollectionEqualityComparisonHelper.Instance));

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
                            var transitionEntity = new Transition { Id = transitionDescriptor.Id, Enabled = true };

                            transitionDbSet.Add(transitionEntity);
                            
                            extension.Transitions.Add(transitionEntity);
                        }
                    }

                    var spectedExtensionOverlays = spectedExtensionOverlayDescriptors.Select(d => new Overlay { Id = d.Id, Enabled = true }).ToArray();

                    var divergentExtensionOverlayDescriptors = extension.Overlays.Except(spectedExtensionOverlays, OverlayEntityCollectionEqualityComparisonHelper.Instance).ToList();

                    divergentExtensionOverlayDescriptors.AddRange(spectedExtensionOverlays.Except(extension.Overlays, OverlayEntityCollectionEqualityComparisonHelper.Instance));

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
                            var overlayEntity = new Overlay { Id = overlayDescriptor.Id, Enabled = true };

                            overlayDbSet.Add(overlayEntity);

                            extension.Overlays.Add(overlayEntity);
                        }
                    }

                    if (divergentExtensionTemplateDescriptors.Count() > 0 || divergentExtensionTransitionDescriptors.Count() > 0 || divergentExtensionOverlayDescriptors.Count() > 0)
                    {
                        if (extension.Version != extensionVersion)
                        {
                            extension.Version = extensionVersion;
                        }

                        extensionDbSet.Update(extension);
                    }
                    else if (extension.Version != extensionVersion)
                    {
                        extension.Version = extensionVersion;
                    }
                }
            }

            #endregion

            if (dbContext is Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext)
            {
                (dbContext as Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.ITraceableDbContext).SaveChanges("system");
            }
            else
            {
                dbContext.SaveChanges();
            }
        }
    }
}

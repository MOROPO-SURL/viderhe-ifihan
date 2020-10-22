using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartSolucionesCuba.SAPRESSC.Core.Persistence.Repositories;
using SmartSolucionesCuba.SAPRESSC.Core.Security.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Core.Web.Security.Filters;
using SmartSolucionesCuba.SAPRESSC.Middleware.Identity.Persistence.Entities;
using SmartSolucionesCuba.SAPRESSC.Middleware.Media.Persistence.Entities;
using SmartSolucionesCuba.Videre.Cloud.Models.View;
using SmartSolucionesCuba.Videre.Cloud.Persistence.Entities;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Cloud.Controllers.Backend
{
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Area("business")]
    public class AccountsController : SAPRESSC.Core.Web.Backend.Controllers.AbstractHabilitableEntityManagementController<Account, System.Guid, AccountInputViewModel, AccountDisplayViewModel>
    {
        private const string LOGO_IMAGE_FILE_FIELD_NAME = "LogoImageFile";
        private const string SPLASH_IMAGE_FILE_FIELD_NAME = "SplashImageFile";

        private readonly SAPRESSC.Middleware.Media.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManagerFacade;
        private readonly IEntityRepository<User, string> userRepository;
        private readonly IEntityRepository<Persistence.Entities.Extension, System.Guid> extensionRepository;
        private readonly IEntityRepository<Image, System.Guid> imageRepository;
        private readonly IEntityRepository<PersonIdentity, System.Guid> identityRepository;
        private readonly IEntityRepository<Moderator, System.Guid> moderatorRepository;

        public AccountsController(IEntityRepository<Moderator, System.Guid> moderatorRepository, IEntityRepository<PersonIdentity, System.Guid> identityRepository, SAPRESSC.Middleware.Media.Web.Common.Managers.Facade.IImageFileManagerFacade imageFileManagerFacade, IEntityRepository<User, string> userRepository, IEntityRepository<Persistence.Entities.Extension, System.Guid> extensionRepository, IEntityRepository<Image, System.Guid> imageRepository, IEntityRepository<Account, System.Guid> repository, Microsoft.Extensions.Localization.IStringLocalizer<AccountsController> localizer, ILogger<AccountsController> logger) : base(repository, localizer, logger)
        {
            this.imageFileManagerFacade = imageFileManagerFacade;
            this.userRepository = userRepository;
            this.extensionRepository = extensionRepository;
            this.imageRepository = imageRepository;
            this.identityRepository = identityRepository;
            this.moderatorRepository = moderatorRepository;
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountViewer)]
        public override IActionResult Index(int sheet = 1, int limit = 25)
        {
            return base.Index(sheet, limit);
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountCreator)]
        public override IActionResult Create()
        {
            return base.Create();
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountCreator)]
        public override IActionResult Create(AccountInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var validationRequired = false;

                var formLogoImageFile = Request.Form.Files.First(f => f.Name == LOGO_IMAGE_FILE_FIELD_NAME);

                if (formLogoImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);

                    modelInput.LogoImageFile = formLogoImageFile;

                    validationRequired = true;
                }

                var formSplashImageFile = Request.Form.Files.First(f => f.Name == SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.SplashImageFile = formSplashImageFile;

                    validationRequired = true;
                }

                if (validationRequired) TryUpdateModelAsync(modelInput).Wait();
            }

            return base.Create(modelInput);
        }

        protected override void PreCreate(Account entity, AccountInputViewModel modelInput)
        {
            base.PreCreate(entity, modelInput);

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.LogoImageFile.CopyTo(memoryStream);

                var logoImage = new Image { ContentType = modelInput.LogoImageFile.ContentType, Length = modelInput.LogoImageFile.Length, About = "Account Logo " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(logoImage.Id, memoryStream.ToArray(), modelInput.LogoImageFile.ContentType);

                entity.Logo = logoImage;
            }

            using (var memoryStream = new System.IO.MemoryStream())
            {
                modelInput.SplashImageFile.CopyTo(memoryStream);

                var splashImage = new Image { ContentType = modelInput.SplashImageFile.ContentType, Length = modelInput.SplashImageFile.Length, About = "Account Splash " + entity.Id };

                imageFileManagerFacade.SaveImageFileContent(splashImage.Id, memoryStream.ToArray(), modelInput.SplashImageFile.ContentType);

                entity.Splash = splashImage;
            }
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public override IActionResult Edit(System.Guid key)
        {
            return base.Edit(key);
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public override IActionResult Edit(AccountInputViewModel modelInput)
        {
            ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);
            ModelState.MarkFieldValid(LOGO_IMAGE_FILE_FIELD_NAME);

            ModelState.ClearValidationState(SPLASH_IMAGE_FILE_FIELD_NAME);
            ModelState.MarkFieldValid(SPLASH_IMAGE_FILE_FIELD_NAME);

            if (Request.Form.Files.Count > 0)
            {
                var validationRequired = false;

                var formLogoImageFile = Request.Form.Files.FirstOrDefault(f => f.Name == LOGO_IMAGE_FILE_FIELD_NAME);

                if (formLogoImageFile != null && formLogoImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);

                    modelInput.LogoImageFile = formLogoImageFile;

                    validationRequired = true;
                }

                var formSplashImageFile = Request.Form.Files.FirstOrDefault(f => f.Name == SPLASH_IMAGE_FILE_FIELD_NAME);

                if (formSplashImageFile != null && formSplashImageFile.Length > 0)
                {
                    ModelState.ClearValidationState(SPLASH_IMAGE_FILE_FIELD_NAME);

                    modelInput.SplashImageFile = formSplashImageFile;

                    validationRequired = true;
                }

                if (validationRequired)
                {
                    TryUpdateModelAsync(modelInput).Wait();

                    if (modelInput.LogoImageFile == null)
                    {
                        ModelState.ClearValidationState(LOGO_IMAGE_FILE_FIELD_NAME);
                        ModelState.MarkFieldValid(LOGO_IMAGE_FILE_FIELD_NAME);
                    }

                    if (modelInput.SplashImageFile == null)
                    {
                        ModelState.ClearValidationState(SPLASH_IMAGE_FILE_FIELD_NAME);
                        ModelState.MarkFieldValid(SPLASH_IMAGE_FILE_FIELD_NAME);
                    }
                }
            }

            return base.Edit(modelInput);
        }

        protected override void PreEdit(Account entity, AccountInputViewModel modelInput)
        {
            base.PreEdit(entity, modelInput);

            if (modelInput.LogoImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.LogoImageFile.CopyTo(memoryStream);

                    var logoImage = new Image { ContentType = modelInput.LogoImageFile.ContentType, Length = modelInput.LogoImageFile.Length, About = "Account Logo " + entity.Id };

                    imageFileManagerFacade.SaveImageFileContent(logoImage.Id, memoryStream.ToArray(), modelInput.LogoImageFile.ContentType);

                    entity.Logo = logoImage;
                }
            }

            if (modelInput.SplashImageFile != null)
            {
                using (var memoryStream = new System.IO.MemoryStream())
                {
                    modelInput.SplashImageFile.CopyTo(memoryStream);

                    var splashImage = new Image { ContentType = modelInput.SplashImageFile.ContentType, Length = modelInput.SplashImageFile.Length, About = "Account Splash " + entity.Id };

                    imageFileManagerFacade.SaveImageFileContent(splashImage.Id, memoryStream.ToArray(), modelInput.SplashImageFile.ContentType);

                    entity.Splash = splashImage;
                }
            }
        }

        protected override void PostEdit(Account entity, AccountInputViewModel modelInput)
        {
            base.PostEdit(entity, modelInput);

            if (modelInput.LogoImageFile != null)
            {
                var oldLogoImage = imageRepository.Get(modelInput.LogoImageId);

                imageRepository.Delete(oldLogoImage, User.Identity.Name);

                imageFileManagerFacade.DeleteImageFile(oldLogoImage);
            }

            if (modelInput.SplashImageFile != null)
            {
                var oldSplashImage = imageRepository.Get(modelInput.SplashImageId);

                imageRepository.Delete(oldSplashImage, User.Identity.Name);

                imageFileManagerFacade.DeleteImageFile(oldSplashImage);
            }
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public override IActionResult Enable(System.Guid key)
        {
            return base.Enable(key);
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public override IActionResult Disable(System.Guid key)
        {
            return base.Disable(key);
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountRemover)]
        public override IActionResult Delete(System.Guid key)
        {
            return base.Delete(key);
        }

        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountRemover)]
        public override IActionResult Delete(AccountDisplayViewModel displayModel)
        {
            return base.Delete(displayModel);
        }

        protected override void PostDelete(Account entity)
        {
            base.PostDelete(entity);

            imageRepository.Delete(entity.Logo, User.Identity.Name);

            imageFileManagerFacade.DeleteImageFile(entity.Logo);

            imageRepository.Delete(entity.Splash, User.Identity.Name);

            imageFileManagerFacade.DeleteImageFile(entity.Splash);
        }

        #region Account Moderators Management

        [HttpGet]
        [Route("edit/{key}/moderators")]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult Moderators(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var model = new AccountModeratorsViewModel
                {
                    Account = new AccountDisplayViewModel(),
                    Moderators = entity.ModeratorBridges.Select(e =>
                    {
                        var displayModel = new ModeratorDisplayViewModel();

                        displayModel.Import(e.Moderator);

                        return displayModel;
                    }).ToList()
                };

                model.Account.Import(entity);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpGet]
        [Route("edit/{key}/moderators/add")]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult AddModerator(System.Guid key)
        {
            try
            {
                var account = Repository.Get(key);

                var model = new ModeratorInputViewModel
                {
                    SelectableUsers = userRepository.GetAll().ToArray().Except(account.ModeratorBridges.Select(b => b.Moderator.User).ToArray()).ToArray().Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                    {
                        Value = e.Id,
                        Text = e.Id
                    }).ToList()
                };

                model.Account.Import(account);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/add")]
        [ValidateAntiForgeryToken]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult AddModerator(System.Guid key, ModeratorInputViewModel modelInput)
        {
            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    ModelState.ClearValidationState("ImageFile");

                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            try
            {
                var entity = Repository.Get(key);

                if (ModelState.IsValid)
                {
                    try
                    {
                        var bridge = new AccountModeratorBridge
                        {
                            AccountId = entity.Id,
                            Moderator = modelInput.Export()
                        };

                        if (modelInput.ImageFile != null)
                        {
                            using (var memoryStream = new System.IO.MemoryStream())
                            {
                                modelInput.ImageFile.CopyTo(memoryStream);

                                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Moderator for Account " + entity.Id };

                                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                                bridge.Moderator.Identity.Image = image;
                            }
                        }

                        entity.ModeratorBridges.Add(bridge);

                        Repository.Update(entity, User.Identity.Name);

                        SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Success, GetCreationSuccessMessage());

                        return RedirectToAction("moderators", new { key = entity.Id });
                    }
                    catch (SAPRESSC.Core.Web.Frontend.InvalidModelException e)
                    {
                        ModelState.AddModelError(e.ModelKey, e.ErrorMessage);
                    }
                }

                SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetInvalidMessage());

                modelInput.SelectableUsers = userRepository.GetAll().ToArray().Except(entity.ModeratorBridges.Select(b => b.Moderator.User).ToArray()).ToArray().Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
                {
                    Value = e.Id,
                    Text = e.Id
                }).ToList();

                modelInput.Account.Import(entity);

                return View(modelInput);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpGet]
        [Route("edit/{key}/moderators/edit/{id}")]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult EditModerator(System.Guid key, System.Guid id)
        {
            try
            {
                var account = Repository.Get(key);

                var entity = account.ModeratorBridges.First(b => b.ModeratorId == id).Moderator;

                var model = new ModeratorInputViewModel();

                model.Import(entity);
                model.Account.Import(account);

                return View(model);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/edit")]
        [ValidateAntiForgeryToken]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult EditModerator(System.Guid key, ModeratorInputViewModel modelInput)
        {
            ModelState.ClearValidationState("ImageFile");
            ModelState.MarkFieldValid("ImageFile");

            if (Request.Form.Files.Count > 0)
            {
                var formFile = Request.Form.Files[0];

                if (formFile.Length > 0)
                {
                    modelInput.ImageFile = formFile;

                    var updateModelTask = TryUpdateModelAsync(modelInput);

                    updateModelTask.Wait();
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var entity = Repository.Get(key);

                    try
                    {
                        var bridge = entity.ModeratorBridges.First(b => b.ModeratorId == modelInput.Id);

                        modelInput.Mergue(bridge.Moderator);

                        if (modelInput.ImageFile == null)
                        {
                            if (modelInput.ResetImage && bridge.Moderator.Identity.Image != null)
                            {
                                imageFileManagerFacade.DeleteImageFile(bridge.Moderator.Identity.Image);

                                imageRepository.Delete(bridge.Moderator.Identity.Image, User.Identity.Name);
                            }
                        }
                        else
                        {
                            if (bridge.Moderator.Identity.Image != null)
                            {
                                imageFileManagerFacade.DeleteImageFile(bridge.Moderator.Identity.Image);

                                imageRepository.Delete(bridge.Moderator.Identity.Image, User.Identity.Name);
                            }

                            using (var memoryStream = new System.IO.MemoryStream())
                            {
                                modelInput.ImageFile.CopyTo(memoryStream);

                                var image = new Image { ContentType = modelInput.ImageFile.ContentType, Length = modelInput.ImageFile.Length, About = "Moderator " + entity.Id };

                                imageFileManagerFacade.SaveImageFileContent(image.Id, memoryStream.ToArray(), modelInput.ImageFile.ContentType);

                                bridge.Moderator.Identity.Image = image;
                            }
                        }

                        Repository.Update(entity, User.Identity.Name);

                        SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Success, GetEditionSuccessMessage());

                        return RedirectToAction("moderators", new { key = entity.Id });
                    }
                    catch (SAPRESSC.Core.Web.Frontend.InvalidModelException e)
                    {
                        ModelState.AddModelError(e.ModelKey, e.ErrorMessage);
                    }

                    SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetInvalidMessage());

                    modelInput.Account.Import(entity);

                    return View(modelInput);
                }
                catch (System.Exception e)
                {
                    logger.LogError(e.InnerException, e.Message);
                }
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("edit/{key}/moderators/delete")]
        [ValidateAntiForgeryToken]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult DeleteModerator(System.Guid key, ModeratorDisplayViewModel modelInput)
        {
            try
            {
                var entity = Repository.Get(key);

                var bridge = entity.ModeratorBridges.First(b => b.Moderator.Id == modelInput.Id);

                entity.ModeratorBridges.Remove(bridge);

                Repository.Update(entity, User.Identity.Name, false);

                identityRepository.Delete(bridge.Moderator.Identity, User.Identity.Name, false);

                if (bridge.Moderator.Identity.Image != null)
                {
                    imageRepository.Delete(bridge.Moderator.Identity.Image, User.Identity.Name, false);
                }

                moderatorRepository.Delete(bridge.Moderator, User.Identity.Name);

                if (bridge.Moderator.Identity.Image != null)
                {
                    imageFileManagerFacade.DeleteImageFile(bridge.Moderator.Identity.Image);
                }

                SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Success, GetDeletionSuccessMessage());

                return RedirectToAction("moderators", new { key = entity.Id });
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                logger.LogError(e.InnerException, e.Message);

                SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Warning, GetOnDeletionDependecyConstrainErrorMessage());

                return RedirectToAction("moderators", new { key });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetSuccessDeleteActionResult();
        }

        #endregion

        #region Account Extension Management

        [HttpGet]
        [Route("[action]/{key}")]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult Extensions(System.Guid key)
        {
            try
            {
                var entity = Repository.Get(key);

                var modelInput = new AccountExtensionsInputViewModel
                {
                    AccountId = entity.Id,
                    Account = entity
                };

                var plugins = extensionRepository.GetAll().ToArray();

                foreach (var plugin in plugins)
                {
                    var descriptor = Support.Extend.Providers.ExtensionDescriptorProvider.Instance.GetDescriptorById(plugin.Id);

                    modelInput.SelectableExtensions.Add(new SAPRESSC.Core.Common.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>
                    {
                        Id = plugin.Id,
                        Selected = false,
                        Label = descriptor.Name,
                        Description = descriptor.Description
                    });
                }

                foreach (var item in modelInput.SelectableExtensions)
                {
                    item.Selected = entity.ExtensionBridges.Any(bridge => Helpers.Integrity.AccountExtensionBridgeIntegrityHelper.IsCorrectlySigned(bridge) && bridge.ExtensionId == item.Id);
                }

                return View(modelInput);
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        [HttpPost]
        [Route("[action]")]
        [ValidateAntiForgeryToken]
        [RequiresRoleBasePermission(Security.Authorization.Roles.AccountEditor)]
        public IActionResult Extensions(AccountExtensionsInputViewModel modelInput)
        {
            try
            {
                var entity = Repository.Get(modelInput.AccountId);

                entity.ExtensionBridges.Clear();

                Repository.Update(entity, User.Identity.Name);

                foreach (var item in modelInput.SelectableExtensions.Where(item => item.Selected))
                {
                    var bridge = new AccountExtensionBridge
                    {
                        AccountId = entity.Id,
                        ExtensionId = item.Id
                    };

                    bridge.Signature = Helpers.Integrity.AccountExtensionBridgeIntegrityHelper.GetSignature(bridge);

                    entity.ExtensionBridges.Add(bridge);
                }

                Repository.Update(entity, User.Identity.Name);

                modelInput.Account = entity;

                SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Success, GetEditionSuccessMessage());

                return RedirectToAction("extensions", new { key = entity.Id });
            }
            catch (System.Exception e)
            {
                logger.LogError(e.InnerException, e.Message);
            }

            SetDefaultNotification(SAPRESSC.Core.Common.Models.View.NotificationType.Danger, GetNotFoundMessage());

            return GetDefaultActionResult();
        }

        # endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOROPO.SAPRESSC.Middleware.Media.Web.Common.Managers.Facade;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Cloud.Controllers.Frontend.Api
{
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme, Policy = Security.Authorization.Policies.ACCOUNT_VALIDATED_MODERATION)]
    [Route("api/[area]/[controller]")]
    [Area("account")]
    [ApiController]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.ChangeUserPasswordRequiredAction]
    [MOROPO.SAPRESSC.Core.Web.Security.Attributes.CatchChangeUserPasswordRequiredException]
    public class SoundsController : Controller
    {
        private readonly Managers.SoundFileManager soundFileManager;
        private readonly IThumbnailFileManagerFacade thumbnailFileManager;
        private readonly MOROPO.SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Sound, System.Guid> soundRepository;
        private readonly Persistence.EF.ApplicationDbContext dbContext;

        public SoundsController(Persistence.EF.ApplicationDbContext dbContext, MOROPO.SAPRESSC.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.Sound, System.Guid> soundRepository, IThumbnailFileManagerFacade thumbnailFileManager, Managers.SoundFileManager soundFileManager)
        {
            this.soundFileManager = soundFileManager;
            this.thumbnailFileManager = thumbnailFileManager;
            this.soundRepository = soundRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        [HttpGet("page/{page}")]
        public ActionResult<MOROPO.SAPRESSC.Core.Common.Models.PaginationModel<SoundDisplayModel>> GetPage(int page = 1)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var limit = 15;

            var account = dbContext.Accounts.Include(e => e.SoundBridges).ThenInclude(b => b.Sound).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var maxCount = account.SoundBridges.Count;

            var rest = maxCount % limit;

            var maxPageCount = maxCount / limit;

            if (rest > 0) maxPageCount += 1;

            if (page < 0 || page > maxPageCount)
            {
                page = 1;
            }

            return Ok(new MOROPO.SAPRESSC.Core.Common.Models.PaginationModel<SoundDisplayModel>
            {
                List = account.SoundBridges.Select(bridge => bridge.Sound).OrderByDescending(e => e.CreateAt).Skip((page - 1) * limit).Take(limit).Select(entity =>
                {
                    var model = new SoundDisplayModel();

                    model.Import(entity);

                    return model;
                }).ToList(),
                Limit = limit,
                Page = page,
                HasPrevious = page > 1,
                HasNext = page < maxPageCount,
                MaxPageCount = maxPageCount
            });
        }

        [HttpPost]
        public ActionResult Add(Microsoft.AspNetCore.Http.IFormFile file, [FromForm] string about)
        {
            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.First(e => e.Id == accountId);

            if (file == null)
            {
                file = Request.Form.Files.First();
            }

            var entity = new Persistence.Entities.Sound
            {
                Extension = "mp3",
                Length = file.Length,
                
                About = about
            };

            using (var memoryStream = new System.IO.MemoryStream((int)file.Length))
            {
                file.CopyTo(memoryStream);

                soundFileManager.SaveFileContent(entity.Id, memoryStream.ToArray());

                dbContext.Sounds.Add(entity);

                dbContext.AccountSoundBridges.Add(new Persistence.Entities.AccountSoundBridge
                {
                    AccountId = accountId,
                    SoundId = entity.Id
                });

                dbContext.SaveChanges(User.Identity.Name);
            }

            return Ok();
        }

        [HttpPut]
        public ActionResult Edit([FromBody] SoundInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

                    var account = dbContext.Accounts.Include(e => e.SoundBridges).ThenInclude(b => b.Sound).First(e => e.Id == accountId);

                    var entity = account.SoundBridges.First(b => b.SoundId == inputModel.Id).Sound;

                    inputModel.Mergue(entity);

                    soundRepository.Update(entity, User.Identity.Name);

                    return Ok();
                }
                catch (System.InvalidOperationException)
                {
                    return NoContent();
                }
                catch (System.Exception)
                {
                    return Conflict();
                }
            }

            return BadRequest();
        }

        [HttpDelete("{key}")]
        public ActionResult Delete(System.Guid key)
        {
            if (dbContext.PlacardSoundBridges.Any(item => item.SoundId == key))
            {
                return Conflict();
            }

            var accountId = System.Guid.Parse(User.Claims.First(claim => claim.Type == Security.Authorization.Claims.ACCOUNT_CLAIM).Value);

            var account = dbContext.Accounts.Include(e => e.SoundBridges).ThenInclude(b => b.Sound).ThenInclude(e => e.Thumbnail).First(e => e.Id == accountId);

            var bridge = account.SoundBridges.First(b => b.SoundId == key);

            dbContext.AccountSoundBridges.Remove(bridge);

            dbContext.Sounds.Remove(bridge.Sound);

            if (bridge.Sound.ThumbnailId != null)
            {
                dbContext.Thumbnails.Remove(bridge.Sound.Thumbnail);
            }

            dbContext.SaveChanges(User.Identity.Name);

            soundFileManager.DeleteFile(bridge.Sound);

            if (bridge.Sound.ThumbnailId != null)
            {
                thumbnailFileManager.DeleteThumbnailFile(bridge.Sound.Thumbnail);
            }

            return Ok();
        }
    }
}

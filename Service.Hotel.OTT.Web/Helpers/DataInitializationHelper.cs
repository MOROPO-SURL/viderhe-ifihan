using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Helpers
{
    public class DataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            if (!permissionDbSet.Any(role => role.Code.Equals(API.Common.Constants.Authorization.TraceViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.TraceViewerPermission.ToPermissionEntity());
            }

            #region ApiKey
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ApiKeyViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ApiKeyViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.ApiKeyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ApiKeyCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ApiKeyCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.ApiKeyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ApiKeyEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ApiKeyEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.ApiKeyManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ApiKeyRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ApiKeyRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.ApiKeyManagementPermissionGroup));
            }
            #endregion

            #region Channel
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ChannelViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ChannelViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.ChannelManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ChannelCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ChannelCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.ChannelManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ChannelEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ChannelEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.ChannelManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.ChannelRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.ChannelRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.ChannelManagementPermissionGroup));
            }
            #endregion

            #region Country
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CountryViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CountryViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.CountryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CountryCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CountryCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CountryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CountryEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CountryEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CountryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CountryRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CountryRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.CountryManagementPermissionGroup));
            }
            #endregion

            #region Personality
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.PersonalityViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.PersonalityViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.PersonalityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.PersonalityCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.PersonalityCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.PersonalityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.PersonalityEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.PersonalityEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.PersonalityManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.PersonalityRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.PersonalityRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.PersonalityManagementPermissionGroup));
            }
            #endregion

            #region AVProducerHouse
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProducerHouseViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProducerHouseViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProducerHouseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProducerHouseCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProducerHouseCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProducerHouseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProducerHouseEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProducerHouseEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProducerHouseManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProducerHouseRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProducerHouseRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProducerHouseManagementPermissionGroup));
            }
            #endregion

            #region AVCategory
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVCategoryViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVCategoryViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVCategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVCategoryCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVCategoryCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVCategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVCategoryEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVCategoryEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVCategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVCategoryRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVCategoryRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVCategoryManagementPermissionGroup));
            }
            #endregion

            #region AVGenre
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVGenreViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVGenreViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVGenreManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVGenreCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVGenreCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVGenreManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVGenreEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVGenreEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVGenreManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVGenreRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVGenreRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVGenreManagementPermissionGroup));
            }
            #endregion

            #region AVProduction
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProductionViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProductionViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProductionCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProductionCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProductionEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProductionEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProductionManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.AVProductionRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.AVProductionRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.AVProductionManagementPermissionGroup));
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

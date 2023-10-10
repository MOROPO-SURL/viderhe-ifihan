using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.Web.Helpers
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

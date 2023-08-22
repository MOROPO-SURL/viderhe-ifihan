using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using MOROPO.VIDERHE.Service.Hotel.OTT.Web.Constants;
using System.Linq;

namespace MOROPO.VIDERHE.Service.Hotel.OTT.Web.Helpers
{
    public class DataInitializationHelper : Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper
    {
        public void InitialiseData(Microsoft.EntityFrameworkCore.DbContext dbContext)
        {
            var permissionDbSet = dbContext.Set<Framework.Guama.Core.Security.Common.Persistence.Entities.Permission>();

            if (!permissionDbSet.Any(role => role.Code.Equals(Permission.TraceViewer)))
            {
                permissionDbSet.Add(Permission.TraceViewer.ToPermissionEntity());
            }

            #region ApiKey
            if (!permissionDbSet.Any(item => item.Code.Equals(Permission.ApiKeyViewer)))
            {
                permissionDbSet.Add(Permission.ApiKeyViewer.ToPermissionEntity(PermissionsFamily.ApiKeyManagement));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Permission.ApiKeyCreator)))
            {
                permissionDbSet.Add(Permission.ApiKeyCreator.ToPermissionEntity(PermissionsFamily.ApiKeyManagement));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Permission.ApiKeyEditor)))
            {
                permissionDbSet.Add(Permission.ApiKeyEditor.ToPermissionEntity(PermissionsFamily.ApiKeyManagement));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(Permission.ApiKeyRemover)))
            {
                permissionDbSet.Add(Permission.ApiKeyRemover.ToPermissionEntity(PermissionsFamily.ApiKeyManagement));
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

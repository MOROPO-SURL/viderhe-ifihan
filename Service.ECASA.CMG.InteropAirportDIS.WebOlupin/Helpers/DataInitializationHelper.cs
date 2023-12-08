using MOROPO.Framework.Guama.Core.Security.Common.Persistence.ORM.EF.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.WebOlupin.Helpers
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

            #region Carrier
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CarrierCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CarrierViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.CarrierManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CarrierCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CarrierCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CarrierManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CarrierEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CarrierEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CarrierManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CarrierRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CarrierRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.CarrierManagementPermissionGroup));
            }
            #endregion

            #region Category
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CategoryViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CategoryViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.CategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CategoryCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CategoryCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CategoryEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CategoryEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CategoryManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CategoryRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CategoryRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.CategoryManagementPermissionGroup));
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

            #region Kind
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.KindViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.KindViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.KindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.KindCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.KindCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.KindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.KindEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.KindEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.KindManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.KindRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.KindRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.KindManagementPermissionGroup));
            }
            #endregion

            #region Status
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.StatusViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.StatusViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.StatusManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.StatusCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.StatusCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.StatusManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.StatusEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.StatusEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.StatusManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.StatusRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.StatusRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.StatusManagementPermissionGroup));
            }
            #endregion

            #region Terminal
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.TerminalViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.TerminalViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.TerminalManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.TerminalCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.TerminalCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.TerminalManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.TerminalEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.TerminalEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.TerminalManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.TerminalRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.TerminalRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.TerminalManagementPermissionGroup));
            }
            #endregion

            #region Operation
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.OperationViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.OperationViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.OperationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.OperationCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.OperationCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.OperationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.OperationEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.OperationEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.OperationManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.OperationRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.OperationRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.OperationManagementPermissionGroup));
            }
            #endregion

            #region CheckIn
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CheckInViewerPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CheckInViewerPermission.ToPermissionEntity(API.Common.Constants.Authorization.CheckInManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CheckInCreatorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CheckInCreatorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CheckInManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CheckInEditorPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CheckInEditorPermission.ToPermissionEntity(API.Common.Constants.Authorization.CheckInManagementPermissionGroup));
            }
            if (!permissionDbSet.Any(item => item.Code.Equals(API.Common.Constants.Authorization.CheckInRemoverPermission)))
            {
                permissionDbSet.Add(API.Common.Constants.Authorization.CheckInRemoverPermission.ToPermissionEntity(API.Common.Constants.Authorization.CheckInManagementPermissionGroup));
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

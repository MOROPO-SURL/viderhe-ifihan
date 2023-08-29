namespace MOROPO.VIDERHE.Service.Hotel.OTT.API.Common.Constants
{
    public static class Authorization
    {
        public const string TraceViewerPermission = "trace-viewer-permission";

        #region ApiKey
        public const string ApiKeyManagementPermissionGroup = "apikey-management-permission-group";

        public const string ApiKeyViewerPermission = "apikey-viewer-permission";
        public const string ApiKeyCreatorPermission = "apikey-creator-permission";
        public const string ApiKeyEditorPermission = "apikey-editor-permission";
        public const string ApiKeyRemoverPermission = "apikey-remover-permission";
        #endregion

        #region Channel
        public const string ChannelManagementPermissionGroup = "channel-management-permission-group";

        public const string ChannelViewerPermission = "channel-viewer-permission";
        public const string ChannelCreatorPermission = "channel-creator-permission";
        public const string ChannelEditorPermission = "channel-editor-permission";
        public const string ChannelRemoverPermission = "channel-remover-permission";
        #endregion
    }
}

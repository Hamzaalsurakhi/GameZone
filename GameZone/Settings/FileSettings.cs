namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images/Games";

        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFilesInMB = 1;
        public const int MinFilesInBYTES = MaxFilesInMB*1024*1024;
    }
}

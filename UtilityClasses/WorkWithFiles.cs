using BBC.Base;
using OpenQA.Selenium;
using System.IO;
using System.Linq;

namespace BBC.UtilityClasses
{
    class WorkWithFiles
    {
        public const string BbcScreenShots = "BbcScreenShots";

        private  DirectoryInfo DirInfo(string folderName) => new DirectoryInfo(@$"C:\{folderName}");

        public bool IsScreenShotsFolderEmpty() => IsFolderEmpty(BbcScreenShots);

        public void GetScreenshot()
        {
            var screenshotCapableDriver = BasePage.Driver as ITakesScreenshot;
            screenshotCapableDriver.GetScreenshot()
                .SaveAsFile(@$"C:\{BbcScreenShots}\{NumberOfFolderFiles(BbcScreenShots) + 1}.png");
        }

        public void CreateFolder(string folderName)
        {
            if (!DirInfo(folderName).Exists)
            {
                DirInfo(folderName).Create();
            }
        }

        public void ClearFolder(string folderName) => DirInfo(folderName).GetFiles().ToList()
            .ForEach(file => file.Delete());

        private bool IsFolderEmpty(string folderName) => DirInfo(folderName).GetFiles() == null;

        private int NumberOfFolderFiles(string folderName) => DirInfo(folderName).GetFiles().Count();
    }
}
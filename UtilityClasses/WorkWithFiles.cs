using BBC.Base;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BBC.UtilityClasses
{
    class WorkWithFiles
    {
        private string ScreenShotsFolderPath = ConfigurationManager.AppSettings["ScreenShotsFolderPath"];

        private DirectoryInfo GetDirInfo(string folderName) => new DirectoryInfo(ScreenShotsFolderPath);

        public void GetScreenshot()
        {
            var screenshotCapableDriver = BasePage.Driver as ITakesScreenshot;
            screenshotCapableDriver.GetScreenshot()
                .SaveAsFile(Path.Combine(ScreenShotsFolderPath, 
                $"{GetNumberOfFolderFiles(ConfigurationManager.AppSettings["ScreenShotsFolder"]) + 1}.png"));
        }

        public void CreateFolderIfNotCreated(string folderName)
        {
            if (!GetDirInfo(folderName).Exists)
            {
                GetDirInfo(folderName).Create();
            }
        }

        public void ClearFolder(string folderName) => GetDirInfo(folderName).GetFiles().ToList()
            .ForEach(file => file.Delete());

        public int GetNumberOfFolderFiles(string folderName) => GetDirInfo(folderName).GetFiles().Count();
    }
}
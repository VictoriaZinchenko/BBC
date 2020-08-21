using BBC.Base;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace BBC.UtilityClasses
{
    class WorkWithFiles
    {
        private DirectoryInfo GetDirInfo(string folderPath) => new DirectoryInfo(folderPath);

        public void GetScreenshot(string folderPath, string fileName)
        {
            var screenshotCapableDriver = BasePage.Driver as ITakesScreenshot;
            screenshotCapableDriver.GetScreenshot()
                .SaveAsFile(Path.Combine(folderPath, $"{fileName}.png"));
        }

        public void CreateFolderIfNotCreated(string folderPath)
        {
            if (!GetDirInfo(folderPath).Exists)
            {
                GetDirInfo(folderPath).Create();
            }
        }

        public void ClearFolder(string folderPath) => GetDirInfo(folderPath).GetFiles().ToList()
            .ForEach(file => file.Delete());

        public int GetNumberOfFolderFiles(string folderPath) => GetDirInfo(folderPath).GetFiles().Count();
    }
}
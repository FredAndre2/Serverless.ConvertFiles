using AWS.Cinte.Application.Services;
using AWS.Cinte.Dtos;
using NUnit.Framework;
using System.IO;

namespace AWS.Cinte.UTest
{
    public class FileServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async System.Threading.Tasks.Task ConvertExcelFileToTextFileTest_FileTestShouldExistAsync()
        {
            string myPathFromExcelFile = $"..\\..\\..\\FilesTest\\ArchivoCinte2021.xlsx";
            FilePathDto filePath = new FilePathDto { MyPathFromExcelFile = myPathFromExcelFile };
            FileService fileService = new FileService();
            bool response = await fileService.ConvertExcelFileToTextFile(filePath);
            Assert.AreEqual(true, response);         
        }
    }
}
using AWS.Cinte.Application.Contracts.Services;
using AWS.Cinte.Dtos;
using Spire.Xls;
using System;
using System.IO;
using System.Threading.Tasks;

namespace AWS.Cinte.Application.Services
{
    public class FileService : IFileService
    {
        public async Task ConvertExcelFileToTextFile(FilePathDto filePath)
        {
            try
            {
                string myDirectoryToTextFile = filePath.MyDirectoryToTextFile;
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(filePath.MyPathFromExcelFile);
                Worksheet sheet = workbook.Worksheets[0];
                string pathFileTxtWithoutFormat = $"{myDirectoryToTextFile}\\AWSCinte.txt";
                sheet.SaveToFile(pathFileTxtWithoutFormat, "|");
                await FormatFileTxt(myDirectoryToTextFile);
                File.Delete(pathFileTxtWithoutFormat);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task FormatFileTxt(string myDirectoryToTextFile)
        {
            try
            {
                string lineFromText = string.Empty;
                using (StreamWriter sw = File.CreateText($"{myDirectoryToTextFile}\\AWSCinteWithFormat.txt"))
                {
                    using (StreamReader sr = File.OpenText($"{myDirectoryToTextFile}\\AWSCinte.txt"))
                    {
                        while ((lineFromText = sr.ReadLine()) != null)
                        {
                            lineFromText = lineFromText.Replace("\"", string.Empty);
                            await sw.WriteLineAsync(lineFromText);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

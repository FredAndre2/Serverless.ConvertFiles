﻿using AWS.Cinte.Dtos;
using System.Threading.Tasks;

namespace AWS.Cinte.Application.Contracts.Services
{
    public interface IFileService
    {
        Task ConvertExcelFileToTextFile(FilePathDto filePath);
    }
}

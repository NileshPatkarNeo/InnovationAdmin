﻿using InnovationAdmin.Application.Contracts.Infrastructure;
using CsvHelper;

using System.Globalization;

namespace InnovationAdmin.Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        //public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter,new CultureInfo(""));
        //        csvWriter.WriteRecords(eventExportDtos);
        //    }

        //    return memoryStream.ToArray();
        //}
    }
}

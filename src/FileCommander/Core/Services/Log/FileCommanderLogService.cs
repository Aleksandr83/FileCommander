using Agl.Helpers;
using FileCommander.Models.FileManagerPanels.VirtualFS;
using System.Text;

namespace FileCommander.Services;

public class FileCommanderLogService : LogService, IFileCommanderLogService
{
    public FileCommanderLogService():base()
    {
    }

    public void LogBootRecord(string message, BootRecord bootRecord)
    {        
        var sb = new StringBuilder();
        sb.Append("RecordSize:{@RecordSize}, ");
        sb.Append("Version:{@Version}, "); 
        sb.Append("IsSupportCompression:{@IsSupportCompression}, ");
        sb.Append("IsSupportEncription:{@IsSupportEncription}, ");
        sb.Append("RootDirectoryId:{@RootDirectoryId}, ");
        sb.Append("OffsetFileTable:{@OffsetFileTable}, ");
        sb.Append("CountRecordsInTable:{@CountRecordsInTable}, ");
        sb.Append("DataBlockSize:{@DataBlockSize}, ");
        sb.Append("Crc:{@Crc}");

        Information
        (   $"{message} {sb.ToString()}", 
            TextConvertorHelper.IntToHex(bootRecord.RecordSize),
            bootRecord.Version,
            bootRecord.IsSupportCompression,
            bootRecord.IsSupportEncription,
            bootRecord.RootDirectoryId,
            TextConvertorHelper.IntToHex(bootRecord.OffsetFileTable),
            TextConvertorHelper.IntToHex(bootRecord.CountRecordsInTable),
            TextConvertorHelper.IntToHex(bootRecord.DataBlockSize),
            TextConvertorHelper.IntToHex(bootRecord.Crc)
        );
    }

    public void LogFileRecord(string message, FileRecord fileRecord)
    {
        var sb = new StringBuilder();
        sb.Append("Crc:{@Crc}, ");
        sb.Append("RecordSize:{@RecordSize}, ");
        sb.Append("IsDeleted:{@IsDeleted}, ");
        sb.Append("NextFileRecord:{@NextFileRecord}, ");
        sb.Append("Id:{@Id}, ");
        sb.Append("IsDirectory:{@IsDirectory}, ");
        sb.Append("ParentId{@ParentId}, ");
        sb.Append("IsCompressed{@IsCompressed}, ");
        sb.Append("CompressedType:{@CompressedType}, ");
        sb.Append("IsEncripted:{@IsEncripted}, ");
        sb.Append("Alg:{@Alg}, ");
        sb.Append("DataSize:{@DataSize}, ");
        sb.Append("DataBlockCount:{@DataBlockCount}, ");
        sb.Append("FirstDataBlockOffset:{@FirstDataBlockOffset}, ");
        sb.Append("EncodingNameType:{@EncodingNameType}, ");
        sb.Append("NameLength:{@NameLength}, ");
        sb.Append("Name:{@Name}");

        Information
        (   $"{message} {sb.ToString()}", 
            TextConvertorHelper.IntToHex(fileRecord.Crc),
            TextConvertorHelper.IntToHex(fileRecord.RecordSize),
            fileRecord.IsDeleted,
            TextConvertorHelper.IntToHex(fileRecord.NextFileRecord),
            TextConvertorHelper.IntToHex(fileRecord.Id),
            fileRecord.IsDirectory,
            TextConvertorHelper.IntToHex(fileRecord.ParentId),
            fileRecord.IsCompressed,
            TextConvertorHelper.IntToHex(fileRecord.CompressedType),
            fileRecord.IsEncripted,
            TextConvertorHelper.IntToHex(fileRecord.Alg),
            TextConvertorHelper.IntToHex(fileRecord.DataSize),
            TextConvertorHelper.IntToHex(fileRecord.DataBlockCount),
            TextConvertorHelper.IntToHex(fileRecord.FirstDataBlockOffset),
            fileRecord.EncodingNameType,
            TextConvertorHelper.IntToHex(fileRecord.NameLength),
            fileRecord.Name
        );
    }
}
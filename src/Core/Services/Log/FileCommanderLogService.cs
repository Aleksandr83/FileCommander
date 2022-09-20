using alg.Helpers;
using VirtualFS;

namespace FileCommander.Services
{
    public class FileCommanderLogService : LogService, IFileCommanderLogService
    {
        public FileCommanderLogService():base()
        {
        }

        public void LogBootRecord(string message, BootRecord bootRecord)
        {
            string s = "";

            s += "RecordSize:{@RecordSize}, ";
            s += "Version:{@Version}, "; 
            s += "IsSupportCompression:{@IsSupportCompression}, ";
            s += "IsSupportEncription:{@IsSupportEncription}, ";
            s += "RootDirectoryId:{@RootDirectoryId}, ";
            s += "OffsetFileTable:{@OffsetFileTable}, ";
            s += "CountRecordsInTable:{@CountRecordsInTable}, ";
            s += "DataBlockSize:{@DataBlockSize}, ";
            s += "Crc:{@Crc}";

            Information
            (   message + " " + s, 
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
            string s = "";

            s += "Crc:{@Crc}, ";
            s += "RecordSize:{@RecordSize}, ";
            s += "IsDeleted:{@IsDeleted}, ";
            s += "NextFileRecord:{@NextFileRecord}, ";
            s += "Id:{@Id}, ";
            s += "IsDirectory:{@IsDirectory}, ";
            s += "ParentId{@ParentId}, ";
            s += "IsCompressed{@IsCompressed}, ";
            s += "CompressedType:{@CompressedType}, ";
            s += "IsEncripted:{@IsEncripted}, ";
            s += "Alg:{@Alg}, ";
            s += "DataSize:{@DataSize}, ";
            s += "DataBlockCount:{@DataBlockCount}, ";
            s += "FirstDataBlockOffset:{@FirstDataBlockOffset}, ";
            s += "EncodingNameType:{@EncodingNameType}, ";
            s += "NameLength:{@NameLength}, ";
            s += "Name:{@Name}";

            Information
            (   message + " " + s, 
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
}
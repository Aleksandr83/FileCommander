using System;
using System.Runtime.InteropServices;

namespace VirtualFS
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FileRecord
    {
        internal byte    Crc;
        internal UInt16  RecordSize;       // Размер в байтах
        internal byte    IsDeleted;
        internal UInt32  NextFileRecord;   // Указатель на следующую запись        
        internal UInt32  Id;
        internal byte    IsDirectory;
        internal UInt32  ParentId;      
        internal byte    IsCompressed;   
        internal byte    CompressedType;   // 0 - сжатие отсутствует
        internal byte    IsEncripted;
        internal UInt16  Alg;              // 0 - шифрование отсутствует
        internal UInt32  DataSize;         // если IsDirectory == 0, то равно 0 
        internal UInt32  DataBlockCount;
        internal UInt32  FirstDataBlockOffset;               
        internal byte    EncodingNameType; // 0 - ascii    
        internal byte    NameLength;       // в байтах
        internal byte[]  Name;

        
    }

}
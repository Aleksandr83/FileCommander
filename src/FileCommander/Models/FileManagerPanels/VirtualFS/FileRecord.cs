using System;
using System.Runtime.InteropServices;

namespace FileCommander.Models.FileManagerPanels.VirtualFS;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FileRecord
{
    internal byte Crc;
    internal ushort RecordSize;       // Размер в байтах
    internal byte IsDeleted;
    internal uint NextFileRecord;   // Указатель на следующую запись        
    internal uint Id;
    internal byte IsDirectory;
    internal uint ParentId;
    internal byte IsCompressed;
    internal byte CompressedType;   // 0 - сжатие отсутствует
    internal byte IsEncripted;
    internal ushort Alg;              // 0 - шифрование отсутствует
    internal uint DataSize;         // если IsDirectory == 0, то равно 0 
    internal uint DataBlockCount;
    internal uint FirstDataBlockOffset;
    internal byte EncodingNameType; // 0 - ascii    
    internal byte NameLength;       // в байтах
    internal byte[] Name;


}
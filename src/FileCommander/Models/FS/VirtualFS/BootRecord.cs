using System;
using System.Runtime.InteropServices;

namespace VirtualFS;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BootRecord
{
    // 2
    internal UInt16  RecordSize;          // в байтах       
    // 1
    internal byte    Version;             // 01
    // 1
    internal byte    IsSupportCompression;// Поддержка сжатия
    // 1
    internal byte    IsSupportEncription; // Поддержка шифрования
    // 4
    internal UInt32  RootDirectoryId;     // По умолчанию - 0
    // 4
    internal UInt32  OffsetFileTable;     // Смещение
    // 4
    internal UInt32  CountRecordsInTable; // По умолчанию - 0
    // 4
    internal UInt32  DataBlockSize;       // Размер блока данных

    // 1
    internal byte    Crc;                 // считается с первого байта по recordSize-2 включительно
};
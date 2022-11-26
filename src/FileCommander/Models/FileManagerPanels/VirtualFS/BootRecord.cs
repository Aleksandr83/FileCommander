using System;
using System.Runtime.InteropServices;

namespace FileCommander.Models.FileManagerPanels.VirtualFS;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BootRecord
{
    // 2
    internal ushort RecordSize;          // в байтах       
    // 1
    internal byte Version;             // 01
    // 1
    internal byte IsSupportCompression;// Поддержка сжатия
    // 1
    internal byte IsSupportEncription; // Поддержка шифрования
    // 4
    internal uint RootDirectoryId;     // По умолчанию - 0
    // 4
    internal uint OffsetFileTable;     // Смещение
    // 4
    internal uint CountRecordsInTable; // По умолчанию - 0
    // 4
    internal uint DataBlockSize;       // Размер блока данных

    // 1
    internal byte Crc;                 // считается с первого байта по recordSize-2 включительно
};
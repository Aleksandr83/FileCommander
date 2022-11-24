using System;
using System.Collections.Generic;
using System.IO;
using Agl.Types.Generic;


namespace VirtualFS;

public class VirtualStorageSaver
{
    public VirtualStorageSaver()
    {

    }

    public void Save(Storage storage, string fileName)
    {          
        if (System.IO.File.Exists(fileName))
            System.IO.File.Delete(fileName);

        StreamWriter writer = new (fileName);
        
        using (BinaryWriter bw = new (writer.BaseStream))
        {       
            SaveBootRecord(bw, storage);
            SaveFileTable (bw, storage);
            
            
            bw.Flush();               
            bw.Close();
        }
    }

    void SaveBootRecord(BinaryWriter writer, Storage storage)
    {
        var    bootRecord = storage.GetBootRecord().GetValue();
            
        var    size       = Struct.GetSize<BootRecord>();
        Byte[] bytes      = Struct.ToArray<BootRecord>(bootRecord);

        writer.BaseStream.Seek(0, SeekOrigin.Begin);

        for (int i = 0; i < size; i++)
        {
            writer.Write(bytes[i]);
        }
    }

    void SaveFileTable(BinaryWriter writer, Storage storage)
    {
        UInt32 size;
        List<Byte> bytes;            
        dynamic items = storage.GetFileTable();

        var bootRecord = storage.GetBootRecord();
        UInt32 offset  = bootRecord.GetValue().OffsetFileTable;

        writer.BaseStream.Seek(offset, SeekOrigin.Begin);

        foreach (FileRecord item in items)
        {
            size  = item.RecordSize;
            bytes = new List<Byte>(Struct.ToArrayExt<FileRecord>(item)); 
            
            for (int i = 0; i < size; i++)
            {
                writer.Write(bytes[i]);
            }
        }
    }
}
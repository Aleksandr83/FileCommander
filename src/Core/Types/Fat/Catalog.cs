using System;

namespace Types.Fat
{

    public class Catalog
    {
        const int __SHORT_NAME_LENGTH = 11;        

        public struct TCatalogFat12
        {                                                                    // Смещение 
            public byte[]  ShortName      = new byte[__SHORT_NAME_LENGTH];   // 0x00
            public byte    FileAtributes  = 0;                               // 0x0B
            public byte    Reserved       = 0;                               // 0x0C
            public byte    TimeCreatedMilliseconds = 0;  // Fat32 only       // 0x0D
            public byte    TimeCreated    = 0;            // Fat32 only      // 0x0E   
            public byte[]  DateCreated    = new byte[2];  // Fat32 only      // 0x10
            public byte[]  LastDateAccess = new byte[2];  // Fat32 only      // 0x12
            public byte[]  HighWordNum    = new byte[2];  // Fat32 only      // 0x14
            public byte[]  LastTime       = new byte[2];                     // 0x16   
            public byte[]  LastDate       = new byte[2];                     // 0x18
            public byte[]  LowWordNum     = new byte[2];                     // 0x1A
            public UInt32  FileSize       = 0;                               // 0x1C

            public TCatalogFat12()
            {               
            }

        };

        #region Data
        TCatalogFat12 _Data = new TCatalogFat12();
        public TCatalogFat12 Data => _Data;
        #endregion Data

        #region Constructor
        public Catalog()
        {

        }
        #endregion Constructor

        public void SetFileName(string value)
        {

        }

        public void SetFileExt(string value)
        {

        }

        public void SetFileSize(UInt32 value)
        {
            
        }

        

    }

}

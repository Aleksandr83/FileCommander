using System;
using System.Text;

namespace Agl.Helpers;

public static class TextConvertorHelper
{
    public static string IntToHex(dynamic value)
    {
        string hex = "";
        int    addZeroCount = 0;

        if (value is UInt16)
        {
            UInt16 val = (UInt16)value;
            hex = val.ToString("x");
            addZeroCount = 4 - hex.Length;
            while (addZeroCount-- > 0)
            {
                hex = '0' + hex;
            }
        }
        else if (value is UInt32)
        {
            UInt32 val = (UInt32)value;
            hex = val.ToString("x");
            addZeroCount = 8 - hex.Length;
            while (addZeroCount-- > 0)
            {
                hex = '0' + hex;
            }
        }       
        else if (value is byte)
        {
            byte val = (byte)value;
            hex = val.ToString("x");
            if (hex.Length % 2 != 0) hex = '0' + hex;
        }            
                   
        return "0x"+hex.ToUpper();
    }

    public static string AsciiBytesToUtfString(Byte[]? value)
    {
        if ((value == null) || (value?.Length == 0)) return string.Empty;

        value = (value != null)? value: new byte[] {}; // ?            
        byte[] utf8Array = Encoding.Convert(Encoding.ASCII, Encoding.UTF8, (Byte[])value);
        return Encoding.UTF8.GetString(utf8Array);
    }
}
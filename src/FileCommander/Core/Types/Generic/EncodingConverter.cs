using System;
using System.Text;

namespace Agl.Types.Generic;


public class EncodingConverter
{
    public static Byte[] ToAssciByteArray(string input)
    {
        byte[] byteArray  = Encoding.UTF8.GetBytes(input);
        return Encoding.Convert(Encoding.UTF8, Encoding.ASCII, byteArray);
    }

}
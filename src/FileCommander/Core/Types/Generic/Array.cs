using System;
using System.Runtime.InteropServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Reflection;

namespace alg.Types.Generic;

public class ArrayType
{
    public static T? ToStruct<T>(Byte[] bytes, UInt32 size)
    {            
        IntPtr ptr      = IntPtr.Zero;
        int elementSize = Marshal.SizeOf(typeof(T));            
        
        try
        {
            ptr = Marshal.AllocHGlobal((int)elementSize);

            if (elementSize < size) 
                size = (UInt32)elementSize;

            Marshal.Copy(bytes, 0, ptr, (int)size);
            
            return (T?)Marshal.PtrToStructure(ptr, typeof(T));                
        }
        finally
        {
            if (ptr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(ptr);
            }
        }     
    }     

    public static T ToStructExt<T>(Byte[] bytes, UInt32 size,Func<T,FieldInfo,dynamic,T> setFieldFunc) where T:struct
    {
        int counter    = 0;
        T result       = new T();                                   
        var fields     = Struct.GetFields<T>();
        var structSize = Struct.GetSizeExt<T>();

        if (size < structSize) structSize = size;
            
        foreach (var field in fields)
        {
            bool fieldIsArray = false;

            if (field.FieldType.BaseType == typeof(System.Array)) 
            {
                continue;        
            }

            if (field.FieldType.BaseType == typeof(System.String))
                continue;

            
            dynamic  value      = 0;
            UInt32   fieldSize  = 0;                
            dynamic? fieldValue = field?.GetValue(result);
            

            if (!fieldIsArray)
            {                    
                fieldSize  = (UInt32)Marshal.SizeOf(fieldValue);
                fieldValue = 0;
                
                for (int i = 0; i < fieldSize; i++)
                {
                    value = bytes[counter++];
                    fieldValue |= (i == 0)? value: (value << 8);
                }

                result = setFieldFunc.Invoke(result, field ,fieldValue);                                    
            }                
        }    

        return result;
    }

    
    
}
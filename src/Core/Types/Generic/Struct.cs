using System;
using System.Runtime.InteropServices;
using Types.Generic;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using VirtualFS;

namespace alg.Types.Generic
{
    public static class Struct
    {

        public static UInt32 GetSize<T>()
        {                     
            return (UInt32)Marshal.SizeOf(typeof(T));               
        }

        public static IEnumerable<FieldInfo> GetFields<T>()
        {
            Queue<FieldInfo> result = new Queue<FieldInfo>();

            var items = typeof(T).GetTypeInfo().GetAllFields();

            foreach (var item in items)
            {
                result.Enqueue(item);
            }

            return result;            
        }        

        public static UInt32 GetSizeExt<T>()
        {
            UInt32 result = 0;            
            var fields    = GetFields<T>();            
            
            foreach (var field in fields)
            {
                if (field.FieldType.BaseType == typeof(System.Array))
                    continue;

                if (field.FieldType.BaseType == typeof(System.String))
                    continue;
                
                result += (UInt32)Marshal.SizeOf(field.FieldType);                
            }

            return result;
        }
        

        public static Byte[] ToArray<T>(dynamic value)
        {
            var size = GetSize<T>();

            Byte[] result = new Byte[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = Marshal.ReadByte(value, i);
            }           
           
            return result;
        }
        
        public static Byte[] ToArrayExt<T>(dynamic value)
        {                         
            List<Byte> result = new List<Byte>();              
            var fields        = typeof(T).GetTypeInfo().GetAllFields();

            foreach (var field in fields)
            {
                bool fieldIsArray = false;

                if (field.FieldType.BaseType == typeof(System.Array)) 
                {              
                    if (field.FieldType  == typeof(System.Byte[])) 
                        fieldIsArray = true;
                    else
                        continue;                  
                }
                
                if (field.FieldType.BaseType == typeof(System.String))
                    continue;

                UInt32   fieldSize  = 0;
                dynamic? fieldValue = field.GetValue(value);

                if (fieldIsArray)
                {
                    foreach (var item in fieldValue)
                    {
                        result.Add(item);
                    }
                }
                else
                {
                    fieldSize  = (UInt32)Marshal.SizeOf(fieldValue);

                    for (int i = 0; i < fieldSize; i++)
                    {
                        result.Add(Marshal.ReadByte(fieldValue,i));                      
                    }
                }

            }            

            return result.ToArray();
        }
    }
}
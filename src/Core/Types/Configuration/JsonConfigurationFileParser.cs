// Copyright (c) 2021 Lukin Aleksandr
using alg.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alg.Types.Configuration
{
    internal class JsonConfigurationFileParser
    {
        public static JsonSettings Parse(String fileName)
        {
            var jsonText = ReadAll(fileName).GetAwaiter()
                .GetResult();
            return ParseJsonText(jsonText);
        }

        public static JsonSettings Parse(Stream stream)
        {
            var jsonText = ReadAll(stream).GetAwaiter()
                .GetResult();
            return ParseJsonText(jsonText);           
        }

        private static async Task<String> ReadAll(Stream stream)
        {
            String result = "";
            using (StreamReader sr = new StreamReader(stream))
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);
                result = await sr.ReadToEndAsync().ConfigureAwait(false);                
                sr.Close();
            }
            return result;
        }

        private static async Task<String> ReadAll(String fileName)
        {
            var sourceStream = new FileStream
                (
                    fileName,
                    FileMode.Open, FileAccess.Read, FileShare.Read,
                    bufferSize: 4096, useAsync: true
                );
            return await ReadAll(sourceStream).ConfigureAwait(false); 

        }

        private static JsonSettings ParseJsonText(String jsonText)
        {
            return (string.IsNullOrEmpty(jsonText.Trim()))?
                new JsonSettings() :
                JsonHelper.Deserialize<JsonSettings>(jsonText);                
        }
        
    }
}

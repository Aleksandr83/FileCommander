using Agl.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agl.Types.Configuration;

internal class JsonSettings
{
    public List<SectionBlock> GetSettings() => _Settings;

    public SectionBlock? GetSectionByName(String sectionName)
    {
        var settings = GetSettings();
        foreach (var section in settings)
        {
            if (section.Section == sectionName)
                return section;
        }
        return null;
    }

    public SectionBlock Add(SectionBlock section)
    {
        var settings = GetSettings();
        settings.Add(section);
        return section;
    }
   
    public IDictionary<String,String> ToDictionary(char sectionSeparator)
    {                       
        IDictionary<String, String> result = new Dictionary<String, String>();
        var settings = GetSettings();            
        foreach (var section in settings)
        {
            foreach (var sectionBlock in section.Values)
            {
                var key = string.Format
                    (
                        "{0}{1}{2}",
                        section?.Section,
                        sectionSeparator,
                        sectionBlock?.GetKey()                            
                    );
                if (sectionBlock != null)
                    result.Add(key, sectionBlock.GetValue());
            }              
        }
        return result;
    }

    public String ToJson()
    {           
        return JsonHelper.Serialize(this);
    }

    public List<SectionBlock> Settings { get { return _Settings; } }

    private readonly List<SectionBlock> _Settings = new List<SectionBlock>();
}

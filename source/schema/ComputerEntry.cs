using System.Collections.Generic;

namespace ostranauts_modding
{
    public class ComputerEntry
    {
        public string strName { get; set; }
        public IList<string> strSubEntries { get; set; }
    }
}
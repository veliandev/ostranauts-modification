using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Loot
    {
        public IList<string> aCOs { get; set; }
        public IList<string> aLoots { get; set; }
        public string strName { get; set; }
        public string strType { get; set; }
        public bool? bNested { get; set; }
        public bool? bSuppress { get; set; }
    }
}
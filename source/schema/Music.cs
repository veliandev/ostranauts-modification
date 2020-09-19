using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Music
    {
        public bool bLoop { get; set; }
        public string strName { get; set; }
        public IList<string> strTags { get; set; }
    }
}
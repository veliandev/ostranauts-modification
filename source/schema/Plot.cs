using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Plot
    {
        public IList<string> aInteractNames { get; set; }
        public bool bCreateMissing { get; set; }
        public string strName { get; set; }
        public string strStartInteraction { get; set; }
    }
}
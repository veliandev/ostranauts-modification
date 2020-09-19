using System.Collections.Generic;

namespace ostranauts_modding
{
    public class InteractionSocialCombat
    {
        public string displayName { get; set; }
        public IList<IList<string>> effects { get; set; }
        public string internalName { get; set; }
        public IList<IList<string>> responses { get; set; }
        public string strImg { get; set; }
        public IList<IList<string>> tooltipInfo { get; set; }
        public string log { get; set; }
        public IList<string> causedBy { get; set; }
    }
}
using System.Collections.Generic;

namespace ostranauts_modding
{
    public class ConditionOverlay
    {
        public IList<string> mapModeSwitches { get; set; }
        public string strCOBase { get; set; }
        public string strCondLoot { get; set; }
        public string strImg { get; set; }
        public string strImgNorm { get; set; }
        public string strName { get; set; }
        public string strNameFriendly { get; set; }
        public string strPortraitImg { get; set; }
        public IList<string> aInteractionsReplace { get; set; }
    }
}
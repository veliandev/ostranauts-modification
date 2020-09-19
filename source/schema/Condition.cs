using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Condition
    {
        public IList<string> aNext { get; set; }
        public bool bFatal { get; set; }
        public bool bRemoveAll { get; set; }
        public bool bResetTimer { get; set; }
        public double fDuration { get; set; }
        public int nDisplayOther { get; set; }
        public int nDisplaySelf { get; set; }
        public string strColor { get; set; }
        public string strDesc { get; set; }
        public string strName { get; set; }
        public string strNameFriendly { get; set; }
        public IList<string> aPer { get; set; }
        public string strAnti { get; set; }
        public bool? bPersists { get; set; }
        public bool? bRoom { get; set; }
    }
}
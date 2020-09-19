using System.Collections.Generic;

namespace ostranauts_modding
{
    public class ConditionTrigger
    {
        public IList<string> aForbids { get; set; }
        public IList<string> aReqs { get; set; }
        public IList<string> aTriggers { get; set; }
        public bool bAND { get; set; }
        public double fChance { get; set; }
        public double fCount { get; set; }
        public string strCondName { get; set; }
        public string strName { get; set; }
    }
}
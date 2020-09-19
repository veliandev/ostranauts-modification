using System.Collections.Generic;

namespace ostranauts_modding
{
    public class AThreshold
    {
        public double fMax { get; set; }
        public int fMaxAdd { get; set; }
        public double fMin { get; set; }
        public int fMinAdd { get; set; }
        public string strLootNew { get; set; }
    }

    public class ConditionRule
    {
        public IList<AThreshold> aThresholds { get; set; }
        public string strCond { get; set; }
        public string strName { get; set; }
    }
}
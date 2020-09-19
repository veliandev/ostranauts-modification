using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Installable
    {
        public string CTThem { get; set; }
        public string CTUs { get; set; }
        public IList<string> aInputs { get; set; }
        public IList<string> aInverse { get; set; }
        public IList<string> aLootCOs { get; set; }
        public IList<string> aToolCTsUse { get; set; }
        public bool bSparks { get; set; }
        public double fDuration { get; set; }
        public double fTargetPointRange { get; set; }
        public string strActionCO { get; set; }
        public string strAllowLootCTsThem { get; set; }
        public string strBuildType { get; set; }
        public string strInteractionTemplate { get; set; }
        public string strJobType { get; set; }
        public string strName { get; set; }
        public string strProgressStat { get; set; }
        public string strStartInstall { get; set; }
        public bool? bHeadless { get; set; }
    }
}
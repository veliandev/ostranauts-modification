using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Interaction
    {
        public string strName { get; set; }
        public string strTitle { get; set; }
        public string strDesc { get; set; }
        public string strTargetPoint { get; set; }
        public double fTargetPointRange { get; set; }
        public string strAnim { get; set; }
        public string strIdleAnim { get; set; }
        public string strBubble { get; set; }
        public IList<string> aInverse { get; set; }
        public double fDuration { get; set; }
        public string strThemType { get; set; }
        public int nLogging { get; set; }
        public bool bOpener { get; set; }
        public string LootCTsUs { get; set; }
        public string LootCTsThem { get; set; }
        public string CTTestUs { get; set; }
        public string CTTestThem { get; set; }
        public IList<string> aLootItms { get; set; }
        public string objLootModeSwitch { get; set; }
        public string strRaiseUI { get; set; }
        public bool? bModeSwitchCheckFit { get; set; }
        public double? fRotation { get; set; }
        public string strTeleport { get; set; }
        public bool? bHumanOnly { get; set; }
        public bool? bPortraitThem { get; set; }
        public IList<string> aSocialPrereqs { get; set; }
        public string strDescPlot { get; set; }
        public IList<string> aSocialNew { get; set; }
        public bool? bEquip { get; set; }
        public string LootReveals { get; set; }
        public string strColor { get; set; }
        public string strSubUI { get; set; }
        public string strImage { get; set; }
        public bool? bCloser { get; set; }
        public string strContextLootUs { get; set; }
        public string strContextLootThem { get; set; }
        public bool? bPause { get; set; }
        public bool? bLot { get; set; }
        public bool? bNoWait { get; set; }
        public bool? bPassThrough { get; set; }
        public string strCancelInteraction { get; set; }
        public IList<string> aTickersUs { get; set; }
    }
}
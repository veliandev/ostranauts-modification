using System.Collections.Generic;

namespace ostranauts_modding
{
    public class ConditionOwner
    {
        public IList<string> aInteractions { get; set; }
        public IList<string> aStartingConds { get; set; }
        public IList<string> aUpdateCommands { get; set; }
        public string jsonPI { get; set; }
        public IList<object> mapCondTolerance { get; set; }
        public IList<string> mapGUIPropMaps { get; set; }
        public IList<string> mapPoints { get; set; }
        public string strItemDef { get; set; }
        public string strLoot { get; set; }
        public string strName { get; set; }
        public string strPortraitImg { get; set; }
        public string strType { get; set; }
        public string strAudioEmitter { get; set; }
        public string strNameFriendly { get; set; }
        public IList<string> aSlotsWeHave { get; set; }
        public IList<string> aStartingCondRules { get; set; }
        public IList<object> aStartingCondsDyn { get; set; }
        public IList<string> aTickers { get; set; }
        public bool? bSaveMessageLog { get; set; }
        public string strContainerCT { get; set; }
        public IList<string> mapSlotImage { get; set; }
        public IList<string> mapSlotUsage { get; set; }
        public string strDesc { get; set; }
        public int? nStackLimit { get; set; }
        public IList<string> mapAltItemDefs { get; set; }
        public string strPaperDollImg { get; set; }
        public IList<string> aComponents { get; set; }
        public int? inventoryHeight { get; set; }
        public int? inventoryWidth { get; set; }
    }
}
using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Career
    {
        public IList<string> aEvents { get; set; }
        public IList<string> aEventsShip { get; set; }
        public IList<string> aSkillsFirst { get; set; }
        public IList<string> aSkillsHobby { get; set; }
        public IList<string> aSkillsNext { get; set; }
        public int nFirst { get; set; }
        public int nHobby { get; set; }
        public int nNext { get; set; }
        public string strCTPrereqs { get; set; }
        public string strLootConds { get; set; }
        public string strName { get; set; }
        public string strNameFriendly { get; set; }
        public bool? bComingSoon { get; set; }
        public bool? bHide { get; set; }
    }
}
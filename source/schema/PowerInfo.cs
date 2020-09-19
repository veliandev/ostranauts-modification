using System.Collections.Generic;

namespace ostranauts_modding
{
    public class PowerInfo
    {
        public IList<string> aInputPts { get; set; }
        public bool bAllowExtPower { get; set; }
        public double fAmount { get; set; }
        public double fMaxStored { get; set; }
        public string strIntPowerOff { get; set; }
        public string strIntPowerOn { get; set; }
        public string strName { get; set; }
        public string strRechargeCT { get; set; }
        public string strUsePowerCT { get; set; }
    }
}
using System.Collections.Generic;

namespace ostranauts_modding
{
    public class AGPMSetting
    {
        public string strName { get; set; }
        public IList<string> dictGUIPropMap { get; set; }
    }

    public class AItem
    {
        public string strName { get; set; }
        public double fX { get; set; }
        public double fY { get; set; }
        public double fRotation { get; set; }
        public string strID { get; set; }
        public IList<AGPMSetting> aGPMSettings { get; set; }
    }
    public class AShallowPSpec
    {
        public string strName { get; set; }
        public double fX { get; set; }
        public double fY { get; set; }
        public double fRotation { get; set; }
        public string strID { get; set; }
        public IList<AGPMSetting> aGPMSettings { get; set; }
    }

    public class VShipPos
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class VAccIn
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class VAccRCS
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class VAccEx
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    public class ObjSS
    {
        public string boPORShip { get; set; }
        public double vPosx { get; set; }
        public double vPosy { get; set; }
        public double vBOOffsetx { get; set; }
        public double vBOOffsety { get; set; }
        public double vVelX { get; set; }
        public double vVelY { get; set; }
        public VAccIn vAccIn { get; set; }
        public VAccRCS vAccRCS { get; set; }
        public VAccEx vAccEx { get; set; }
        public double fRot { get; set; }
        public double fW { get; set; }
        public double fA { get; set; }
        public bool bBOLocked { get; set; }
        public bool bIsBO { get; set; }
    }

    public class ARoom
    {
        public string strID { get; set; }
        public bool bVoid { get; set; }
        public IList<int> aTiles { get; set; }
    }

    public class Ship
    {
        public string strName { get; set; }
        public string strRegID { get; set; }
        public int nCurrentWaypoint { get; set; }
        public double fTimeEngaged { get; set; }
        public IList<AItem> aItems { get; set; }
        public IList<AShallowPSpec> aShallowPSpecs { get; set; }
        public VShipPos vShipPos { get; set; }
        public ObjSS objSS { get; set; }
        public IList<ARoom> aRooms { get; set; }
        public int DMGStatus { get; set; }
        public double fLastVisit { get; set; }
        public bool bPrefill { get; set; }
        public bool bNoCollisions { get; set; }
        public double dLastScanTime { get; set; }
        public bool bLocalAuthority { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string origin { get; set; }
        public string designation { get; set; }
        public string publicName { get; set; }
        public string dimensions { get; set; }
        public double fShallowMass { get; set; }
        public double fShallowRCSRemass { get; set; }
        public double fShallowFusionRemain { get; set; }
        public int nRCSCount { get; set; }
        public int nRCSDistroCount { get; set; }
        public bool bFusionTorch { get; set; }
    }
}
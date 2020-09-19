namespace ostranauts_modding
{
    public class AudioEmitter
    {
        public double fLoPassFreq { get; set; }
        public double fLoPassFreqOccluded { get; set; }
        public double fMaxDistance { get; set; }
        public double fMinDistance { get; set; }
        public double fSpatialBlend { get; set; }
        public double fSteadyDelay { get; set; }
        public double fTransDuration { get; set; }
        public double fVolumeSteady { get; set; }
        public double fVolumeTrans { get; set; }
        public string strClipSteady { get; set; }
        public string strClipTrans { get; set; }
        public string strFalloffCurve { get; set; }
        public string strLowPassCurve { get; set; }
        public string strMixerName { get; set; }
        public string strName { get; set; }
    }
}
using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Item
    {
        public IList<string> aSocketAdds { get; set; }
        public IList<string> aSocketForbids { get; set; }
        public IList<string> aSocketReqs { get; set; }
        public int nCols { get; set; }
        public string strImg { get; set; }
        public string strImgNorm { get; set; }
        public string strName { get; set; }
        public IList<string> aShadowBoxes { get; set; }
        public double? fZScale { get; set; }
        public IList<string> aLights { get; set; }
        public bool? bHasSpriteSheet { get; set; }
        public string ctSpriteSheet { get; set; }
        public int? inventoryHeight { get; set; }
        public int? inventoryWidth { get; set; }
    }
}
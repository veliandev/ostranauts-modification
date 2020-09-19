namespace ostranauts_modding
{
    public class PtPos
    {
        public int x { get; set; }
        public int y { get; set; }
    }

    public class Light
    {
        public PtPos ptPos { get; set; }
        public string strColor { get; set; }
        public string strImg { get; set; }
        public string strName { get; set; }
    }
}
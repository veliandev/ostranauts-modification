using System.Collections.Generic;

namespace ostranauts_modding
{
    public class Homeworld
    {
        public IList<string> aCondsCitizen { get; set; }
        public IList<string> aCondsIllegal { get; set; }
        public IList<string> aCondsResident { get; set; }
        public int nFoundingYear { get; set; }
        public string strATCCode { get; set; }
        public string strColonyName { get; set; }
        public string strName { get; set; }
    }
}
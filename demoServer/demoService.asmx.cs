using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace demoServer
{
    [WebService(Namespace = "http://example.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    // [System.Web.Script.Services.ScriptService]
    public class demoService : System.Web.Services.WebService
    {
        [WebMethod]
        public List<int> GetFibonacciSequence(int n)
        {
            var sequence = new List<int>() { 0, 1 };
            for (int i = 2; i < n; i++)
                sequence.Add(sequence[i - 2] + sequence[i - 1]);
            return sequence;
        }
    }
}

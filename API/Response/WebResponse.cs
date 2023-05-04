using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Response
{
    public class WebResponse
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public object Response { get; set; }
    }
}

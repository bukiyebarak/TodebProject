using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Configuration.Response
{
    public class CommandResponse
    {
        public bool Status { get; set; }
        public string Messsage { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Update_At { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Dtos
{
    public class SendPostGetThumb
    {

            public string format { get; set; } = "jpeg";
            public string mode { get; set; } = "strict";
            public string path { get; set; }
            public string size { get; set; } = "w64h64";

        public SendPostGetThumb(string path)
        {
            this.path = path;
        }

    }
}

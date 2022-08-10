using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.DropBox.Dtos
{
    public class SendPostGetThumb
    {

            public string Path { get; set; }

        public SendPostGetThumb(string path)
        {
            this.Path = path;
        }

    }
}

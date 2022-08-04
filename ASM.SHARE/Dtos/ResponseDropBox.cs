using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM.SHARE.Dtos
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Entry
    {
        [JsonProperty(".tag")]
        public string Tag { get; set; }
        public Metadata metadata { get; set; }
        public string thumbnail { get; set; }
    }

    public class Metadata
    {
        public string name { get; set; }
        public string path_lower { get; set; }
        public string path_display { get; set; }
        public string id { get; set; }
        public DateTime client_modified { get; set; }
        public DateTime server_modified { get; set; }
        public string rev { get; set; }
        public int size { get; set; }
        public bool is_downloadable { get; set; }
        public string content_hash { get; set; }
    }

    public class ResponseThumb
    {
        public List<Entry> entries { get; set; }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Common
{
    public class Notepad
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("note")]
        public string Note { get; set; }
    }
}

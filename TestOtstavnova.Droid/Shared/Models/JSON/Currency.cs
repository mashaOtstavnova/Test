using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Shared.Models.JSON
{

    public class RootObject
    {
        public List<Stock> Stock { get; set; }
        public DateTime As_of { get; set; }
    }
}

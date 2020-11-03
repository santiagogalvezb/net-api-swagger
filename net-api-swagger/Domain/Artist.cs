using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_swagger.Domain
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public string Nickname { get; set; }
        public Country Country { get; set; }
        private Guid _idCountry;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_api_swagger.Domain
{
    public class Song
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Duration { get; set; }

        public Artist Artist { get; set; }
        private Guid _idArtist;
    }
}

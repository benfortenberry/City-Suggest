using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GG.Models
{
    public class VenueDTO
    {
        public int? id { get; set; }
        public string city { get; set; }

        public string name { get; set; }

        public string state { get; set; }

        public string website { get; set; }
        public string address { get; set; }

        public string hours { get; set; }

        public string zip { get; set; }

        public string instagram { get; set; }

        public string twitter { get; set; }

        public string facebook { get; set; }

        public string parking { get; set; }

        public string email { get; set; }

        public string contact { get; set; }

        public string neighborhood { get; set; }

        public List<TypeDTO> types {get; set;}

        public List<TimeDTO> times { get; set; }

        public List<PriceDTO> prices { get; set; }

        public List<TagDTO> tags { get; set; }

        public List<ImageDTO> images { get; set; }

        public List<VideoDTO> videos { get; set; }

    }
}
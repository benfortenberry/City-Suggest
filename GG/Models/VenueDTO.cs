using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GG.Models
{
    public class VenueDTO
    {
        public int id { get; set; }
        public string city { get; set; }

        public string name { get; set; }

        public string state { get; set; }

        public string website { get; set; }
        public string address { get; set; }

        public string hours { get; set; }

        public List<TypeDTO> types {get; set;}

        public List<TimeDTO> times { get; set; }

        public List<PriceDTO> prices { get; set; }

        public List<TagDTO> tags { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GG.Models;
using System.Runtime.Serialization;
using System.Net.Mail;
using System.Text;

using System.Net;
namespace GG.Controllers
{
    public class ggWebAPIController : ApiController
    {

        [HttpGet]
        [Route("API/allTimes")]
        [System.Web.Http.ActionName("allTimes")]

        public List<TimeDTO> allTimes()
        {

            List<TimeDTO> response = new List<TimeDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.Times
                         .Select(b => new TimeDTO
                         {

                            id =  b.Id,
                              timeText = b.Text


                         })

                         select x).ToList();


                response = l;


            }

            return response;


        }

        [HttpGet]
        [Route("API/allTags")]
        [System.Web.Http.ActionName("allTags")]

        public List<TagDTO> allTags()
        {

            List<TagDTO> response = new List<TagDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.Tags
                         .Select(b => new TagDTO
                         {

                               id = b.Id,
                               tagText = b.Text


                         })

                         select x).ToList();


                response = l;


            }

            return response;


        }


        [HttpGet]
        [Route("API/allPrices")]
        [System.Web.Http.ActionName("allPrices")]

        public List<PriceDTO> allPrices()
        {

            List<PriceDTO> response = new List<PriceDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.Prices1
                         .Select(b => new PriceDTO
                         {

                             id = b.Id,
                              priceText = b.Text


                         })

                         select x).ToList();


                response = l;


            }

            return response;


        }

        [HttpGet]
        [Route("API/allTypes")]
        [System.Web.Http.ActionName("allTypes")]

        public List<TypeDTO> allTypes()
        {

            List<TypeDTO> response = new List<TypeDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.Types
                         .Select(b => new TypeDTO
                         {

                           id= b.Id,
                             typeText = b.Text


                         })

                         select x).ToList();


                response = l;


            }

            return response;


        }


    }
}
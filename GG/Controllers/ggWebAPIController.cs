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

                             id = b.Id,
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

                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


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

                             id = b.Id,
                             typeText = b.Text


                         })

                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


                response = l;


            }

            return response;


        }


        [HttpGet]
        [Route("API/allVenues")]
        [System.Web.Http.ActionName("allVenues")]

        public List<VenueDTO> allVenues()
        {

            List<VenueDTO> response = new List<VenueDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.Venues
                         .Select(b => new VenueDTO
                         {

                             id = b.Id,
                             address= b.Address,
                              city = b.City,
                               hours = b.Hours,
                                name = b.Name,
                             prices = b.Prices.Select(m => new PriceDTO
                             {
                                id = m.Id,
                                 priceText = m.Text


                             }).ToList(),
                             state = b.State,
                             tags = b.Tags.Select(m => new TagDTO
                             {
                                 id = m.Id,
                                 tagText = m.Text


                             }).ToList(),
                             times = b.Times.Select(m => new TimeDTO
                             {
                                 id = m.Id,
                                 timeText = m.Text


                             }).ToList(),
                             types = b.Types.Select(m => new TypeDTO
                             {
                                 id = m.Id,
                                 typeText = m.Text


                             }).ToList(),
                             website = b.Website



                         })

                         select x).OrderBy(x => x.name).ToList();


                response = l;


            }

            return response;


        }

        [HttpPost]
        [Route("API/searchVenue")]
        [System.Web.Http.ActionName("searchVenue")]

        public List<VenueDTO> searchVenue(VenueSearchDTO v)
        {

            List<VenueDTO> response = new List<VenueDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {

                var query = (from oData in db.Venues select oData);
                if (v.price != "whatever")
                    query = query.Where(m => m.Prices.Any(pr => pr.Text == v.price));
                if (v.tag != "anything")
                    query = query.Where(m => m.Tags.Any(ta => ta.Text == v.tag));
                if (v.time != "anytime")
                    query = query.Where(m => m.Times.Any(ti => ti.Text == v.time));
                if (v.type != "random place")
                    query = query.Where(m => m.Types.Any(ty => ty.Text == v.type));


                var l = query


                                    .Select(b => new VenueDTO
                                    {
                                        id = b.Id,
                                        city = b.City,
                                        address = b.Address,
                                        hours = b.Hours,
                                        name = b.Name,
                                        state = b.State,
                                        website = b.Website
                                    }).OrderBy(x => Guid.NewGuid())
                                    .Take(10).ToList();

                response = l;


   




            }

            return response;


        }

    }
}
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

                         select x).OrderBy(x => x.timeText).ToList();


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

                         select x).OrderBy(x => x.tagText).ToList();


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

                         select x).OrderBy(x => x.priceText).ToList();


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
                        

                         select x).OrderBy(x => x.typeText).ToList();


                response = l;


            }

            return response;


        }


        //mixer

        [HttpGet]
        [Route("API/allTimes_Mixer")]
        [System.Web.Http.ActionName("allTimes_Mixer")]

        public List<TimeDTO> allTimes_Mixer()
        {

            List<TimeDTO> response = new List<TimeDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {



                var l = (from time in db.Times

                         where time.Venues.Any(z => z.Times.Contains(time))
                         select time);

                var t = (from x in l
                         .Select(b => new TimeDTO
                         {

                             id = b.Id,
                             timeText = b.Text


                         })

                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


                response = t;


            }

            return response;


        }

        [HttpGet]
        [Route("API/allTags_Mixer")]
        [System.Web.Http.ActionName("allTags_Mixer")]

        public List<TagDTO> allTags_Mixer()
        {

            List<TagDTO> response = new List<TagDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {

                var l = (from tag in db.Tags

                         where tag.Venues.Any(z => z.Tags.Contains(tag))
                         select tag);

                var t = (from x in l
                         .Select(b => new TagDTO
                         {

                             id = b.Id,
                             tagText = b.Text


                         })

                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


                response = t;


            }

            return response;


        }


        [HttpGet]
        [Route("API/allPrices_Mixer")]
        [System.Web.Http.ActionName("allPrices_Mixer")]

        public List<PriceDTO> allPrices_Mixer()
        {

            List<PriceDTO> response = new List<PriceDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {




                var l = (from price in db.Prices1

                         where price.Venues.Any(z => z.Prices.Contains(price))
                         select price);

                var t = (from x in l
                         .Select(b => new PriceDTO
                         {

                             id = b.Id,
                             priceText = b.Text


                         })
                         select x).ToList().OrderBy(x => Guid.NewGuid()).Take(4).ToList();

                response = t;


            }

            return response;


        }

        [HttpGet]
        [Route("API/allTypes_Mixer")]
        [System.Web.Http.ActionName("allTypes_Mixer")]

        public List<TypeDTO> allTypes_Mixer()
        {

            List<TypeDTO> response = new List<TypeDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from type in db.Types

                         where type.Venues.Any(z => z.Types.Contains(type))
                         select type);

                var t = (from x in l
                         .Select(b => new TypeDTO
                         {

                             id = b.Id,
                             typeText = b.Text


                         })


                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


                response = t;


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
                             address = b.Address,
                              city = b.City,

                               hours = b.Hours,
                                name = b.Name,
                                 contact = b.Contact,
                                  email = b.Email,
                                   facebook = b.Facebook,
                                    instagram = b.Instagram,
                                     neighborhood = b.Neighborhood,
                                      parking = b.Parking,
                                       twitter = b.Twitter,
                                        zip = b.Zip,

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
                                        website = b.Website,
                                         zip = b.Zip,
                                          twitter = b.Twitter,
                                           parking = b.Parking,
                                            neighborhood = b.Neighborhood,
                                             instagram = b.Instagram,
                                              contact = b.Contact,
                                               email = b.Email,
                                                facebook = b.Facebook
                                    }).OrderBy(x => Guid.NewGuid())
                                    .Take(10).ToList();

                response = l;


   




            }

            return response;


        }


        [HttpPost]
        [Route("API/updateVenue")]
        [System.Web.Http.ActionName("searchVenue")]

        public Boolean updateVenue(VenueDTO v)
        {

            Boolean response;

            using (var db = new GG.Models.GGModelContainer())
            {
                 

               

                if (v.id == null)
                {

                    Venue VenueTbl = new Venue();


                    VenueTbl = new Venue
                    {
                        
                        Address = v.address,
                        City = v.city,
                        Hours = v.hours,
                        Name = v.name,
                        State = v.state,
                        Website = v.website,
                         Contact = v.contact,
                          Email = v.email,
                           Facebook= v.facebook,
                            Instagram = v.instagram,
                             Neighborhood = v.neighborhood,
                              Twitter = v.twitter,
                               Zip = v.zip,
                                Parking = v.parking
                                
                         

                    };

                    db.Venues.Add(VenueTbl);


                    db.SaveChanges();

                    response = true;
                    return response;


                }
                else
                {
                    Venue VenueTbl = new Venue();

                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                    existingVenue.Address = v.address;
                    existingVenue.City = v.city;
                    existingVenue.Hours = v.hours;
                    existingVenue.Name = v.name;
                    existingVenue.State = v.state;
                    existingVenue.Website = v.website;
                    existingVenue.Email = v.email;
                    existingVenue.Zip = v.zip;
                    existingVenue.Twitter = v.twitter;
                    existingVenue.Parking = v.parking;
                    existingVenue.Facebook = v.facebook;
                    existingVenue.Instagram = v.instagram;
                    existingVenue.Neighborhood = v.neighborhood;
                    existingVenue.Contact = v.contact;
                   




                    db.SaveChanges();

                    return true;
                }


             

                







            }

          

        }

        [HttpPost]
        [Route("API/addPrice")]
        [System.Web.Http.ActionName("addPrice")]

        public List<PriceDTO> addPrice(VenueDTO v)
        {

            PriceDTO p = new PriceDTO();

            p = v.prices.Last();

            

            using (var db = new GG.Models.GGModelContainer())
            {

                
                if (p.id == null)
                {

                    Price PriceTbl = new Price();

                    PriceDTO newPrice = new PriceDTO();

                    PriceTbl = new Price
                    {

                      Text = p.priceText
                      
                    };

                    db.Prices1.Add(PriceTbl);
                    
                    db.SaveChanges();

                    newPrice = p;
                    newPrice.id = PriceTbl.Id;

                    var existingPrice = (from x in db.Prices1 where x.Id == newPrice.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                    existingVenue.Prices.Add(existingPrice);

                    db.SaveChanges();

                    var l = (from x in existingVenue.Prices
                                         .Select(b => new PriceDTO
                                         {

                                             id = b.Id,
                                             priceText = b.Text


                                         })

                             select x).ToList();


                    return l;

                }
                else
                {
                    Venue VenueTbl = new Venue();

                    var existingPrice = (from x in db.Prices1 where x.Id == p.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                    existingVenue.Prices.Add(existingPrice);


                    db.SaveChanges();

                    var l = (from x in existingVenue.Prices
                                         .Select(b => new PriceDTO
                                         {

                                             id = b.Id,
                                             priceText = b.Text


                                         })

                             select x).ToList();


                    return l;
                }





            }

         
        }


        [HttpPost]
        [Route("API/removePrice")]
        [System.Web.Http.ActionName("removePrice")]

        public List<PriceDTO> removePrice(VenueDTO v)
        {

            PriceDTO p = new PriceDTO();

            p = v.prices.Last();



            using (var db = new GG.Models.GGModelContainer())
            {
                
                    Venue VenueTbl = new Venue();

                    var existingPrice = (from x in db.Prices1 where x.Id == p.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                    existingVenue.Prices.Remove(existingPrice);


                    db.SaveChanges();

                    var l = (from x in existingVenue.Prices
                                         .Select(b => new PriceDTO
                                         {

                                             id = b.Id,
                                             priceText = b.Text


                                         })

                             select x).ToList();


                    return l;
                

            }


        }

        [HttpPost]
        [Route("API/deleteVenue")]
        [System.Web.Http.ActionName("deleteVenue")]

        public Boolean deleteVenue(VenueDTO v)
        {

           

            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

             
                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();



                foreach (var x in db.Types.ToList())
                {
                    x.Venues.Remove(existingVenue);
                }

                foreach (var x in db.Tags.ToList())
                {
                    x.Venues.Remove(existingVenue);
                }

                foreach (var x in db.Times.ToList())
                {
                    x.Venues.Remove(existingVenue);
                }

                foreach (var x in db.Prices1.ToList())
                {
                    x.Venues.Remove(existingVenue);
                }


                db.Venues.Remove(existingVenue);


                db.SaveChanges();

                return true;



            }


        }



        //type

        [HttpPost]
        [Route("API/addType")]
        [System.Web.Http.ActionName("addType")]

        public List<TypeDTO> addType(VenueDTO v)
        {

            TypeDTO t = new TypeDTO();

            t = v.types.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                if (t.id == null)
                {

                    Models.Type TypeTbl = new Models.Type();

                    TypeDTO newType = new TypeDTO();

                    TypeTbl = new Models.Type
                    {

                        Text = t.typeText

                    };

                    db.Types.Add(TypeTbl);

                    db.SaveChanges();

                    newType = t;
                    newType.id = TypeTbl.Id;

                    var existingType = (from x in db.Types where x.Id == newType.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                    existingVenue.Types.Add(existingType);

                    db.SaveChanges();

                    var l = (from x in existingVenue.Types
                                         .Select(b => new TypeDTO
                                         {

                                             id = b.Id,
                                             typeText = b.Text


                                         })

                             select x).ToList();


                    return l;

                }
                else
                {
                    Venue VenueTbl = new Venue();

                    var existingType = (from x in db.Types where x.Id == t.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                    existingVenue.Types.Add(existingType);


                    db.SaveChanges();

                    var l = (from x in existingVenue.Types
                                         .Select(b => new TypeDTO
                                         {

                                             id = b.Id,
                                             typeText = b.Text


                                         })

                             select x).ToList();


                    return l;
                }





            }


        }


        [HttpPost]
        [Route("API/removeType")]
        [System.Web.Http.ActionName("removeType")]

        public List<TypeDTO> removeType(VenueDTO v)
        {

            TypeDTO t = new TypeDTO();

            t = v.types.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingType = (from x in db.Types where x.Id == t.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                existingVenue.Types.Remove(existingType);


                db.SaveChanges();

                var l = (from x in existingVenue.Types
                                     .Select(b => new TypeDTO
                                     {

                                         id = b.Id,
                                         typeText = b.Text


                                     })

                         select x).ToList();


                return l;


            }


        }

        //tag

        [HttpPost]
        [Route("API/addTag")]
        [System.Web.Http.ActionName("addTag")]

        public List<TagDTO> addTag(VenueDTO v)
        {

            TagDTO t = new TagDTO();

            t = v.tags.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                if (t.id == null)
                {

                    Models.Tag TagTbl = new Models.Tag();

                    TagDTO newTag = new TagDTO();

                    TagTbl = new Models.Tag
                    {

                        Text = t.tagText

                    };

                    db.Tags.Add(TagTbl);

                    db.SaveChanges();

                    newTag = t;
                    newTag.id = TagTbl.Id;

                    var existingTag = (from x in db.Tags where x.Id == newTag.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                    existingVenue.Tags.Add(existingTag);

                    db.SaveChanges();

                    var l = (from x in existingVenue.Tags
                                         .Select(b => new TagDTO
                                         {

                                             id = b.Id,
                                             tagText = b.Text


                                         })

                             select x).ToList();


                    return l;

                }
                else
                {
                    Venue VenueTbl = new Venue();

                    var existingTag = (from x in db.Tags where x.Id == t.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                    existingVenue.Tags.Add(existingTag);


                    db.SaveChanges();

                    var l = (from x in existingVenue.Tags
                                         .Select(b => new TagDTO
                                         {

                                             id = b.Id,
                                             tagText = b.Text


                                         })

                             select x).ToList();


                    return l;
                }





            }


        }


        [HttpPost]
        [Route("API/removeTag")]
        [System.Web.Http.ActionName("removeTag")]

        public List<TagDTO> removeTag(VenueDTO v)
        {

            TagDTO t = new TagDTO();

            t = v.tags.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingTag = (from x in db.Tags where x.Id == t.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                existingVenue.Tags.Remove(existingTag);


                db.SaveChanges();

                var l = (from x in existingVenue.Tags
                                     .Select(b => new TagDTO
                                     {

                                         id = b.Id,
                                         tagText = b.Text


                                     })

                         select x).ToList();


                return l;


            }


        }

        //time

        [HttpPost]
        [Route("API/addTime")]
        [System.Web.Http.ActionName("addTime")]

        public List<TimeDTO> addTime(VenueDTO v)
        {

            TimeDTO t = new TimeDTO();

            t = v.times.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                if (t.id == null)
                {

                    Models.Time TimeTbl = new Models.Time();

                    TimeDTO newTime = new TimeDTO();

                    TimeTbl = new Models.Time
                    {

                        Text = t.timeText

                    };

                    db.Times.Add(TimeTbl);

                    db.SaveChanges();

                    newTime = t;
                    newTime.id = TimeTbl.Id;

                    var existingTime = (from x in db.Times where x.Id == newTime.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                    existingVenue.Times.Add(existingTime);

                    db.SaveChanges();

                    var l = (from x in existingVenue.Times
                                         .Select(b => new TimeDTO
                                         {

                                             id = b.Id,
                                             timeText = b.Text


                                         })

                             select x).ToList();


                    return l;

                }
                else
                {
                    Venue VenueTbl = new Venue();

                    var existingTime = (from x in db.Times where x.Id == t.id select x).FirstOrDefault();


                    var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                    existingVenue.Times.Add(existingTime);


                    db.SaveChanges();

                    var l = (from x in existingVenue.Times
                                         .Select(b => new TimeDTO
                                         {

                                             id = b.Id,
                                             timeText = b.Text


                                         })

                             select x).ToList();


                    return l;
                }





            }


        }


        [HttpPost]
        [Route("API/removeTime")]
        [System.Web.Http.ActionName("removeTime")]

        public List<TimeDTO> removeTime(VenueDTO v)
        {

            TimeDTO t = new TimeDTO();

            t = v.times.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingTime = (from x in db.Times where x.Id == t.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();




                existingVenue.Times.Remove(existingTime);


                db.SaveChanges();

                var l = (from x in existingVenue.Times
                                     .Select(b => new TimeDTO
                                     {

                                         id = b.Id,
                                         timeText = b.Text


                                     })

                         select x).ToList();


                return l;


            }


        }

    }
}
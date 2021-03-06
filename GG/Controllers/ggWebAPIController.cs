﻿using System;
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
        [Route("API/carouselImages")]
        [System.Web.Http.ActionName("carouselImages")]

        public List<FeatureImageDTO> carouselImages()
        {

            List<FeatureImageDTO> response = new List<FeatureImageDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.FeatureImages
                         .Select(b => new FeatureImageDTO
                         {

                             id = b.Id, url = b.Url


                         })

                         select x).OrderBy(x => Guid.NewGuid()).Take(4).ToList();


                response = l;


            }

            return response;


        }

        [HttpGet]
        [Route("API/allFeaturedImages")]
        [System.Web.Http.ActionName("allFeaturedImageImages")]

        public List<FeatureImageDTO> allFeaturedImages()
        {

            List<FeatureImageDTO> response = new List<FeatureImageDTO>();

            using (var db = new GG.Models.GGModelContainer())
            {


                var l = (from x in db.FeatureImages
                         .Select(b => new FeatureImageDTO
                         {

                             id = b.Id,
                             url = b.Url


                         })

                         select x).OrderBy(x => x.id).ToList();


                response = l;


            }

            return response;


        }

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

                             //  hours = b.Hours,
                                name = b.Name,
                                 contact = b.Contact,
                                  email = b.Email,
                                   facebook = b.Facebook,
                                    instagram = b.Instagram,
                                     neighborhood = b.Neighborhood,
                                      parking = b.Parking,
                                       
                                       twitter = b.Twitter,
                                        zip = b.Zip,
                                        phone = b.Phone,
                                        notes = b.Notes,


                             prices = b.Prices.Select(m => new PriceDTO
                             {
                                id = m.Id,
                                 priceText = m.Text


                             }).ToList(),
                             hours = b.Hours.Select(m => new HourDTO
                             {
                                 id = m.Id,
                                 hourText = m.Text


                             }).OrderBy(g => g.id).ToList(),
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
                             website = b.Website,
                             images = b.Images.Select(m => new ImageDTO
                             {
                                 id = m.Id,
                                 url = m.url
                             }).ToList(),
                             videos = b.Videos.Select(m => new VideoDTO
                             {
                                 id = m.Id,
                                 url = m.url
                             }).ToList()



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
                                      //  hours = b.Hours,
                                        name = b.Name,
                                        state = b.State,
                                        website = b.Website,
                                         zip = b.Zip,
                                          twitter = b.Twitter,
                                           parking = b.Parking,
                                           phone = b.Phone,
                                           notes = b.Notes,
                                            neighborhood = b.Neighborhood,
                                             instagram = b.Instagram,
                                              contact = b.Contact,
                                               email = b.Email,
                                                facebook = b.Facebook
                                                ,
                                        images = b.Images.Select(m => new ImageDTO
                                        {
                                            id = m.Id,
                                            url = m.url
                                        }).ToList(),
                                        hours = b.Hours.Select(m => new HourDTO
                                        {
                                            id = m.Id, 
                                            hourText = m.Text
                                        }).ToList(),
                                        videos = b.Videos.Select(m => new VideoDTO
                                        {
                                            id = m.Id,
                                            url = m.url
                                        }).ToList()

                                    }).OrderBy(x => Guid.NewGuid())
                                    .Take(6).ToList();

                response = l;


   




            }

            return response;


        }


        [HttpPost]
        [Route("API/updateVenue")]
        [System.Web.Http.ActionName("updateVenue")]

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
                      //  Hours = v.hours,
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
                                Parking = v.parking,
                                Phone = v.phone,
                                Notes = v.notes
                                
                         

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
                   // existingVenue.Hours = v.hours;
                    existingVenue.Name = v.name;
                    existingVenue.State = v.state;
                    existingVenue.Website = v.website;
                    existingVenue.Email = v.email;
                    existingVenue.Zip = v.zip;
                    existingVenue.Twitter = v.twitter;
                    existingVenue.Parking = v.parking;
                    existingVenue.Phone = v.phone;
                    existingVenue.Notes = v.notes;
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
        [Route("API/addFeaturedImage")]
        [System.Web.Http.ActionName("addFeaturedImage")]

        public List<FeatureImageDTO> addFeaturedImage(FeatureImageDTO f)
        {

           
            using (var db = new GG.Models.GGModelContainer())
            {


                FeatureImage FeatureImageTbl = new FeatureImage();

                FeatureImageDTO newFeatureImage = new FeatureImageDTO();

                FeatureImageTbl = new FeatureImage
                {

                   Url=f.url

                };

                db.FeatureImages.Add(FeatureImageTbl);

                db.SaveChanges();

               

                var l = (from x in db.FeatureImages
                                     .Select(b => new FeatureImageDTO
                                     {

                                         id = b.Id,
                                         url = b.Url


                                     })

                         select x).ToList();


                return l;

            }


        }


        [HttpPost]
        [Route("API/removeFeatureImage")]
        [System.Web.Http.ActionName("removeFeatureImage")]

        public List<FeatureImageDTO> removeFeatureImage(FeatureImageDTO f)
        {

          



            using (var db = new GG.Models.GGModelContainer())
            {

              

                var existingFeatureImage = (from x in db.FeatureImages where x.Id == f.id select x).FirstOrDefault();


                db.FeatureImages.Remove(existingFeatureImage);

                

                db.SaveChanges();

                var l = (from x in db.FeatureImages
                                     .Select(b => new FeatureImageDTO
                                     {

                                         id = b.Id,
                                         url = b.Url


                                     })

                         select x).ToList();


                return l;


            }


        }

        [HttpPost]
        [Route("API/addImage")]
        [System.Web.Http.ActionName("addImage")]

        public List<ImageDTO> addImage(VenueDTO v)
        {

            ImageDTO i = new ImageDTO();

            i = v.images.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                Image ImageTbl = new Image();

                ImageDTO newImage = new ImageDTO();

               ImageTbl = new Image
                {

                    url = i.url,
                    VenueId = (int)v.id

                };

                db.Images.Add(ImageTbl);

                db.SaveChanges();

                newImage = i;
                newImage.id = ImageTbl.Id;

                var existingImage = (from x in db.Images where x.Id == newImage.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                existingVenue.Images.Add(existingImage);

                db.SaveChanges();

                var l = (from x in existingVenue.Images
                                     .Select(b => new ImageDTO
                                     {

                                         id = b.Id,
                                         url = b.url


                                     })

                         select x).ToList();


                return l;

            }


        }


        [HttpPost]
        [Route("API/removeImage")]
        [System.Web.Http.ActionName("removeImage")]

        public List<ImageDTO> removeImage(VenueDTO v)
        {

            ImageDTO i = new ImageDTO();

            i = v.images.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingImage = (from x in db.Images where x.Id == i.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();


                db.Images.Remove(existingImage);


                existingVenue.Images.Remove(existingImage);


                db.SaveChanges();

                var l = (from x in existingVenue.Images
                                     .Select(b => new ImageDTO
                                     {

                                         id = b.Id,
                                         url = b.url


                                     })

                         select x).ToList();


                return l;


            }


        }


        [HttpPost]
        [Route("API/addHour")]
        [System.Web.Http.ActionName("addHour")]

        public List<HourDTO> addHour(VenueDTO v)
        {

            HourDTO h = new HourDTO();

            h = v.hours.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                Hours HourTbl = new Hours();

                HourDTO newHour = new HourDTO();

                HourTbl = new Hours
                {

                 Text = h.hourText,
                    VenueId = (int)v.id

                };

                db.Hours.Add(HourTbl);

                db.SaveChanges();

                newHour = h;
                newHour.id = HourTbl.Id;

                var existingHour = (from x in db.Hours where x.Id == newHour.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                existingVenue.Hours.Add(existingHour);

                db.SaveChanges();

                var l = (from x in existingVenue.Hours
                                     .Select(b => new HourDTO
                                     {

                                         id = b.Id,
                                          hourText = b.Text



                                     })

                         select x).ToList();


                return l;

            }


        }


        [HttpPost]
        [Route("API/removeHour")]
        [System.Web.Http.ActionName("removeHour")]

        public List<HourDTO> removeHour(VenueDTO v)
        {

            HourDTO h = new HourDTO();

            h = v.hours.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingHour = (from x in db.Hours where x.Id == h.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();


                db.Hours.Remove(existingHour);


                existingVenue.Hours.Remove(existingHour);


                db.SaveChanges();

                var l = (from x in existingVenue.Hours
                                     .Select(b => new HourDTO
                                     {

                                         id = b.Id, 
                                          hourText = b.Text


                                     })

                         select x).ToList();


                return l;


            }


        }

        [HttpPost]
        [Route("API/addVideo")]
        [System.Web.Http.ActionName("addVideo")]

        public List<VideoDTO> addVideo(VenueDTO v)
        {

            VideoDTO i = new VideoDTO();

            i = v.videos.Last();



            using (var db = new GG.Models.GGModelContainer())
            {


                Video VideoTbl = new Video();

                VideoDTO newVideo = new VideoDTO();

                VideoTbl = new Video
                {
                    
                    url = i.url,
                    VenueId = (int)v.id

                };

                db.Videos.Add(VideoTbl);

                db.SaveChanges();

                newVideo = i;
                newVideo.id = VideoTbl.Id;

                var existingVideo = (from x in db.Videos where x.Id == newVideo.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();

                existingVenue.Videos.Add(existingVideo);

                db.SaveChanges();

                var l = (from x in existingVenue.Videos
                                     .Select(b => new VideoDTO
                                     {

                                         id = b.Id,
                                         url = b.url


                                     })

                         select x).ToList();


                return l;

            }


        }


        [HttpPost]
        [Route("API/removeVideo")]
        [System.Web.Http.ActionName("removeVideo")]

        public List<VideoDTO> removeVideo(VenueDTO v)
        {

            VideoDTO i = new VideoDTO();

            i = v.videos.Last();



            using (var db = new GG.Models.GGModelContainer())
            {

                Venue VenueTbl = new Venue();

                var existingVideo = (from x in db.Videos where x.Id == i.id select x).FirstOrDefault();


                var existingVenue = (from x in db.Venues where x.Id == v.id select x).FirstOrDefault();


                db.Videos.Remove(existingVideo);


                existingVenue.Videos.Remove(existingVideo);


                db.SaveChanges();

                var l = (from x in existingVenue.Videos
                                     .Select(b => new VideoDTO
                                     {

                                         id = b.Id,
                                         url = b.url


                                     })

                         select x).ToList();


                return l;


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
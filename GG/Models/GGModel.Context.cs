﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GG.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GGModelContainer : DbContext
    {
        public GGModelContainer()
            : base("name=GGModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Price> Prices1 { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Time> Times { get; set; }
        public virtual DbSet<Type> Types { get; set; }
    }
}

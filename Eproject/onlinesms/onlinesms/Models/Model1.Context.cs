﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace onlinesms.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineSMSEntities1 : DbContext
    {
        public OnlineSMSEntities1()
            : base("name=OnlineSMSEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<count> counts { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<personaldetail> personaldetails { get; set; }
        public virtual DbSet<professionaldetail> professionaldetails { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<freind> freinds { get; set; }
    }
}
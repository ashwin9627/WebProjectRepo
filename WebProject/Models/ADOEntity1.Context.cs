﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FirstDBEntities1 : DbContext
    {
        public FirstDBEntities1()
            : base("name=FirstDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<EntityTable1> EntityTable1 { get; set; }
        public virtual DbSet<LoginTable1> LoginTable1 { get; set; }
        public virtual DbSet<Table3> Table3 { get; set; }
    }
}
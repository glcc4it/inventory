﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Loop_Inventory
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Inventory_DBEntities : DbContext
    {
        public Inventory_DBEntities()
            : base("name=Inventory_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Tax> tbl_Tax { get; set; }
        public virtual DbSet<tbl_Currency> tbl_Currency { get; set; }
        public virtual DbSet<tblBonusQuantity> tblBonusQuantities { get; set; }
        public virtual DbSet<tbl_godown> tbl_godown { get; set; }
        public virtual DbSet<tblStore> tblStores { get; set; }
        public virtual DbSet<tblItemMaster> tblItemMasters { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<tbl_AccountMaster> tbl_AccountMaster { get; set; }
    }
}

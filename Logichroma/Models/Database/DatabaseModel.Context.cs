﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Logichroma.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LogichromaDbEntities : DbContext
    {
        public LogichromaDbEntities()
            : base("name=LogichromaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<CardState> CardStates { get; set; }
        public virtual DbSet<CardType> CardTypes { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<GameCard> GameCards { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GameStatus> GameStatuses { get; set; }
        public virtual DbSet<GameStatusType> GameStatusTypes { get; set; }
        public virtual DbSet<GamePlayer> GamePlayers { get; set; }
    }
}

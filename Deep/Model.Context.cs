﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Deep
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DeepEntities : DbContext
    {
        public DeepEntities()
            : base("name=DeepEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessToken> AccessTokens { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Variant> Variants { get; set; }
    }
}
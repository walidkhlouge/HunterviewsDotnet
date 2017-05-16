using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using MySQL.Data.EntityFrameworkCore.Extensions;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace WebApplication
{
    public class HunterViewContext : DbContext
    {
        public HunterViewContext(DbContextOptions<HunterViewContext> options)
        : base(options)
        { }
        public HunterViewContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Certification>().
        //   ToTable("Certification").Property(c => c.title).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Certification>().HasOne(p => p.user).WithMany(c => c.certifications);
            //modelBuilder.Entity<Evaluation>().HasOne(p => p.offer).WithMany(c => c.evaluations);
            modelBuilder.Entity<Formation>().HasOne(p => p.user).WithMany(p => p.formations);
           // modelBuilder.Entity<Notification>().HasOne(p => p.user).WithMany(p => p.notifications);
           // modelBuilder.Entity<Offer>().HasOne(p => p.user).WithMany(p => p.offers);
          //  modelBuilder.Entity<Post>().HasOne(p => p.user).WithMany(p => p.posts);
         //   modelBuilder.Entity<Post>().HasOne(p => p.offer).WithMany(p => p.posts);
        //    modelBuilder.Entity<Skill>().HasOne(p => p.user).WithMany(p => p.skills);
            //modelBuilder.Entity<JobSeeker>();
        //   modelBuilder.Entity<User>()
        //.HasDiscriminator<string>("Type")
        //.HasValue<JobSeeker>("Jobseeker")
        //.HasValue<HeadHunter>("Headhunter");


        }


        public DbSet<User> user { get; set; }
        public DbSet<Offer> offers { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Skill> skills { get; set; }
        public DbSet<Reclamation> reclamations { get; set; }
        public DbSet<Evaluation> evaluations { get; set; }
        public DbSet<Formation> formations { get; set; }
        public DbSet<Notification> notifications { get; set; }
        public DbSet<Certification> certifications { get; set; }
        public DbSet<Coordonates> coordinates { get; set; }
        //public DbSet<JobSeeker> jobseeker { get; set; }
        //public DbSet<HeadHunter> Headhunter { get; set; }


    }
}
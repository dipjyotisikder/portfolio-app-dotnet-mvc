﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using folio.Areas.Portfolio.Models;
using folio.Models.Email;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace folio.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PermanentAddress { get; set; }
        public string CurrentAddress { get; set; }

        public string ImageUrl { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFIle { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Pcategory> Pcategories { get; set; }
        public DbSet<EmailInfo> EmailInfos { get; set; }
        public DbSet<Pimage> Pimages { get; set; }
        public DbSet<Pskill> Pskills { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectImage> ProjectImages { get; set; }
        public DbSet<ProjectSkill> ProjectSkills { get; set; }
        public DbSet<ProjectFeature> ProjectFeatures { get; set; }




        public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<Project>()
        //            .HasMany(s => s.Pskills)
        //            .WithMany(c => c.Projects)
        //            .Map(cs =>
        //                    {
        //                        cs.MapLeftKey("ProjectId");
        //                        cs.MapRightKey("SkillId");
        //                        cs.ToTable("ProjectSkills");
        //                    });
        //    base.OnModelCreating(modelBuilder);
        //}




    }
}
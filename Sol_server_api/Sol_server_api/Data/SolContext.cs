using Microsoft.EntityFrameworkCore;
using Sol_server_api.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Sol_server_api.Data
{
    public class SolContext : DbContext
    {
        public SolContext(DbContextOptions<SolContext> options) : base(options)
        {

        }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Project>? Projects { get; set; }
        public DbSet<ProjectPackage>? ProjectPackages { get; set; }
        public DbSet<Component>? Components { get; set; }
        public DbSet<Compartment>? Compartments { get; set; }
        public DbSet<Process>? Processes { get; set; }

        public DbSet<Coworker>? Coworkers { get; set; }
        public DbSet<PersonalData>? PersonalDatas { get; set; }
        public DbSet<Permission>? Permissions { get; set; }
        public DbSet<Login>? Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Tábla átnevezések, hogy ne az osztályok nevén legyenek azonosítva
            modelBuilder.Entity<Customer>().ToTable("megrendelo");
            modelBuilder.Entity<Project>().ToTable("projekt");
            modelBuilder.Entity<ProjectPackage>().ToTable("projekt_csomag");
            modelBuilder.Entity<Component>().ToTable("alkatresz");
            modelBuilder.Entity<Compartment>().ToTable("rekesz");
            modelBuilder.Entity<Process>().ToTable("folyamat");

            modelBuilder.Entity<Coworker>().ToTable("munkatars_fo");
            modelBuilder.Entity<PersonalData>().ToTable("szemelyi_adat");
            modelBuilder.Entity<Permission>().ToTable("jogosultsag");
            modelBuilder.Entity<Login>().ToTable("login");

            //Entitások elsődleges kulcsának beállítása, ahol nem Id van a változónévben
            modelBuilder.Entity<Customer>().HasKey(e => e.CustomerID);
            modelBuilder.Entity<Project>().HasKey(e => e.ProjectID);
            modelBuilder.Entity<ProjectPackage>().HasKey(e => e.PackageID);
            modelBuilder.Entity<Component>().HasKey(e => e.ComponentID);
            modelBuilder.Entity<Compartment>().HasKey(e => e.CompartmentID);
            modelBuilder.Entity<Process>().HasKey(e => e.ProcessID);

            modelBuilder.Entity<Coworker>().HasKey(e => e.CoworkerID);
            modelBuilder.Entity<PersonalData>().HasKey(e => e.TelNumber);
            modelBuilder.Entity<Permission>().HasKey(e => e.PermissionID);
            modelBuilder.Entity<Login>().HasKey(e => e.LoginID);


            //Táblakapcsolatok
            //A - Projekt és Raktározás
            //A1. Customer-Project: egy projekthez egy megrendelő tartozik, egy megrendelőhöz több projekt is tartozhat, Foreign Key: ProjektCode          
            modelBuilder.Entity<Customer>()
                    .HasMany(e => e.Projects)                           // Egy ügyfélhez több projekt tartozhat
                    .WithOne()                                                 // Minden projektnek pontosan egy ügyfele van
                    .HasForeignKey(e => e.FKCustomerID);        // Projekt táblában a ProjectCode oszlop lesz a külső kulcs
                                                                                       // Minden projektnek egy ügyfele van
                                                                                      // Egy ügyfélhez csak egy projekt tartozik
                                                                                     // Customer táblában a CustomerId oszlop lesz a külső kulcs

            //A2. Egy projekthez egy projektcsomag tartozik, egy projektcsomaghoz egy projekt  tartozik a projektod a foreign key
            modelBuilder.Entity<Project>().HasOne(e => e.ProjectPackage).WithOne().HasForeignKey<ProjectPackage>(e => e.FKProjectID);

            //A3. Egy projektcsomaghoz több alkatrész tartozik, egy alkatrészhez egy projektcsomag
            modelBuilder.Entity<ProjectPackage>().HasMany(e => e.Components).WithOne().HasForeignKey(e => e.FKPackageID).OnDelete(DeleteBehavior.Cascade);

            //A4. Egy alkatrészhez egy rekesz tartozik, egy rekeszhez egy alkatresz tarozik foreign key RekeszAlkatrészNév 
            modelBuilder.Entity<Component>().HasOne(e => e.Compartment).WithOne().HasForeignKey<Compartment>(e => e.FKComponentID).OnDelete(DeleteBehavior.Cascade);

            //A5. Egy projekthez egy folyamat tábla tartozik és egy folyamat táblához egy projekt
            modelBuilder.Entity<Project>().HasOne(e => e.Process).WithOne().HasForeignKey<Process>(e => e.FKProjectID);


            //B - Munkatársak - Adatok és Admin táblák
            //Egy pojecthez több munkatárs tartozhat, egy munkatárshoz több project tartozhat ~~~many to many kapcsolatnál nem kell Foreign Key-t meghatározni az EF Core automatikusan kezeli~~~
            modelBuilder.Entity<Project>().HasMany(e => e.Coworkers).WithMany();

            //B2. - Egy munkatarshoz egy szemelyes_adat tartozik, egy munkatars adathoz egy munkatars_fo tartozik, FK MunkatarsTel
            modelBuilder.Entity<Coworker>().HasOne(e => e.PersonalData).WithOne().HasForeignKey<PersonalData>(e => e.TelNumber).HasPrincipalKey<Coworker>(e => e.PLKTelNumber);

            //B3. - Egy munkatarshoz egy jogosultság tartozik. egy jogosultsághoz egy munkatars_fo tartozik, FK munkatarsPozicio
            modelBuilder.Entity<Coworker>().HasOne(e => e.Permission).WithOne().HasForeignKey<Permission>(e => e.FKCoworkerID);

            //B4. Egy munkatarshoz egy  login tartozik, egy loginhoz egy munkatars_fotabla tartozik
            modelBuilder.Entity<Coworker>().HasOne(e => e.Login).WithOne().HasForeignKey<Login>(e => e.LoginID).HasPrincipalKey<Coworker>(e => e.PLKLoginID);
        }
    }
}

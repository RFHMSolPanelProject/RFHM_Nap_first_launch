using Microsoft.EntityFrameworkCore;
using static RHM_Napv02_projekt_server.Models.SqlTable;

namespace RHM_Napv02_projekt_server.Models
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
           
        public DbSet<CoworkerMain>? CoworkerMains { get; set; }
        public DbSet<CoworkerData>? CoworkerDatas { get; set; }
        public DbSet<CoworkerPermission>? CoworkerPermissions { get; set; }
        public DbSet<CoworkerLogin>? CoworkerLogins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Tábla átnevezések, hogy ne az osztályok nevén legyenek azonosítva
        modelBuilder.Entity<Customer>().ToTable("megrendelo");
        modelBuilder.Entity<Project>().ToTable("projekt");
        modelBuilder.Entity<ProjectPackage>().ToTable("projekt_csomag");
        modelBuilder.Entity<Component>().ToTable("alkatresz");
        modelBuilder.Entity<Compartment>().ToTable("rekesz");    
        modelBuilder.Entity<Process>().ToTable("folyamat");

        modelBuilder.Entity<CoworkerMain>().ToTable("munkatars_fo");
        modelBuilder.Entity<CoworkerData>().ToTable("munkatars_adat");
        modelBuilder.Entity<CoworkerPermission>().ToTable("munkatars_jogosultsag");
        modelBuilder.Entity<CoworkerLogin>().ToTable("munkatars_login");

    //Entitások elsődleges kulcsának beállítása, ahol nem Id van a változónévben
        modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
        modelBuilder.Entity<Project>().HasKey(p => p.ProjectID);
        modelBuilder.Entity<ProjectPackage>().HasKey(pp => pp.ProjectPackageID);
        modelBuilder.Entity<Component>().HasKey(comp => comp.ComponentName);
        modelBuilder.Entity<Compartment>().HasKey(b => b.CompartmentNr);
        modelBuilder.Entity<Process>().HasKey(proc => proc.ProcessID);
                 
        modelBuilder.Entity<CoworkerMain>().HasKey(cm => cm.CoworkerId);
        modelBuilder.Entity<CoworkerData>().HasKey(cd => cd.CoworkerTel);
        modelBuilder.Entity<CoworkerPermission>().HasKey(cp => cp.CoworkerPermissionName);
        modelBuilder.Entity<CoworkerLogin>().HasKey(cl => cl.CoworkerLoginID);

            
          //Táblakapcsolatok
         //A - Projekt és Raktározás
        //A1. Customer-Project: egy projekthez egy megrendelő tartozik, egy megrendelőhöz több projekt is tartozhat, Foreign Key: ProjektCode          
        modelBuilder.Entity<Customer>()
                .HasMany(cus => cus.Projects)                            // Egy ügyfélhez több projekt tartozhat
                .WithOne(p => p.CustomerNav)                         // Minden projektnek pontosan egy ügyfele van
                .HasForeignKey(p => p.ProjectCustomerID);    // Projekt táblában a ProjectCode oszlop lesz a külső kulcs
                                                                                           // Minden projektnek egy ügyfele van
                                                                                          // Egy ügyfélhez csak egy projekt tartozik
                                                                                         // Customer táblában a CustomerId oszlop lesz a külső kulcs

        //A2. Egy projekthez egy projektcsomag tartozik, egy projektcsomaghoz egy projekt  tartozik a projektod a foreign key
        modelBuilder.Entity<Project>().HasOne(p => p.ProjectPackageNav).WithOne(pp => pp.ProjectPackageProjectNav).HasForeignKey<ProjectPackage>(pp => pp.ProjectPackageID);

        //A3. Egy projektcsomaghoz több alkatrész tartozik, egy alkatrészhez egy projektcsomag
        modelBuilder.Entity<ProjectPackage>().HasMany(pp => pp.Components).WithOne(c => c.ComponentProjectPNav).HasForeignKey(c => c.ProjectPackageComponentID);

        //A4. Egy alkatrészhez egy rekesz tartozik, egy rekeszhez egy alkatresz tarozik foreign key RekeszAlkatrészNév 
        modelBuilder.Entity<Component>().HasOne(component => component.CompartmentNav).WithOne(component => component.ComponentNav).HasForeignKey<Compartment>(compartment => compartment.CompartmentComponentID);

        //A5. Egy projekthez egy folyamat tábla tartozik és egy folyamat táblához egy projekt
        modelBuilder.Entity<Project>().HasOne(p => p.ProcessNav).WithOne(proc => proc.ProcessProjectNav).HasForeignKey<Process>(proc => proc.ProcessName);


        //B - Munkatársak - Adatok és Admin táblák
        //Egy pojecthez több munkatárs tartozhat, egy munkatárshoz több project tartozhat ~~~many to many kapcsolatnál nem kell Foreign Key-t meghatározni az EF Core automatikusan kezeli~~~
        modelBuilder.Entity<Project>().HasMany(p => p.CoworkerMains).WithMany(cm => cm.Projects);
        
        //B2. - Egy munkatars_főhöz egy munkatars_adat tartozik, egy munkatars adathoz egy munkatars_fo tartozik, FK MunkatarsTel
        modelBuilder.Entity<CoworkerMain>().HasOne(cm => cm.CoworkerDataNav).WithOne(cd => cd.CoworkerDataCoworkerMainNav).HasForeignKey<CoworkerMain>(cm => cm.CoworkerTel);

        //B3. - Egy munkatars_főhöz egy jogosultság tartozik. egy jogosultsághoz egy munkatars_fo tartozik, FK munkatarsPozicio
        modelBuilder.Entity<CoworkerMain>().HasOne(cm => cm.CoworkerPermissionNav).WithOne(cp => cp.CoworkerMainNav).HasForeignKey<CoworkerMain>(cw => cw.CoworkerPosition);

        //B4. Egy munkatars_főhoz egy munkatars_login tartozik, egy munkatars_loginhoz egy munkatars_fotabla tartozik
        modelBuilder.Entity<CoworkerLogin>().HasOne(cl => cl.CoworkerLoginCoworkerMainNav).WithOne(cm => cm.CoworkerLoginNav).HasForeignKey<CoworkerMain>(cm => cm.CoworkerLoginID);
        }
    }
}

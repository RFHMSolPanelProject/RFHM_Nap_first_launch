using System.Diagnostics;

namespace RHM_Napv02_projekt_server.Models
{
    public class SqlTable
    {
        public class Customer
        {
            public string CustomerID { get; set; } = string.Empty;
            public string CustomerName { get; set; } = string.Empty;
            public string CustomerEmail { get; set; } = string.Empty;
          
            public ICollection<Project>? Projects { get; set; }
        }



        public class Project
        {
            public string ProjectID { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public string Desc { get; set; } = string.Empty;
            public string Status { get; set; } = string.Empty;
            public string ProjectCustomerID = string.Empty ;    

            public Customer CustomerNav { get; set; }
            public ProjectPackage ProjectPackageNav { get; set; }
            public Process ProcessNav { get; set; }
            public ICollection<CoworkerMain>? CoworkerMains { get; set; }
            
            public Project()
            {
                ProjectPackageNav = new ProjectPackage(); //ProjectPackage kaphat NULL értéket, amíg az alkatrészbegyűjtés történik
                CustomerNav = new Customer();
                ProjectPackageNav = new ProjectPackage();
                ProcessNav = new Process();
            }
        }


        public class ProjectPackage
        {
            public string ProjectPackageID { get; set; } = string.Empty;
            public int PackageComponentName { get; set; } = 0;
            public int RequiredPiece { get; set; } = 0;
            public string PackageProjectID { get; set; } = string.Empty; //FK

            public Project ProjectPackageProjectNav { get; set; }
            public List<Component>? Components { get; set; }

            public ProjectPackage()
            {
                ProjectPackageProjectNav = new Project();
            }
        }


        public class Component
        {
            public string ComponentID { get; set; } = string.Empty;
            public string ComponentName { get; set; } = string.Empty;   
            public int MaxPiece{ get; set; } = 0;
            public int Piece { get; set; } = 0;
            public int Price { get; set; } = 0;
            public string ProjectPackageComponentID { get; set; } = string.Empty;

            public ProjectPackage ComponentProjectPNav { get; set; }
            public Compartment CompartmentNav { get; set; }

            public Component()
            {
                ComponentProjectPNav = new ProjectPackage();
                CompartmentNav = new Compartment();
            }
        }


        public class Compartment
        {
            public int CompartmentNr { get; set; } = 0;
            public int Row { get; set; } = 0;
            public int Col { get; set; } = 0;
            public int Bracket { get; set; } = 0;
            public string ComponentName { get; set; } = string.Empty;
            public float StoragedPiece { get; set; } = 0;
            public string CompartmentComponentID { get; set; } = string.Empty;

            public Component ComponentNav { get; set; }

            public Compartment()
            {
                ComponentNav = new Component();
            }
        }

       
        public class Process
        {  
            public int ProcessID { get; set; }
            public string ProcessName { get; set; } = string.Empty;
            public string Desc { get; set; } = string.Empty;
     
            public Project ProcessProjectNav { get; set; }

            public Process()
            {
                ProcessProjectNav = new Project();
            }
        }

        #region B

        public class CoworkerMain
        {
            public string CoworkerId { get; set; } = string.Empty;
            public string CoworkerName { get; set; } = string.Empty ;
            public string CoworkerPosition { get; set; } = string.Empty;
            public string CoworkerTel { get; set; } = string.Empty;
            public string ProjectCoworkerID { get; set; } = string.Empty;
            public string CoworkerLoginID { get; set; } = string.Empty;
           
            public CoworkerData CoworkerDataNav { get; set; }
            public CoworkerPermission CoworkerPermissionNav { get; set; }
            public CoworkerLogin CoworkerLoginNav { get; set; }
            public ICollection<Project> Projects { get; set; }

            public CoworkerMain()
            {
                CoworkerDataNav = new CoworkerData();
                CoworkerPermissionNav = new CoworkerPermission();  
                CoworkerLoginNav = new CoworkerLogin();
                Projects = new List<Project>();
            }
        }

      
        public class CoworkerData
        {
            public string CoworkerTel { get; set; } = string.Empty;
            public string CoworkerEmail { get; set; } = string.Empty;
            public string CoworkerAddress { get; set; } = string.Empty;

            public CoworkerMain CoworkerDataCoworkerMainNav { get; set; }

            public CoworkerData()
            {
                CoworkerDataCoworkerMainNav = new CoworkerMain();
            }
        }

        public class CoworkerPermission
        {
            public string CoworkerPermissionName { get; set; } = string.Empty;
            public string PermissionDesc { get; set; } = string.Empty;

            public CoworkerMain CoworkerMainNav { get; set; }

            public CoworkerPermission()
            {
                CoworkerMainNav = new CoworkerMain();
            }
        }


        public class CoworkerLogin
        {
            public string CoworkerLoginID { get; set; } = string.Empty;
            public string LoginName { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;

            public CoworkerMain CoworkerLoginCoworkerMainNav { get; set; }

            public CoworkerLogin()
            {
                CoworkerLoginCoworkerMainNav = new CoworkerMain();
            }
        }

        #endregion B
    }
}







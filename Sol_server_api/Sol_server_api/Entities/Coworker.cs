namespace Sol_server_api.Entities
{
    public class Coworker
    {
        public string CoworkerID { get; set; } = string.Empty;
        public string CoworkerName { get; set; } = string.Empty;
        
        public string PLKPermission { get; set; } = string.Empty; //FK
        public virtual Permission Permission { get; set; } 

        public string PLKTelNumber { get; set; } = string.Empty;     //FK 
        public virtual PersonalData PersonalData { get; set; } 

        //public ICollection<Project>? Projects { get; set; }

        public string PLKLoginID { get; set; } = string.Empty; //FK
        public virtual Login Login { get; set; }    
    }
}

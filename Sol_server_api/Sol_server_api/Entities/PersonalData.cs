namespace Sol_server_api.Entities
{
    public class PersonalData
    {
        public string TelNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty ;
        public string Address { get; set; } = string.Empty;

        //public string CoworkerID { get; set; } = string.Empty;
        //public virtual Coworker? Coworker { get; set; } 
    }
}

namespace Sol_server_api.Entities
{
    public class Process
    {
        public string ProcessID { get; set; } = string.Empty;  
        public string Desc { get; set; } = string.Empty;
        
        public string ProcessName { get; set; } = string.Empty;//FK
        public string FKProjectID { get; set; } = string.Empty ;
        //public virtual Project? Project { get; set; }         
    }
}

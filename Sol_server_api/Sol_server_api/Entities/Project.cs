using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Sol_server_api.Entities
{
   

    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ProjectID { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime projectDate { get; set; }
        public string? Desc { get; set; }
        public string ProcessStatus { get; set; } = string.Empty; //PLK
        
        public string FKCustomerID { get; set; } = string.Empty; //FK
       
        //public virtual Customer? Customer { get; set; }     
       
        public virtual ProjectPackage ProjectPackage { get; set; } 
        public virtual Process Process { get; set; }   
        
        public virtual ICollection<Coworker>? Coworkers { get; set; }


    }
}

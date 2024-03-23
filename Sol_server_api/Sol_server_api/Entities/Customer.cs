using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sol_server_api.Entities;

#region Customer
public partial class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string CustomerID { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;

        public ICollection<Project> Projects { get; set; }
    }
#endregion 

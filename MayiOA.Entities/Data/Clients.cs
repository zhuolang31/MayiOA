//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MayiOA.Entities.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public Clients()
        {
            this.Groups = new HashSet<Groups>();
            this.Users = new HashSet<Users>();
        }
    
        public int ClientID { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string ClientType { get; set; }
        public Nullable<int> ConfigID { get; set; }
    
        public virtual ICollection<Groups> Groups { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReceivedDetail : EntityValidator
    {
        public string ID { get; set; }
        public string ReceivedID { get; set; }
        public string ProductID { get; set; }
        public Nullable<int> Quantity { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Received Received { get; set; }
    }
}

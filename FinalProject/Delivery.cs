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
    
    public partial class Delivery : EntityValidator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Delivery()
        {
            this.Bills = new HashSet<Bill>();
            this.DeliveryDetails = new HashSet<DeliveryDetail>();
        }
    
        public string ID { get; set; }
        public string EmployeeID { get; set; }
        public string AngencyID { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
    
        public virtual Agency Agency { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrviTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class DOBAVITELJ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOBAVITELJ()
        {
            this.PRODUKT = new HashSet<PRODUKT>();
        }
    
        public int D_KODA { get; set; }
        public string D_IME { get; set; }
        public string D_KONTAKT { get; set; }
        public string D_PODROČJE { get; set; }
        public string D_TELEFON { get; set; }
        public string D_DRŽAVA { get; set; }
        public string D_NAROČILO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUKT> PRODUKT { get; set; }
    }
}

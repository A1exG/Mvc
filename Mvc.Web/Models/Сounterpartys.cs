//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mvc.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сounterpartys
    {
        public Сounterpartys()
        {
            this.Sales = new HashSet<Sales>();
        }
    
        public int СounterpartyId { get; set; }
        public string СounterpartyName { get; set; }
    
        public virtual ICollection<Sales> Sales { get; set; }
    }
}

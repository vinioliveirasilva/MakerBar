//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Item()
        {
            this.ItensFabricacao = new HashSet<ItensFabricacao>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Qualidade { get; set; }
        public int Resistencia { get; set; }
        public string Arquivo { get; set; }
        public int Quantidade { get; set; }
        public int IdPedido { get; set; }
    
        public virtual Pedido Pedido { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItensFabricacao> ItensFabricacao { get; set; }
    }
}

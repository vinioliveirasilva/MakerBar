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
    
    public partial class Estoque
    {
        public int Id { get; set; }
        public int IdFabricacao { get; set; }
        public int IdPedido { get; set; }
    
        public virtual Fabricacao Fabricacao { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}

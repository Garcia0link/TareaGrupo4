//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LIBRERIAS
    {
        public int ID { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public Nullable<int> ID_LIBRO { get; set; }
    
        public virtual LIBRO2 LIBRO2 { get; set; }
        public virtual USUARIO2 USUARIO2 { get; set; }
    }
}

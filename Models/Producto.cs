using System; 

namespace Proyecto_P.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public string Proveedor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CantidadCajas { get; set; }
        public decimal PrecioPorCajas { get; set; }
        public decimal PrecioTotal { get; set; }
        public int CantidadProductosPorCajas { get; set; }
        public int CantidadProductosTotal { get; set; }
        public decimal PrecioPorProducto { get; set; }

        public Producto(){
            FechaRegistro = DateTime.Now;
        }

    }
}
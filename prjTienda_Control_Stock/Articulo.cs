using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjTienda_Control_Stock
{
    public class Articulo
    {
        public long id { get; set; }   
        public string nombre { get; set; }
        public string descripcion {  get; set; }
        public double precio {  get; set; }
        public int cantidad {  get; set; }
        public string categoria { get; set; }

    }
}

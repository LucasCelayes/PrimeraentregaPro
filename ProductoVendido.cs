using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
  public class ProductoVendido

        {
            private int id;

            private double stock;

            private int idProducto;

            private int idVenta;


            public ProductoVendido() { }

            public ProductoVendido(double stock, int idProducto, int idVenta)

            {
                this.stock = stock;

                this.idProducto = idProducto;

                this.idVenta = idVenta;


            }

            public ProductoVendido(int id, double stock, int idProducto, int idVenta) : this(stock, idProducto, idVenta)

            {

                this.id = id;



            }

            public int Id { get => id; set => id = value; }

            public double Stock { get => stock; set => stock = value; }

            public int IdProducto { get => idProducto; set => idProducto = value; }

            public int IdVenta { get => idVenta; set => idVenta = value; }



            public override string ToString()

            {

                return $"Id = {this.id} - Stock = {this.stock} - IdProducto = {this.idProducto} - Id Venta = {this.idVenta}";

            }

        }
    }


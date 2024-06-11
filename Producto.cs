namespace SistemaGestionEntities
{
    public class Producto
    {
        private int id;

        private string descripciones;

        private int costo;

        private int precioVenta;

        private double stock;

        private int idUsuario;

        public Producto() { }

        public Producto(string descripciones, int costo, int precioVenta, double stock, int IdUsuario)
        {
            this.descripciones = descripciones;

            this.costo = costo;

            this.precioVenta = precioVenta;

            this.stock = stock;

            this.idUsuario = IdUsuario;


        }
        public Producto(int id, string descripciones, int costo, int precioVenta, double stock, int idUsuario) : this(descripciones, costo, precioVenta, stock, idUsuario)
        {

            this.id = id;
        }
        public int Id { get => id; set => id = value; }

        public string Descripciones { get => descripciones; set => descripciones = value; }

        public int Costo { get => costo; set => costo = value; }

        public int PrecioVenta { get => precioVenta; set => precioVenta = value; }

        public double Stock { get => stock; set => stock = value; }

        public int IdUsuario { get => IdUsuario; set => IdUsuario = value; }

        public override string ToString()

        {

            return $"Id = {this.id} - Descripciones = {this.descripciones} - Costo = {this.costo} - Precio de venta = {this.precioVenta}  - Stock = {this.stock} - Id Usuario = {this.idUsuario}";

        }

    }
}



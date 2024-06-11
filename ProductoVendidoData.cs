using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
        public static class ProductoVendidoData
    
        { 
     
        public static bool DeleteProductoVendido(int Id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM ProductoVendido WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", Id);

                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool CreateProductoVendido(ProductoVendido productovendido)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO ProductoVendido(stock,idProducto,IdVenta values(@stock, @idProducto, @idVenta)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("stock", productovendido.Stock);
                command.Parameters.AddWithValue("idProducto", productovendido.IdProducto);
                command.Parameters.AddWithValue("idVenta", productovendido.IdVenta);


                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }
        public static ProductoVendido GetUserById(int id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM ProductoVendido WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    double stock = Convert.ToDouble(reader["stock"]);
                    int idProducto = Convert.ToInt32(reader["idProducto"]);
                    int idVenta = Convert.ToInt32(reader["idProducto"]);


                    ProductoVendido productoVendido = new ProductoVendido(Id, stock, idProducto, idVenta);
                    return productoVendido;
                }
            }
            throw new Exception("no se encontro Producto Vendido");
        }

        public static bool UpdateProductoVendido(int id, ProductoVendido productoVendido)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE ProductoVendido SET stock = @stock, idProducto = @idProducto,idVenta = @idVenta WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("stock", productoVendido.Stock);
                command.Parameters.AddWithValue("idProducto", productoVendido.IdProducto);
                command.Parameters.AddWithValue("IdVenta", productoVendido.IdVenta);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
        }
        public static List<ProductoVendido> ListaProductoVendidos()
        {
            List<ProductoVendido> listaProductosVendidos = new List<ProductoVendido>();
            string query = "SELECT * FROM ProductoVendido";
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ProductoVendido productoVendido = new ProductoVendido();
                            productoVendido.Id = Convert.ToInt32(dataReader["Id"]);
                            productoVendido.Stock = Convert.ToDouble(dataReader["Stock"]);
                            productoVendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                            productoVendido.IdVenta = Convert.ToInt32(dataReader["IdVentas"]);


                            listaProductosVendidos.Add(productoVendido);
                        }
                    }
                }
            }
            return listaProductosVendidos;
        }
    }
}

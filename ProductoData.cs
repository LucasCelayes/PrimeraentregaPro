using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{
    
    public static class ProductoData
    { 
        public static bool DeleteProduct(int Id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Producto WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", Id);
                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool CreateProduct(Producto Producto)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario) values(@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Descripciones", Producto.Descripciones);
                command.Parameters.AddWithValue("Costo", Producto.Costo);
                command.Parameters.AddWithValue("PrecioVenta", Producto.PrecioVenta);
                command.Parameters.AddWithValue("Stock", Producto.Stock);
                command.Parameters.AddWithValue("IdUsuario", Producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }


        }
        public static Producto GetUserById(int id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Producto WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["id"]);
                    string descripciones = reader["descripciones"].ToString();
                    int costo = Convert.ToInt32(reader["costo"]);
                    int precioVenta = Convert.ToInt32(reader["precioVenta"]);
                    double stock = Convert.ToDouble(reader["stock"]);
                    int idUsuario = Convert.ToInt32(reader["IdUsuario"]);

                    Producto producto = new Producto(Id, descripciones, costo, precioVenta, stock, idUsuario);

                    return producto;
                }
                throw new Exception("Id no encontrado");
            }

        }

        public static bool UpdateProduct(int id, Producto producto)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Producto SET Descripciones = @descripciones,  = @Costo,costo = @Precioventa, precioVenta = @Stock,stock = ,@IdUsuario, idUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("Descripciones", producto.Descripciones);
                command.Parameters.AddWithValue("Costo", producto.Costo);
                command.Parameters.AddWithValue("PrecioVenta", producto.PrecioVenta);
                command.Parameters.AddWithValue("Stock", producto.Stock);
                command.Parameters.AddWithValue("IdUsuario", producto.IdUsuario);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
        }


        public static List<Producto> ListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            string query = "SELECT * FROM Producto";
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Producto producto = new Producto();

                            producto.Id = Convert.ToInt32(dataReader["Id"]);
                            producto.Descripciones = dataReader["Descripiones"].ToString();
                            producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                            producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                            producto.Stock = Convert.ToDouble(dataReader["Stock"]);
                            producto.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);
                            listaProductos.Add(producto);
                        }
                    }
                }
            }
            return listaProductos;
        }
    }
}
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{    
    public static class VentaData
    { 
       
        public static bool DeleteVenta(int Id)
        {
        using (SqlConnection connection = DatabaseConnection.GetConnection())
        {
                string query = "DELETE FROM Venta WHERE ID = @id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", Id);

                return command.ExecuteNonQuery() > 0;
            }
        }
        public static bool CreateVenta(Venta venta)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Venta(comentarios,idUsuario) values(@comentarios, @idUsuario)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }

        }
        public static Venta GetVentaById(int id)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Venta WHERE id = @id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader[0]);
                    string comentarios = reader.GetString(1);
                    int idUsuario = Convert.ToInt32(reader[2]);


                    Venta venta = new Venta(Id, comentarios, idUsuario);
                    return venta;
                }
            }
            throw new Exception("no se encontro la venta");
        }

        public static bool UpdateVenta(int id, Venta venta)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Venta SET comentarios = @comentarios, idUsuario = @idUsuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idUsuario", venta.IdUsuario);
                command.Parameters.AddWithValue("id", id);

                connection.Open();
                return command.ExecuteNonQuery() > 0;

            }
        }
        public static List<Venta> ListaVentas()
        {
            List<Venta> listaVentas = new List<Venta>();
            string query = "SELECT * FROM Venta";
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Venta venta = new Venta();
                            venta.Id = Convert.ToInt32(dataReader["Id"]);
                            venta.Comentarios = dataReader["Comentarios"].ToString();
                            venta.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);


                            listaVentas.Add(venta);
                        }
                    }
                }
            }
            return listaVentas;
        }
    }
}
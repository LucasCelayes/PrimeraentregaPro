using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaLogistica;Trusted_Connection=true;";
    
        public static SqlConnection GetConnection() {
            return new SqlConnection(connectionString); 
        }
    }
}

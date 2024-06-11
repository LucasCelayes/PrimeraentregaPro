using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{

    public class Venta

    {
        private int id;

        private string comentarios;

        private int idUsuario;

        public Venta() { }

        public Venta(string comentarios, int idUsuario)

        {
            this.comentarios = comentarios;

            this.idUsuario = idUsuario;
        }

        public Venta(int id, string comentarios, int idUsuario) : this(comentarios, idUsuario)
        {

            this.id = id;



        }
        public int Id { get => id; set => id = value; }

        public string Comentarios { get => comentarios; set => comentarios = value; }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }

        public override string ToString()

        {

            return $"Id = {this.id} - Comentarios = {this.comentarios} - IdUsuario = {this.idUsuario}";

        }

    }
}
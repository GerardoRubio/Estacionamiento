using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamiento
{
    class ClaseAuto : IComparable<ClaseAuto>, IEquatable<ClaseAuto>
    {
        private string placas;
        private string nombre;
        private DateTime hora;
        public string Placas { get => placas; set => placas = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime Hora { get => hora; set => hora = value; }

        public ClaseAuto()
        {
            placas = "";
            nombre = "";
        }
        public int CompareTo(ClaseAuto x)
        {
            return this.Placas.ToString().CompareTo(x.Placas.ToString());
        }
        public bool Equals(ClaseAuto x)
        {
            return this.Placas == x.Placas;
        }


    }
}

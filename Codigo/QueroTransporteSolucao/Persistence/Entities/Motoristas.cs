using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Motoristas
    {
        public Motoristas()
        {
            Abastecimento = new HashSet<Abastecimento>();
            RegistroSaidas = new HashSet<RegistroSaidas>();
            Vistorias = new HashSet<Vistorias>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }
        public DateTime Validade { get; set; }
        public string Cnh { get; set; }
        public int IdUsuario { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Abastecimento> Abastecimento { get; set; }
        public ICollection<RegistroSaidas> RegistroSaidas { get; set; }
        public ICollection<Vistorias> Vistorias { get; set; }
    }
}

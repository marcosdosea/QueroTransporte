using System;
using System.Collections.Generic;

namespace Persistence
{
    public partial class Usuario
    {
        public Usuario()
        {
            Credito = new HashSet<Credito>();
            Motorista = new HashSet<Motorista>();
            Solicitacao = new HashSet<Solicitacao>();
            Transacao = new HashSet<Transacao>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Credito> Credito { get; set; }
        public virtual ICollection<Motorista> Motorista { get; set; }
        public virtual ICollection<Solicitacao> Solicitacao { get; set; }
        public virtual ICollection<Transacao> Transacao { get; set; }
    }
}

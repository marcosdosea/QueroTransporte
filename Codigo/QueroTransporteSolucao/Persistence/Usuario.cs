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

        public ICollection<Credito> Credito { get; set; }
        public ICollection<Motorista> Motorista { get; set; }
        public ICollection<Solicitacao> Solicitacao { get; set; }
        public ICollection<Transacao> Transacao { get; set; }
    }
}

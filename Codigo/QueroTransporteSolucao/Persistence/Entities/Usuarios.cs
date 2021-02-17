using System.Collections.Generic;

namespace Data.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Credito = new HashSet<Credito>();
            Motoristas = new HashSet<Motoristas>();
            Solicitacao = new HashSet<Solicitacao>();
            SolicitacoesManutencao = new HashSet<SolicitacoesManutencao>();
            Transacao = new HashSet<Transacao>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }
        public int UnidadesIdUnidades { get; set; }
        public string NumeroMatricula { get; set; }

        public Unidades UnidadesIdUnidadesNavigation { get; set; }
        public ICollection<Credito> Credito { get; set; }
        public ICollection<Motoristas> Motoristas { get; set; }
        public ICollection<Solicitacao> Solicitacao { get; set; }
        public ICollection<SolicitacoesManutencao> SolicitacoesManutencao { get; set; }
        public ICollection<Transacao> Transacao { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace QueroTransporte.Model
{
    public class UsuarioModel
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(11), MinLength(11)]
        public string Cpf { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public int Tipo { get; set; }
        // 0 = ADM, 1 = Cliente, 2 = Motorista, 3 = Gestor
    }
}
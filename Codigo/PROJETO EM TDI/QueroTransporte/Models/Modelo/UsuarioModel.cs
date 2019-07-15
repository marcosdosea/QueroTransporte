
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Usuario {

        public Usuario() {
        }

        private int IdUsuario;

        private string Cpf;

        private string Nome;

        private string Senha;

        private string Email;

        private string Telefone;

        private string Tipo;





        /// <summary>
        /// @return
        /// </summary>
        public int getIdUsuario() {
            // TODO implement here
            return this.IdUsuario;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdUsuario(int value) {
            this.IdUsuario = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getCpf() {
            // TODO implement here
            return this.Cpf;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setCpf(string value) {
            this.Cpf = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getNome() {
            // TODO implement here
            return this.Nome;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setNome(string value) {
            this.Nome = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getSenha() {
            // TODO implement here
            return this.Senha;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setSenha(string value) {
            this.Senha = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getEmail() {
            // TODO implement here
            return this.Email;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setEmail(string value) {
            this.Email = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getTelefone() {
            // TODO implement here
            return this.Telefone;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setTelefone(string value) {
            this.Telefone = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getTipo() {
            // TODO implement here
            return this.Tipo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setTipo(string value) {
            this.Tipo = value;
        }

    }
}
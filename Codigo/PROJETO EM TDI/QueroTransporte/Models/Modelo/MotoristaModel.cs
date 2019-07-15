
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Motorista {

        public Motorista() {
        }

        private int IdMotorista;

        private string Categoria;

        private string Validade;

        private string Cnh;

        private int Usuario;


        /// <summary>
        /// @return
        /// </summary>
        public int getIdMotorista() {
            // TODO implement here
            return this.IdMotorista;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdMotorista(int value) {
            this.IdMotorista = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getCategoria() {
            return this.Categoria;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setCategoria(string value) {
            this.Categoria = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getValidade() {
            return this.Validade;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setValidade(string value) {
            this.Validade = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getCnh() {
            return this.Cnh;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setCnh(string value) {
            this.Cnh = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public int getUsuario() {
            return this.Usuario;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setUsuario(int value) {
            this.Usuario = value;
        }

    }
}
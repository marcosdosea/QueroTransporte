
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Transacao {

        public Transacao() {
        }

        private int IdTransacao;

        private double QtdCreditos;

        private bool Deferido;

        private string Data;

        private int Usuario;

        private string Status;


        /// <summary>
        /// @return
        /// </summary>
        public int getIdTransacao() {
            return IdTransacao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdTransacao(int value) {
            this.IdTransacao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double getQtdCreditos() {
            return this.QtdCreditos;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setQtdCreditos(double value) {
            this.QtdCreditos = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public bool getDeferido() {
            return this.Deferido;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDeferido(bool value) {
            this.Deferido = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getData() {
            return this.Data;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setData(string value) {
            this.Data = value;
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

        /// <summary>
        /// @return
        /// </summary>
        public string getStatus() {
            return this.Status;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setStatus(string value) {
            this.Status = value;
        }

    }
}
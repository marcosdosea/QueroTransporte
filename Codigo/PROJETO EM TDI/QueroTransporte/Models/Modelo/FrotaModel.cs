
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Frota {

        public Frota() {
        }

        private int IdFrota;

        private string Titulo;

        private string Descricao;

        private bool EhPublica;



        /// <summary>
        /// @return
        /// </summary>
        public int getIdFrota() {
            return IdFrota;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdFrota(int value) {
            this.IdFrota = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getTitulo() {
            return this.Titulo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setTitulo(string value) {
            this.Titulo = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDescricao() {
            return this.Descricao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDescricao(string value) {
            this.Descricao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public bool getEhPublica() {
            return this.EhPublica;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setEhPublica(bool value) {
            this.EhPublica = value;
        }

    }
}
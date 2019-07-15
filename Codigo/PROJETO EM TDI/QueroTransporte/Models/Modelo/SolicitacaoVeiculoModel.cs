
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class SolicitacaoVeiculo {

        public SolicitacaoVeiculo() {
        }

        private int IdSolicitacao;

        private int IdUsuario;

        private int IdViagem;

        private string DataSolicitacao;

        private bool FoiAtendida;




        /// <summary>
        /// @return
        /// </summary>
        public int getIdSolicitacao() {
            // TODO implement here
            return this.IdSolicitacao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdSolicitacao(int value) {
            this.IdSolicitacao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public int getIdUsuario() {
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
        public int getIdViagem() {
            return this.IdViagem;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdViagem(int value) {
            this.IdViagem = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDataSolicitacao() {
            return this.DataSolicitacao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDataSolicitacao(string value) {
            this.DataSolicitacao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public bool getFoiAtendida() {
            return this.FoiAtendida;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setFoiAtendida(bool value) {
            this.FoiAtendida = value;
        }
    }
}
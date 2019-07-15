
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class PagamentoPassagem {

        public PagamentoPassagem() {
        }

        private int IdPagamento;

        private string DataPagamento;

        private string TipoPagamento;


        /// <summary>
        /// @return
        /// </summary>
        public int getIdPagamento() {
            return this.IdPagamento;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdPagamento(int value) {
            this.IdPagamento = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDataPagamento() {
            return this.DataPagamento;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDataPagamento(string value) {
            this.DataPagamento = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getTipoPagamento() {
            return this.TipoPagamento;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setTipoPagamento(string value) {
            this.TipoPagamento = value;
        }

    }
}
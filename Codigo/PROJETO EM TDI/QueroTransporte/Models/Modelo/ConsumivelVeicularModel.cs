
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class ConsumivelVeicular {

        public ConsumivelVeicular() {
        }

        private int IdConsumivel;

        private int IdVeiculo;

        private double Valor;

        private string DataDespesa;

        private string Categoria;


        /// <summary>
        /// @return
        /// </summary>
        public int getIdConsumivel() {
            // TODO implement here
            return this.IdConsumivel;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdConsumivel(int value) {
            this.IdConsumivel = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public int getIdVeiculo() {
            return IdVeiculo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdVeiculo(int value) {
            this.IdVeiculo = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double getValor() {
            return this.Valor;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setValor(double value) {
            this.Valor = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDataDespesa() {
            return this.DataDespesa;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDataDespesa(string value) {
            this.DataDespesa = value;
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

    }
}
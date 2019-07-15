
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Veiculo {

        public Veiculo() {
        }

        private int IdVeiculo;

        private int IdFrota;

        private string Placa;

        private string Marca;

        private string Modelo;

        private string Cor;

        private string AnoFabricacao;

        private string AnoModelo;

        private string DataEmplacamento;

        private string Chassi;

        private string Categoria;

        private int Capacidade;




        /// <summary>
        /// @return
        /// </summary>
        public int getIdVeiculo() {
            // TODO implement here
            return this.IdVeiculo;
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
        public int getIdFrota() {
            return this.IdFrota;
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
        public string getPlaca() {
            return this.Placa;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setPlaca(string value) {
            this.Placa = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getMarca() {
            return this.Marca;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setMarca(string value) {
            this.Marca = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getModelo() {
            return this.Modelo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setModelo(string value) {
            this.Modelo = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getCor() {
            return this.Cor;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setCor(string value) {
            this.Cor = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getAnoFabricacao() {
            return this.AnoFabricacao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setAnoFabricacao(string value) {
            this.AnoFabricacao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getAnoModelo() {
            return this.AnoModelo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setAnoModelo(string value) {
            this.AnoModelo = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDataEmplacamento() {
            return this.DataEmplacamento;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDataEmplacamento(string value) {
            this.DataEmplacamento = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getChassi() {
            return this.Chassi;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setChassi(string value) {
            this.Chassi = value;
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
        public int getCapacidade() {
            return this.Capacidade;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setCapacidade(int value) {
            this.Capacidade = value;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Viagem {

        public Viagem() {
        }

        private int IdViagem;

        private int IdRota;

        private int IdVeiculo;

        private double Preco;

        private int Lotacao;

        private bool FoiRealizada;




        public void Operation1() {
            // TODO implement here
        }

        /// <summary>
        /// @return
        /// </summary>
        public int getIdViagem() {
            // TODO implement here
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
        public int getIdRota() {
            // TODO implement here
            return this.IdRota;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdRota(int value) {
            this.IdRota = value;
        }

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
        public double getPreco() {
            // TODO implement here
            return this.Preco;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setPreco(double value) {
            this.Preco = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public int getLotacao() {
            return this.Lotacao;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setLotacao(int value) {
            this.Lotacao = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public bool getFoiRealizada() {
            return FoiRealizada;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setFoiRealizada(bool value) {
            this.FoiRealizada = value;
        }

    }
}
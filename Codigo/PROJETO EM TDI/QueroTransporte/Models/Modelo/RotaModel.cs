
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Rota {

        public Rota() {
        }

        private int IdRota;

        private string Origem;

        private string Destino;

        private double HorarioSaida;

        private double HorarioChegada;

        private string DiaSemana;

        private bool EhComposta;




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
        public string getOrigem() {
            return this.Origem;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setOrigem(string value) {
            this.Origem = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDestino() {
            return this.Destino;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDestino(string value) {
            this.Destino = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double getHorarioSaida() {
            return this.HorarioSaida;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setHorarioSaida(double value) {
            this.HorarioSaida = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double getHorarioChegada() {
            // TODO implement here
            return this.HorarioChegada;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setHorarioChegada(double value) {
            this.HorarioChegada = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public string getDiaSemana() {
            // TODO implement here
            return this.DiaSemana;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setDiaSemana(string value) {
            this.DiaSemana = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public bool getEhComposta() {
            return this.EhComposta;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setEhComposta(bool value) {
            this.EhComposta = value;
        }
    }
}
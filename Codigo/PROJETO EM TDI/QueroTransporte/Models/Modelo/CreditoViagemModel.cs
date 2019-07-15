
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class CreditoViagem {

        public CreditoViagem() {
        }

        private int IdCredito;

        private double Saldo;


        /// <summary>
        /// @return
        /// </summary>
        public int getIdCredito() {
            return this.IdCredito;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdCredito(int value) {
            this.IdCredito = value;
        }

        /// <summary>
        /// @return
        /// </summary>
        public double getSaldo() {
            return this.Saldo;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setSaldo(double value) {
            this.Saldo = value;
        }

    }
}
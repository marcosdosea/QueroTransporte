
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Cliente {

        public Cliente() {
        }

        public int idCliente;

        /// <summary>
        /// @return
        /// </summary>
        public int getIdCliente() {
            // TODO implement here
            return this.idCliente;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdCliente(int value) {
            this.idCliente = value;
        }

    }
}
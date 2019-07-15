
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Gestor {

        public Gestor() {
        }

        public int idGestor;

        /// <summary>
        /// @return
        /// </summary>
        public int getIdGestor() {
            // TODO implement here
            return this.idGestor;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdGestor(int value) {
            this.idGestor = value;
        }

    }
}
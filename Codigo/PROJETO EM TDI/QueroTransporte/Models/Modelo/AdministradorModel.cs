
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class Administrador {

        public Administrador() {
        }

        private int IdAdm;

        /// <summary>
        /// @return
        /// </summary>
        public int getIdAdm() {
            // TODO implement here
            return this.IdAdm;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdAdm(int value) {
            this.IdAdm = value;
        }

    }
}
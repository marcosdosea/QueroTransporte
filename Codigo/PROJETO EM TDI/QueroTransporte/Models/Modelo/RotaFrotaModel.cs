
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QueroTransporte.Modelo{
    public class RotaFrota {

        public RotaFrota() {
        }

        private int IdRotaFrota;

        private int IdFrota;

        private int IdRota;



        /// <summary>
        /// @return
        /// </summary>
        public int getIdRotaFrota() {
            // TODO implement here
            return this.IdRotaFrota;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdRotaFrota(int value) {
            this.IdRotaFrota = value;
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
        public int getIdRota() {
            return this.IdRota;
        }

        /// <summary>
        /// @param value
        /// </summary>
        public void setIdRota(int value) {
            this.IdRota = value;
        }

    }
}
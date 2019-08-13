using Business;
using Persistence;
using QueroTransporte.Model;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Business
{
    public class GerenciadorConsumivelVeicular
    {
        private readonly BD_QUERO_TRANSPORTEContext _context;
        public GerenciadorConsumivelVeicular(BD_QUERO_TRANSPORTEContext context)
        {
            this._context = context;
        }
        
        /// <summary>
        /// Insere consumível veicular na base de dados
        /// </summary>
        /// <param name="consumivelveicularModel"> </param>
        /// <returns> </returns>
        public bool Inserir(ConsumivelVeicularModel objeto)
        {
            ConsumivelVeicular _consumivel = new ConsumivelVeicular();
            Atribuir(objeto, _consumivel);

            _context.Add(_consumivel);
            return _context.SaveChanges() == 1 ? true : false;
        }

        /// <summary>
        /// Altera dados do consumível veicular na base de dados
        /// </summary>
        /// <param name="consumivelveicularModel"> </param>
        /// <returns> </returns>
        public bool Editar(ConsumivelVeicular objeto)
        {
            ConsumivelVeicular _consumivel = new ConsumivelVeicular();

            Atribuir(objeto, _consumivel);
            _context.Update(_consumivel);
            return _context.SaveChanges() == 1 ? true : false;
        }
    }
}

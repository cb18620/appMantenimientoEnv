using Ardalis.Specification;
using Dominio.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IRepositoryAsync<T> : IRepositoryBase<T> where T : class
    {
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);


        /// <summary>
        /// Retorna una funcion refcursor desde la base d edatos
        /// </summary>
        /// <param name="nameFunction">Nombre de la funcion</param>
        /// <param name="param">Parametros deben estar en el orden de la misma consulta</param>
        /// <returns>Listado de objecto T resultado de la operación</returns>
        Task<List<T>> CallFunctionReFCursor(string nameFunction,  params object[] param);
    }

    public interface IReadRepositoryAsync<T> : IReadRepositoryBase<T> where T : class
    {

    }


}

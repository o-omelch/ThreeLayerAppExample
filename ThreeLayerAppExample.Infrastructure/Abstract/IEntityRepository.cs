using System.Collections.Generic;

namespace ThreeLayerAppExample.Infrastructure.Abstract
{
   public interface IEntityRepository<T> where T : class, IEntity, new()
   {
      IEnumerable<T> GetAll( );
      T Get( int id );
      void Add( T entity );
      void Update( T entity );
      void Delete( T entity );
   }
}

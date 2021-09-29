
using System.Collections.Generic;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.Infrastructure.Abstract
{
   public interface ICarPhotoRepository : IEntityRepository<CarPhoto>
   {
      IEnumerable<CarPhoto> GetByCar( int carId );
   }
}

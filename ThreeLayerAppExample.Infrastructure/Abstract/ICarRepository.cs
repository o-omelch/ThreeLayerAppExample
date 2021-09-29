using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.Infrastructure.Abstract
{
   public interface ICarRepository : IEntityRepository<Car>
   {
   }
}

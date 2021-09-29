
using ThreeLayerAppExample.Infrastructure.Abstract;

namespace ThreeLayerAppExample.Infrastructure.Entities
{
   public class CarPhoto : IEntity
   {
      public int Id { get; set; }
      public int CarId { get; set; }
      public string PhotoURI { get; set; }
   }
}

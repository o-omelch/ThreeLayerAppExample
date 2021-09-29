
using ThreeLayerAppExample.Infrastructure.Abstract;

namespace ThreeLayerAppExample.Infrastructure.Entities
{
   public class Car : IEntity
   {
      public int Id { get; set; }
      public string Brand { get; set; }
      public string Color { get; set; }
      public int ModelYear { get; set; }
      public decimal DailyPrice { get; set; }
      public string Description { get; set; }
   }
}

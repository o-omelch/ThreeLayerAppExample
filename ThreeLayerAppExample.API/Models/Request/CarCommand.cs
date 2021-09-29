using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeLayerAppExample.API.Models.Request
{
   public class CarCommand
   {
      public int Id { get; set; }
      public string Brand { get; set; }
      public string Color { get; set; }
      public int ModelYear { get; set; }
      public decimal DailyPrice { get; set; }
      public string Description { get; set; }
   }
}

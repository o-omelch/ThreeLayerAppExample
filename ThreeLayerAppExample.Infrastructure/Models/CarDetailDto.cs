using System;
using System.Collections.Generic;
using System.Text;

namespace ThreeLayerAppExample.Infrastructure.Models
{
   public class CarDetailDto
   {
      public int Id { get; set; }
      public string Brand { get; set; }
      public string Color { get; set; }
      public int ModelYear { get; set; }
      public decimal DailyPrice { get; set; }
      public string Description { get; set; }
      public string CoverPhoto { get; set; }
   }
}

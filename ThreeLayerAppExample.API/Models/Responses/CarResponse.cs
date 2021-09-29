namespace ThreeLayerAppExample.API.Models.Responses
{
   public class CarResponse
   {
      public int Id { get; set; }
      public string Brand { get; set; }
      public string Color { get; set; }
      public int ModelYear { get; set; }
      public decimal DailyPrice { get; set; }
      public string Description { get; set; }
   }
}

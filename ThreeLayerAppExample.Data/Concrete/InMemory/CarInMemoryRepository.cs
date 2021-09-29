using System;
using System.Collections.Generic;
using System.Linq;
using ThreeLayerAppExample.Infrastructure.Abstract;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.Data.Concrete.InMemory
{
   public class CarInMemoryRepository : ICarRepository
   {
      private readonly IList<Car> _cars;

      public CarInMemoryRepository()
      {
         _cars = new List<Car>
         {
             new Car {Id=1, Description="Sports", Brand="BMW", ModelYear=1996, Color="red", DailyPrice=120},
                new Car {Id=2, Description="Sedan", Brand="BMW", ModelYear=2010,Color="blue", DailyPrice=300},
                new Car {Id=3, Description="Coupe", Brand="Audi", ModelYear=2018, Color="green", DailyPrice=400},
                new Car {Id=4, Description="Hatchback", Brand="Volvo", ModelYear=2013, Color="silver", DailyPrice=310},
                new Car {Id=5, Description="Station Wagon", Brand="Mersedes", ModelYear=2020, Color="white", DailyPrice=450},
         };
      }

      public void Add( Car car )
      {
         _cars.Add( car );
      }

      public void Delete( int id )
      {
         Car forDelete = _cars.SingleOrDefault( d => id == d.Id );
         _cars.Remove( forDelete );
      }

      public void Delete( Car entity )
      {
         _cars.Remove( entity );
      }

      public IEnumerable<Car> GetAll()
      {
         return _cars;
      }

      public Car Get( int id )
      {
         return _cars.SingleOrDefault( g => g.Id == id );
      }


      public void Update( Car car )
      {
         Car forUpdate = _cars.SingleOrDefault( u => u.Id == car.Id );
         forUpdate.Brand = car.Brand;
         forUpdate.Color = car.Color;
         forUpdate.DailyPrice = car.DailyPrice;
         forUpdate.Description = car.Description;
         forUpdate.ModelYear = car.ModelYear;
      }
   }
}


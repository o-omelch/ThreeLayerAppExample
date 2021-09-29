using System;
using System.Collections.Generic;
using System.Linq;
using ThreeLayerAppExample.Infrastructure.Abstract;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.Data.Concrete.InMemory
{
   public class CarPhotoInMemoryRepository : ICarPhotoRepository
   {
      private readonly IList<CarPhoto> _carDetails;

      public CarPhotoInMemoryRepository()
      {
         _carDetails = new List<CarPhoto>
         {
            new CarPhoto{ Id = 1, CarId = 1, PhotoURI = "http://mysyte.com/bmw.jpg"},
            new CarPhoto{ Id = 2, CarId = 2, PhotoURI = "http://mysyte.com/bmw2.jpg"},
            new CarPhoto { Id = 3, CarId = 3, PhotoURI = "http://mysyte.com/audi.jpg" },
            new CarPhoto { Id = 4, CarId = 4, PhotoURI = "http://mysyte.com/volvo.jpg" },
            new CarPhoto { Id = 5, CarId = 5, PhotoURI = "http://mysyte.com/mersedes.jpg" },
         };
      }

      public void Add( CarPhoto entity )
      {
         _carDetails.Add( entity );
      }

      public void Delete( int id )
      {
         CarPhoto forDelete = _carDetails.SingleOrDefault( d => id == d.Id );
         _carDetails.Remove( forDelete );
      }

      public void Delete( CarPhoto entity )
      {
         _carDetails.Remove( entity );
      }

      public CarPhoto Get( int id )
      {
         return _carDetails.SingleOrDefault( p => p.Id == id );
      }

      public IEnumerable<CarPhoto> GetAll()
      {
         return _carDetails;
      }

      public void Update( CarPhoto entity )
      {
         var forUpdate = _carDetails.SingleOrDefault( u => u.Id == entity.Id );
         forUpdate.PhotoURI = entity.PhotoURI;
         forUpdate.CarId = entity.CarId;
      }

      IEnumerable<CarPhoto> ICarPhotoRepository.GetByCar( int carId )
      {
         return _carDetails.Where( p => p.Id == carId );
      }
   }
}

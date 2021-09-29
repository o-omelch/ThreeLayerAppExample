using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThreeLayerAppExample.BusinessLogic.Abstract;
using ThreeLayerAppExample.BusinessLogic.Models;
using ThreeLayerAppExample.Infrastructure.Abstract;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.BusinessLogic
{
   public class CarManager : ICarManager
   {
      private readonly ICarRepository _carRepository;
      private readonly ICarPhotoRepository _carPhotoRepository;
      private readonly IMapper _mapper;

      public CarManager(
         ICarRepository carRepository,
         ICarPhotoRepository carPhotoRepository,
         IMapper mapper )
      {
         _carRepository = carRepository ?? throw new ArgumentNullException( nameof( carRepository ) );
         _carPhotoRepository = carPhotoRepository ?? throw new ArgumentNullException( nameof( carPhotoRepository ) );
         _mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
      }

      public void AddCar( CarDto car )
      {
         var carEntity = _mapper.Map<Car>( car );
         _carRepository.Add( carEntity );
      }

      public void DeleteCar( CarDto car )
      {
         var carEntity = _mapper.Map<Car>( car );
         _carRepository.Delete( carEntity );
      }

      public void DeleteCar( int id )
      {
         var carEntity = _carRepository.Get( id );
         _carRepository.Delete( carEntity );
      }

      public IEnumerable<CarDto> GetAllCars()
      {
         var cars = _carRepository.GetAll();
         return _mapper.Map<IEnumerable<CarDto>>( cars );
      }

      public CarDto GetCarById( int id )
      {
         var car = _carRepository.Get(id);
         return _mapper.Map<CarDto>( car );
      }

      public IEnumerable<CarDetailDto> GetCarDetails()
      {
         var cars = _carRepository.GetAll();

         List<CarDetailDto> result = new List<CarDetailDto>();
         foreach (var car in cars )
         {
            var detail = _carPhotoRepository.GetByCar( car.Id );

            var carDetail = new CarDetailDto
            {
               Id = car.Id,
               Brand = car.Brand,
               Color = car.Color,
               DailyPrice = car.DailyPrice,
               Description = car.Description,
               ModelYear = car.ModelYear,
               PhotoURI = detail.FirstOrDefault().PhotoURI
            };

            result.Add( carDetail );
         }
         return result;
      }

      public CarDetailDto GetCarDetailsById( int id )
      {
         var car = _carRepository.Get(id);
         var detail = _carPhotoRepository.GetByCar( car.Id );

         return new CarDetailDto
         {
            Id = car.Id,
            Brand = car.Brand,
            Color = car.Color,
            DailyPrice = car.DailyPrice,
            Description = car.Description,
            ModelYear = car.ModelYear,
            PhotoURI = detail.FirstOrDefault().PhotoURI
         };
      }

      public IEnumerable<CarDto> GetCarsByBrand( string brand )
      {
         var cars = _carRepository.GetAll().Where( c => c.Brand == brand );
         return _mapper.Map<IEnumerable<CarDto>>( cars );
      }

      public IEnumerable<CarDto> GetCarsByColor( string color )
      {
         var cars = _carRepository.GetAll().Where( c => c.Color == color );
         return _mapper.Map<IEnumerable<CarDto>>( cars );
      }

      public void UpdateCar( CarDto car )
      {
         var carEntity = _mapper.Map<Car>( car );
         _carRepository.Update( carEntity );
      }
   }
}

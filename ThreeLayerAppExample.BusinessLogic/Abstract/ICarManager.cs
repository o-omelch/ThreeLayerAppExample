using System;
using System.Collections.Generic;
using System.Text;
using ThreeLayerAppExample.BusinessLogic.Models;

namespace ThreeLayerAppExample.BusinessLogic.Abstract
{
   public interface ICarManager
   {
      CarDto GetCarById( int id );
      IEnumerable<CarDto> GetAllCars();
      IEnumerable<CarDto> GetCarsByBrand( string brand );
      IEnumerable<CarDto> GetCarsByColor( string color );
      IEnumerable<CarDetailDto> GetCarDetails();
      CarDetailDto GetCarDetailsById( int id );
       void AddCar( CarDto car );
       void UpdateCar( CarDto car );
       void DeleteCar( CarDto car );
      void DeleteCar( int id );

   }
}

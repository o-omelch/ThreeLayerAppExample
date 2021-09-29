using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThreeLayerAppExample.API.Models.Request;
using ThreeLayerAppExample.API.Models.Responses;
using ThreeLayerAppExample.BusinessLogic.Models;
using ThreeLayerAppExample.Infrastructure.Entities;

namespace ThreeLayerAppExample.API.MapperProfiles
{
   public class CarPresenterProfile : Profile
   {
      public CarPresenterProfile()
      {
         CreateMap<CarDto, CarResponse>();
         CreateMap<CarCommand, CarDto>();
         CreateMap<Car, CarDto>();
      }

   }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreeLayerAppExample.API.Models.Request;
using ThreeLayerAppExample.API.Models.Responses;
using ThreeLayerAppExample.BusinessLogic.Abstract;
using ThreeLayerAppExample.BusinessLogic.Models;

namespace ThreeLayerAppExample.API.Controllers
{
   [Route( "api/[controller]" )]
   [ApiController]
   public class CarController : ControllerBase
   {
      private readonly ICarManager _carManager;
      private readonly IMapper _mapper;

      public CarController( 
         ICarManager carManager,
         IMapper mapper)
      {
         _carManager = carManager ?? throw new ArgumentNullException( nameof( carManager ) );
         _mapper = mapper ?? throw new ArgumentNullException( nameof( mapper ) );
      }

      // GET: api/<CarManagerController>
      [HttpGet]
      [ProducesResponseType( typeof( CarResponse ), StatusCodes.Status200OK )]
      public IActionResult Get()
      {
         var cars = _carManager.GetAllCars();
         var response = _mapper.Map<IEnumerable<CarResponse>>( cars );
         return OkResult( response );
      }

      // GET api/<CarManagerController>/5
      [HttpGet( "{id}" )]
      [ProducesResponseType( typeof( CarResponse ), StatusCodes.Status200OK )]
      public IActionResult Get( int id )
      {
         var car = _carManager.GetCarById( id );
         var response = _mapper.Map<CarResponse>( car );
         return OkResult( response );
      }

      // POST api/<CarManagerController>
      [HttpPost]
      [ProducesResponseType( StatusCodes.Status200OK )]
      public IActionResult Post( [FromBody] CarCommand command )
      {
         _carManager.AddCar( _mapper.Map<CarDto>( command ) );
         return Ok();
      }

      // PUT api/<CarManagerController>/5
      [HttpPut( "{id}" )]
      [ProducesResponseType( StatusCodes.Status200OK )]
      public IActionResult Put( [FromBody] CarCommand command )
      {
         _carManager.UpdateCar( _mapper.Map<CarDto>( command ) );
         return Ok();
      }

      // DELETE api/<CarManagerController>/5
      [HttpDelete( "{id}" )]
      [ProducesResponseType( StatusCodes.Status200OK )]
      public IActionResult Delete( int id )
      {
         _carManager.DeleteCar( id );
         return Ok();
      }

      private IActionResult OkResult<T>( T responseModel )
      {
         if ( responseModel == null )
         {
            return NotFound();
         }

         return Ok( responseModel );
      }
   }
}

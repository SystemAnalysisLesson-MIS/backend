using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Ikematgah;
using IkematgahDegisim.Entity.Mapping._Ikematgah;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IkematgahController : ControllerBase
    {
        private IIkematgahService _ikematgahManager;
        private IMapper mapper;
        public IkematgahController(IIkematgahService ıkematgahService, IMapper mapper)
        {
            this._ikematgahManager = ıkematgahService;
            this.mapper = mapper;
        }


        [HttpGet("getIkematgah")]
        public IActionResult GetIkematgah()
        {
            var result = _ikematgahManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpGet("getIkematgahById/{id:int}")]
        public IActionResult GetIkematgahById(int id)
        {
            var result = _ikematgahManager.GetById(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpPost("addVatandas")]
        public IActionResult AddVatandas(IkematgahDto ikematgahDto)
        {
            mapper = IkematgahMapping.GetMapper().CreateMapper();
            Ikematgah ikematgah = mapper.Map<IkematgahDto, Ikematgah>(ikematgahDto);

            var result = _ikematgahManager.Add(ikematgah);

            if (result.Success)
            {
                return this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateVatandas/{id:int}")]
        public IActionResult UpdateVatandas(IkematgahDto ikematgahDto, int id)
        {

            var dataResult = _ikematgahManager.GetById(id);

            if (dataResult.Success)
            {
                mapper = IkematgahMapping.GetMapper().CreateMapper();
                Ikematgah ikematgah = mapper.Map<IkematgahDto, Ikematgah>(ikematgahDto);

                var result = _ikematgahManager.Update(ikematgah);

                if (result.Success)
                {
                    return this.OkWithMessage(result.Message);
                }

                return this.BadRequestWithMessage(result.Message);
            }

            else
            {
                return this.BadRequestWithMessage(dataResult.Message);
            }
        }

        [HttpDelete("deleteVatandas/{id:int}")]
        public IActionResult DeleteVatandas(int id)
        {
            var dataResult = _ikematgahManager.GetById(id);

            if (dataResult.Success)
            {
              
              var result = _ikematgahManager.Delete(dataResult.Data);

              if (result.Success)
              {
                    return this.OkWithMessage(result.Message);
              }

                return this.BadRequestWithMessage(result.Message);
            }

            else
            {
                return this.BadRequestWithMessage(dataResult.Message);
            }
        }

    }
}
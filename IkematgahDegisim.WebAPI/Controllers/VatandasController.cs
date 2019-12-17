using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using IkematgahDegisim.Entity.Mapping._Vatandas;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatandasController : ControllerBase
    {
        private IVatandasService _vatandasManager;
        private IMapper mapper;
        public VatandasController(IVatandasService vatandasManager, IMapper mapper)
        {
            this._vatandasManager = vatandasManager;
            this.mapper = mapper;
        }


        [HttpGet("getVatandas")]
        public IActionResult GetVatandas()
        {
            var result = _vatandasManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpGet("getVatandasByIkematgahId/{id:int}")]
        public IActionResult GetTalepByIkematgahId(int id)
        {
            var result = _vatandasManager.GetByIkematgahId(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpGet("getById/{id:int}")]
        public IActionResult GetTalepById(int id)
        {
            var result = _vatandasManager.GetByID(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPost("addVatandas")]
        public IActionResult AddVatandas(VatandasDto vatandasDto)
        {
            mapper = VatandasMapping.GetMapper().CreateMapper();
            Vatandas vatandas = mapper.Map<VatandasDto, Vatandas>(vatandasDto);

            var result = _vatandasManager.Add(vatandas);

            if (result.Success)
            {
                return this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateVatandas/{id:int}")]
        public IActionResult UpdateVatandas(VatandasDto vatandasDto,int id)
        {

            var dataResult = _vatandasManager.GetByID(id);

            if (dataResult.Success)
            {
                mapper = VatandasMapping.GetMapper().CreateMapper();
                Vatandas vatandas = mapper.Map<VatandasDto, Vatandas>(vatandasDto);

                var result = _vatandasManager.Update(vatandas);

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

            var dataResult = _vatandasManager.GetByID(id);

            if (dataResult.Success)
            {
                var result = _vatandasManager.Delete(dataResult.Data);

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
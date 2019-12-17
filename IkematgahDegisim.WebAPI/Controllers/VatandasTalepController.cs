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
    public class VatandasTalepController : ControllerBase
    {
        private IVatandasTalepService _vatandastalepManager;
        private IMapper mapper;
        public VatandasTalepController(IVatandasTalepService vatandastalepManager, IMapper mapper)
        {
            this._vatandastalepManager = vatandastalepManager;
            this.mapper = mapper;
        }

        [HttpGet("getVatandasTalep")]
        public IActionResult GetVatandasTalep()
        {
            var result = _vatandastalepManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpGet("getVatandasTalep/{id:int}")]
        public IActionResult GetVatandasTalepById(int id)
        {
            var result = _vatandastalepManager.GetByID(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPost("addVatandasTalep")]
        public IActionResult AddVatandasTalep(VatandasTalepDto vatandasTalepDto)
        {
            mapper = VatandasTalepMapping.GetMapper().CreateMapper();
            VatandasTalep vatandasTalep = mapper.Map<VatandasTalepDto, VatandasTalep>(vatandasTalepDto);

            var result = _vatandastalepManager.Add(vatandasTalep);

            if (result.Success)
            {
                return this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpPut("updateVatandasTalep/{id:int}")]
        public IActionResult UpdateVatandasTalep(VatandasTalepDto vatandasTalepDto,int id)
        {

            var dataResult = _vatandastalepManager.GetByID(id);

            if (dataResult.Success)
            {
                mapper = VatandasTalepMapping.GetMapper().CreateMapper();
                VatandasTalep vatandasTalep = mapper.Map<VatandasTalepDto, VatandasTalep>(vatandasTalepDto);

                var result = _vatandastalepManager.Add(vatandasTalep);

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

        [HttpDelete("deleteVatandasTalep/{id:int}")]
        public IActionResult DeleteVatandasTalep(int id)
        {
            var dataResult = _vatandastalepManager.GetByID(id);

            if (dataResult.Success)
            {
                var result = _vatandastalepManager.Add(dataResult.Data);

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
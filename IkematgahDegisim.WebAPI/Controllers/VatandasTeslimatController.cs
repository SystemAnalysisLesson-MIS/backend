
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using IkematgahDegisim.Entity.Mapping._dVatandas;
using IkematgahDegisim.WebAPI.Controllers.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatandasTeslimatController : ControllerBase
    {
        private IVatandasTeslimatService _vatandasteslimatManager;
        private IMapper mapper;
        public VatandasTeslimatController(IVatandasTeslimatService vatandasteslimatManager, IMapper mapper)
        {
            this._vatandasteslimatManager = vatandasteslimatManager;
            this.mapper = mapper;
        }

        [HttpGet("getVatandasteslimat")]
        public IActionResult GetVatandasTeslimat()
        {
            var result = _vatandasteslimatManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpGet("getById/{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _vatandasteslimatManager.GetByID(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }



        [HttpPost("addVatandasteslimat")]
        public IActionResult AddVatandasTeslimat(VatandasTeslimatDto vatandasteslimatDto)
        {
            mapper = VatandasTeslimatMapping.GetMapper().CreateMapper();
            VatandasTeslimat vatandasTeslimat= mapper.Map<VatandasTeslimatDto, VatandasTeslimat>(vatandasteslimatDto);

            var result = _vatandasteslimatManager.Add(vatandasTeslimat);

            if (result.Success)
            {
                return this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateVatandasteslimat/{id:int}")]
        public IActionResult UpdateVatandasTeslimat(VatandasTeslimatDto vatandasteslimatDto, int id)
        {

            var dataResult = _vatandasteslimatManager.GetByID(id);

            if (dataResult.Success)
            {
                mapper = VatandasTeslimatMapping.GetMapper().CreateMapper();
                VatandasTeslimat vatandasTeslimat = mapper.Map<VatandasTeslimatDto, VatandasTeslimat>(vatandasteslimatDto);

                var result = _vatandasteslimatManager.Add(vatandasTeslimat);

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

        [HttpDelete("deleteVatandasTeslimat/{id:int}")]
        public IActionResult DeleteVatandasTeslimat(int id)
        {
            var dataResult = _vatandasteslimatManager.GetByID(id);

            if (dataResult.Success)
            {
               

                var result = _vatandasteslimatManager.Add(dataResult.Data);

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
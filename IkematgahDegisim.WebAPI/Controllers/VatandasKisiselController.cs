
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using IkematgahDegisim.Entity.Mapping._Vatandas;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatandasKisiselController : ControllerBase
    {
        private IVatandasKisiselService _vatandaskisiselManager;
        private IMapper mapper;
        public VatandasKisiselController(IVatandasKisiselService vatandaskisiselManager, IMapper mapper)
        {
            this._vatandaskisiselManager = vatandaskisiselManager;
            this.mapper = mapper;
        }

        [HttpGet("getVatandaskisisel")]
        public IActionResult GetVatandasKisisel()
        {
            var result = _vatandaskisiselManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }


        [HttpGet("getByVatandasId/{id:int}")]
        public IActionResult GetByVatandasId(int id)
        {
            var result = _vatandaskisiselManager.GetByVatandasId(id);

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

     

        [HttpPost("addVatandas")]
        public IActionResult AddVatandas(VatandasKisiselDto vatandaskisiselDto)
        {
            mapper = VatandasKisiselMapping.GetMapper().CreateMapper();
            VatandasKisisel vatandaskisisel = mapper.Map<VatandasKisiselDto, VatandasKisisel>(vatandaskisiselDto);

            var result = _vatandaskisiselManager.Add(vatandaskisisel);

            if (result.Success)
            {
                return this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateVatandas/{id:int}")]
        public IActionResult UpdateVatandas(VatandasKisiselDto vatandaskisiselDto, int id)
        {

            var dataResult = _vatandaskisiselManager.GetByVatandasId(id);

            if (dataResult.Success)
            {
                mapper = VatandasMapping.GetMapper().CreateMapper();
                VatandasKisisel vatandaskisisel = mapper.Map<VatandasKisiselDto, VatandasKisisel>(vatandaskisiselDto);

                var result = _vatandaskisiselManager.Update(vatandaskisisel);

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
            var dataResult = _vatandaskisiselManager.GetByVatandasId(id);

            if (dataResult.Success)
            {
             
                var result = _vatandaskisiselManager.Update(dataResult.Data);

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
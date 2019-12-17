
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Talep;
using IkematgahDegisim.Entity.Mapping._Talep;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalepController : ControllerBase
    {
        private ITalepService _talepManager;
        private IMapper mapper;
        public TalepController(ITalepService talepManager,IMapper mapper)
        {
            this._talepManager = talepManager;
            this.mapper = mapper;
        }

        [HttpGet("getTalep")]
        public IActionResult GetTalep()
        {
            var result = _talepManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data, result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPost("addTalep")]
        public IActionResult AddTalep(TalepDto talepDto)
        {
            mapper = TalepMapping.GetMapper().CreateMapper();
            Talep talep = mapper.Map<TalepDto, Talep>(talepDto);
            var result = _talepManager.Update(talep);

            if (result.Success)
            {
                this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateTalep/{id:int}")]
        public IActionResult UpdateTalep(TalepDto talepDto, int id)
        {

            var dataResult = _talepManager.GetById(id);

            if (dataResult.Success)
            {
                mapper = TalepMapping.GetMapper().CreateMapper();
                Talep talep = mapper.Map<TalepDto, Talep>(talepDto);
                var result = _talepManager.Update(talep);

                if (result.Success)
                {
                    this.OkWithMessage(result.Message);
                }

                return this.BadRequestWithMessage(result.Message);
            }

            else
            {
                return this.BadRequestWithMessage(dataResult.Message);
            }


        }


        [HttpDelete("deleteTalep/{id:int}")]
        public IActionResult DeleteTalep(int id)
        {

            var dataResult = _talepManager.GetById(id);

            if (dataResult.Success)
            {

                var result = _talepManager.Update(dataResult.Data);

                if (result.Success)
                {
                    this.OkWithMessage(result.Message);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Teslimat;
using IkematgahDegisim.Entity.Mapping._Teslimat;
using IkematgahDegisim.WebAPI.Controllers.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IkematgahDegisim.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeslimatController : ControllerBase
    {
        private ITeslimatService _teslimatManager;
        private IMapper mapper;
        public TeslimatController(ITeslimatService teslimatManager, IMapper mapper)
        {
            this._teslimatManager = teslimatManager;
            this.mapper = mapper;
        }

        [HttpGet("getTeslimat")]
        public IActionResult GetTeslimat()
        {
            var result = _teslimatManager.GetAll();

            if (result.Success)
            {
                return this.OkWithData(result.Data,result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPost("addTeslimat")]
        public IActionResult AddTeslimat(TeslimatDto teslimatDto)
        {
            mapper = TeslimatMapping.GetMapper().CreateMapper();
            Teslimat teslimat = mapper.Map<TeslimatDto, Teslimat>(teslimatDto);
            var result = _teslimatManager.Add(teslimat);

            if (result.Success)
            {
                this.OkWithMessage(result.Message);
            }

            return this.BadRequestWithMessage(result.Message);
        }

        [HttpPut("updateTeslimat/{id:int}")]
        public IActionResult UpdateTeslimat(TeslimatDto teslimatDto,int id)
        {

            var dataResult = _teslimatManager.GetByTeslimatId(id);

            if (dataResult.Success)
            {
                mapper = TeslimatMapping.GetMapper().CreateMapper();
                Teslimat teslimat = mapper.Map<TeslimatDto, Teslimat>(teslimatDto);
                var result = _teslimatManager.Update(teslimat);

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


        [HttpDelete("deleteTeslimat/{id:int}")]
        public IActionResult DeleteTeslimat(int id)
        {

            var dataResult = _teslimatManager.GetByTeslimatId(id);

            if (dataResult.Success)
            {
            
                var result = _teslimatManager.Update(dataResult.Data);

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
using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Teslimat;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._Teslimat
{
    public class TeslimatMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeslimatDto, Teslimat>()
                .ForMember(teslimat => teslimat.vatandasTeslimat, option => option.Ignore());

                cfg.CreateMap<Teslimat,TeslimatDto>();
            });

            return config;
        }
    }
}

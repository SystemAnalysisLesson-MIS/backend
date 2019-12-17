using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Ikematgah;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._Ikematgah
{
    public class IkematgahMapping : Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
             {
                 cfg.CreateMap<IkematgahDto, Ikematgah>()
                 .ForMember(ikematgah => ikematgah.vatandaslar, option => option.Ignore());

                 cfg.CreateMap<Ikematgah, IkematgahDto>();
                 
             });

            return config;
        }
    }
}

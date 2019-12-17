using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Talep;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._Talep
{
   public class TalepMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TalepDto, Talep>()
                .ForMember(talep=>talep.vatandasTalep, option => option.Ignore());

                cfg.CreateMap<Talep,TalepDto>();
            });

            return config;
        }
    }
}

using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._Vatandas
{
    public class VatandasTalepMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VatandasTalepDto, VatandasTalep>()
               .ForMember(vatandastalep => vatandastalep.vatandas, option => option.Ignore())
               .ForMember(vatandastalep => vatandastalep.talepler, option => option.Ignore());
             
                cfg.CreateMap<VatandasTalep, VatandasKisiselDto>();
            });

            return config;
        }
    }
}

using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._Vatandas
{
    public class VatandasKisiselMapping
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VatandasKisiselDto,VatandasKisisel>()
                .ForMember(vatandasKisisel=>vatandasKisisel.vatandas, option => option.Ignore());

                cfg.CreateMap<VatandasKisisel,VatandasKisiselDto>();
            });

            return config;
        }
    }
}

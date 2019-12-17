using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Entity.Mapping._dVatandas
{
    public class VatandasTeslimatMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VatandasTeslimatDto,VatandasTeslimat>()
              .ForMember(vatandastalep => vatandastalep.vatandas, option => option.Ignore())
              .ForMember(vatandastalep => vatandastalep.teslimatlar, option => option.Ignore());

                cfg.CreateMap<VatandasTalep, VatandasKisiselDto>();
            });

            return config;
        }
    }
}

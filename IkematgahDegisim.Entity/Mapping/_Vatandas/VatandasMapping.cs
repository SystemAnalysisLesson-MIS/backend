using AutoMapper;
using IkematgahDegisim.Entity.Concerete;
using IkematgahDegisim.Entity.Concerete.Dtos.Vatandas;

namespace IkematgahDegisim.Entity.Mapping._Vatandas
{
    public class VatandasMapping:Profile
    {
        public static MapperConfiguration GetMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<VatandasDto, Vatandas>()
                .ForMember(vatandas => vatandas.vatandasKisisel, option => option.Ignore())
                .ForMember(vatandas => vatandas.vatandasTalep, option => option.Ignore())
                .ForMember(vatandas => vatandas.vatandasTeslimat, option => option.Ignore());

                cfg.CreateMap<Vatandas, VatandasKisiselDto>();
            });

            return config;
        }
    }
}

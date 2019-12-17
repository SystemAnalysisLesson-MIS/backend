using IkematgahDegisim.Core.DataAccess.Abstract;
using IkematgahDegisim.Core.Entities.Concerete;
using System.Collections.Generic;

namespace IkematgahDegisim.DataAccess.Abstract.EntityFramework
{
    public interface IEfKullaniciDal:IEntityRepositoryBase<Kullanici>
    {
        List<OperasyonelTalep> GetClaims(Kullanici kullanici);
    }
}

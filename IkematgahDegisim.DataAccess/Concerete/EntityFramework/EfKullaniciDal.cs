using System.Collections.Generic;
using IkematgahDegisim.Core.DataAccess.Concerete.EntityFramework;
using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework.Context;
using System.Linq;

namespace IkematgahDegisim.DataAccess.Concerete.EntityFramework
{
    public class EfKullaniciDal : GenericEntityFrameworkRepositoryBase<Kullanici, IkematgahDegisimContext>, IEfKullaniciDal
    {
        public List<OperasyonelTalep> GetClaims(Kullanici kullanici)
        {
            using (var context = new IkematgahDegisimContext())
            {
                var result = from operationClaim in context.OperasyonelTalepler
                             join userOperationClaim in context.KullaniciOperasyonelTalepler
                                 on operationClaim.Id equals userOperationClaim.operationClaimId
                             where userOperationClaim.userId == kullanici.Id
                             select new OperasyonelTalep { Id = operationClaim.Id, name = operationClaim.name };

                return result.ToList();

            }
        }
    }
}

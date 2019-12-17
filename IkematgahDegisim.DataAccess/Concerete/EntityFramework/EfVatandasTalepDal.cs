

using IkematgahDegisim.Core.DataAccess.Concerete.EntityFramework;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework.Context;
using IkematgahDegisim.Entity.Concerete;


namespace IkematgahDegisim.DataAccess.Concerete.EntityFramework
{ 
    public class EfVatandasTalepDal:GenericEntityFrameworkRepositoryBase<VatandasTalep,IkematgahDegisimContext>,IEfVatandasTalepDal
    {

    }
}

using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IVatandasKisiselService
    {
        IResult Add(VatandasKisisel vatandasKisisel);
        IResult Delete(VatandasKisisel vatandasKisisel);
        IResult Update(VatandasKisisel vatandasKisisel);
        IDataResult<List<VatandasKisisel>> GetAll();
        IDataResult<VatandasKisisel> GetByVatandasId(int id);

        



    }
}

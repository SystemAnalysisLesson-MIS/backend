using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IVatandasTalepService
    {
        IDataResult<List<VatandasTalep>> GetAll();
        IDataResult<VatandasTalep> GetByID(int id);

        IDataResult<IEnumerable<VatandasTalep>> GetRelatedToTalepAndVatandas();

        IDataResult<IEnumerable<VatandasTalep>> GetRelatedToTalep();

        IDataResult<IEnumerable<VatandasTalep>> GetRelatedToVatandas();
        IResult TransactionalOperation(VatandasTalep vatandastalep);
        IResult TransactionalOperation(VatandasTalep vatandasTalep, Talep talep);
        IResult TransactionalDelete(VatandasTalep vatandasTalep, Talep talep);

        IResult TransactionalUpdate(VatandasTalep vatandasTalep, Talep talep);
        IResult TransactionalOperation(VatandasTalep vatandasTalep, Talep talep, VatandasTeslimat vatandasteslimat, Teslimat teslimat);
        IResult Add(VatandasTalep vatandastalep);
        IResult Delete(VatandasTalep vatandastalep);
        IResult Update(VatandasTalep vatandastalep);
    }
}

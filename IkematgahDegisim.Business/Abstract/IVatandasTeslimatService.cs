using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IVatandasTeslimatService
    {
        IDataResult<List<VatandasTeslimat>> GetAll();

        IDataResult<VatandasTeslimat> GetByID(int id);

        IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToVatandas();

        IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToTalep();

        IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToTalepAndVatandas();

        IResult TransactionalOperation(VatandasTeslimat vatandasteslimat);
        IResult TransactionalOperation(VatandasTeslimat vatandasteslimat, Teslimat teslimat);
        IResult TransactionalDelete(VatandasTeslimat vatandasTeslimat, Teslimat teslimat);
        IResult TransactionalUpdate(VatandasTeslimat vatandasTeslimat, Teslimat teslimat);

        IResult TransactionalOperationWithTalep(VatandasTeslimat vatandasTeslimat, Teslimat teslimat, Talep talep, VatandasTalep vatandasTalep);
        IResult OptionalTransactionalOperationWithTalep(VatandasTeslimat vatandasTeslimat, Teslimat teslimat, Talep talep, VatandasTalep vatandasTalep);
        IResult Add(VatandasTeslimat vatandasteslimat);
        IResult Delete(VatandasTeslimat vatandasteslimat);
        IResult Update(VatandasTeslimat vatandas);

    }
}

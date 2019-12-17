using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IVatandasService
    {
        IDataResult<List<Vatandas>> GetAll();
        IDataResult<Vatandas> GetByID(int id);

        IDataResult<Vatandas> GetByIkematgahId(int ikematgahId);

        IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiestoIkematgah();
        IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiesToVatandasKisisel();

        IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiesToIkematgahAndVatandasKisisel();
        IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel);

        IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Ikematgah ikematgah);
        IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici);
        IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah);
        IResult TransactionalOperation(Vatandas vatandas);
        IResult TransactionalDelete(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah);
        IResult TransactionalUpdate(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah);
        IResult Add(Vatandas vatandas);
        IResult Delete(Vatandas vatandas);
        IResult Update(Vatandas vatandas);


    }
}

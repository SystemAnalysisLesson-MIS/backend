using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface ITeslimatService
    {
        IResult Add(Teslimat teslimat);
        IResult Delete(Teslimat teslimat);
        IResult Update(Teslimat teslimat);

        IDataResult<List<Teslimat>> GetAll();
        IDataResult<Teslimat> GetByTeslimatId(int id);
    }
}

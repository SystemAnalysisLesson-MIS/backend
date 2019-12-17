using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface ITalepService
    {
        IResult Add(Talep talep);
        IResult Update(Talep talep);
        IResult Delete(Talep talep);
        IDataResult<List<Talep>> GetAll();
        IDataResult<Talep> GetById(int id);
    }
}

using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IIkematgahService
    {
        IResult Add(Ikematgah ikematgah);

        IResult Delete(Ikematgah ikematgah);

        IResult Update(Ikematgah ikematgah);

        IDataResult<List<Ikematgah>> GetAll();

        IDataResult<Ikematgah> GetById(int id);

    }
}

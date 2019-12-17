using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IkematgahDegisim.Business.Concerete
{
    public class IkematgahManager : IIkematgahService
    {

        private IEfIkematgahDal ikematgahDal;

        public IkematgahManager(IEfIkematgahDal ikematgahDal)
        {
            this.ikematgahDal = ikematgahDal;
        }
        public IResult Add(Ikematgah ikematgah)
        {
            try
            {
                ikematgahDal.Add(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IResult Delete(Ikematgah ikematgah)
        {
            try
            {
                ikematgahDal.Delete(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        public IDataResult<List<Ikematgah>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Ikematgah>>(ikematgahDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Ikematgah>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IDataResult<Ikematgah> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Ikematgah>(ikematgahDal.GetByFilter(i=>i.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<Ikematgah>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IResult Update(Ikematgah ikematgah)
        {
            try
            {
                ikematgahDal.Update(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

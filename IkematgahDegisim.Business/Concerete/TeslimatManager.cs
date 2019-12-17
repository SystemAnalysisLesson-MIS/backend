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
    public class TeslimatManager : ITeslimatService
    {
        private IEfTeslimatDal efTeslimatDal;

        public TeslimatManager(IEfTeslimatDal efTeslimatDal)
        {
            this.efTeslimatDal = efTeslimatDal;
        }

        public IResult Add(Teslimat teslimat)
        {
            try
            {
                efTeslimatDal.Add(teslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IResult Delete(Teslimat teslimat)
        {
            try
            {
                efTeslimatDal.Delete(teslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }

        public IDataResult<List<Teslimat>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Teslimat>>(efTeslimatDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Teslimat>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IDataResult<Teslimat> GetByTeslimatId(int id)
        {
            try
            {
                return new SuccessDataResult<Teslimat>(efTeslimatDal.GetByFilter(t=>t.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<Teslimat>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IResult Update(Teslimat teslimat)
        {
            try
            {
                efTeslimatDal.Update(teslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

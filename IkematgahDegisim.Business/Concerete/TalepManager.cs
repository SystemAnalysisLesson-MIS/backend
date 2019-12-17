using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Business.ValidationRules.FluentValidation;
using IkematgahDegisim.Core.Aspects.Autofac.Validation;

namespace IkematgahDegisim.Business.Concerete
{

    [ValidationAspect(typeof(TalepValidator))]
    public class TalepManager : ITalepService
    {
        private IEfTalepDal efTalepDal { get; set; }
       

        public TalepManager(IEfTalepDal efTalepDal)
        {
            this.efTalepDal = efTalepDal;
            
        }


        public IResult Add(Talep talep)
        {
            try
            {
                efTalepDal.Add(talep);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IResult Delete(Talep talep)
        {
            try
            {
                efTalepDal.Delete(talep);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        public IDataResult<List<Talep>> GetAll()
        {
            try
            {    
                return new SuccessDataResult<List<Talep>>(efTalepDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Talep>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IDataResult<Talep> GetById(int id)
        {

            try
            {
                return new SuccessDataResult<Talep>(efTalepDal.GetByFilter(t=>t.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<Talep>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }


        public IResult Update(Talep talep)
        {
            try
            {
                efTalepDal.Update(talep);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

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
using IkematgahDegisim.Core.Aspects.Autofac.Validation;
using IkematgahDegisim.Business.ValidationRules.FluentValidation;

namespace IkematgahDegisim.Business.Concerete
{

    [ValidationAspect(typeof(VatandasKisiselValidator))]
    public class VatandasKisiselManager : IVatandasKisiselService
    {
        private IEfVatandasKisiselDal efVatandasKisiselDal { get; set; }

        public VatandasKisiselManager(IEfVatandasKisiselDal efVatandasKisiselDal)
        {
            this.efVatandasKisiselDal = efVatandasKisiselDal;
        }


        public IResult Add(VatandasKisisel vatandasKisisel)
        {
            try
            {
                efVatandasKisiselDal.Add(vatandasKisisel);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IResult Delete(VatandasKisisel vatandasKisisel)
        {
            try
            {
                efVatandasKisiselDal.Delete(vatandasKisisel);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

      
        public IDataResult<VatandasKisisel> GetByVatandasId(int id)
        {
            try
            {
                return new SuccessDataResult<VatandasKisisel>(efVatandasKisiselDal.Find(id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<VatandasKisisel>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IResult Update(VatandasKisisel vatandasKisisel)
        {
            try
            {
                efVatandasKisiselDal.Update(vatandasKisisel);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }

        public IDataResult<List<VatandasKisisel>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<VatandasKisisel>>(efVatandasKisiselDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<VatandasKisisel>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }
    }
}

using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Business.BusinessAspects;
using IkematgahDegisim.Core.Aspects.Autofac.Transaction;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using IkematgahDegisim.Core.Utilities.Constants;

namespace IkematgahDegisim.Business.Concerete
{

    [ClaimRolesAspect("Postaci,postaci,superAdmin,superadmin,SuperAdmin")]
    public class VatandasTeslimatManager : IVatandasTeslimatService
    {

        private IEfVatandasTeslimatDal efVatandasTeslimatDal;
        private IEfTeslimatDal EfTeslimatDal;

        private IEfTalepDal efTalepDal;
        private IEfVatandasTalepDal efvatandastalepDal;

        public VatandasTeslimatManager(IEfVatandasTeslimatDal efVatandasTeslimatDal,IEfTeslimatDal efTeslimatDal,IEfTalepDal efTalepDal,IEfVatandasTalepDal efVatandasTalepDal)
        {
            this.EfTeslimatDal = efTeslimatDal;
            this.efVatandasTeslimatDal = efVatandasTeslimatDal;
            this.efTalepDal = efTalepDal;
            this.efvatandastalepDal = efVatandasTalepDal;
        }
        public IResult Add(VatandasTeslimat vatandasteslimat)
        {
            try
            {
                efVatandasTeslimatDal.Add(vatandasteslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IResult Delete(VatandasTeslimat vatandasteslimat)
        {
            try
            {
                efVatandasTeslimatDal.Delete(vatandasteslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        public IDataResult<List<VatandasTeslimat>> GetAll()
        {
            try
            {
               
                return new SuccessDataResult<List<VatandasTeslimat>>(efVatandasTeslimatDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<VatandasTeslimat>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IDataResult<VatandasTeslimat> GetByID(int id)
        {
            try
            {

                return new SuccessDataResult<VatandasTeslimat>(efVatandasTeslimatDal.GetByFilter(vt=>vt.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<VatandasTeslimat>(e.Message);
            }
        }

        public IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToTalep()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToTalepAndVatandas()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<VatandasTeslimat>> GetRelatedToVatandas()
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect()]
        public IResult OptionalTransactionalOperationWithTalep(VatandasTeslimat vatandasTeslimat, Teslimat teslimat, Talep talep, VatandasTalep vatandasTalep)
        {
            try
            {

                efVatandasTeslimatDal.Delete(vatandasTeslimat);
                EfTeslimatDal.Delete(teslimat);

                efvatandastalepDal.Delete(vatandasTalep);
                efTalepDal.Delete(talep);

                return new SuccessResult(DbOperationMessages.Basarili_Silme+" ve  "+DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme+" ve  "+DbOperationMessages.Basarisiz_Guncelleme);
            }
        }

        [TransactionScopeAspect()]
        public IResult TransactionalDelete(VatandasTeslimat vatandasTeslimat, Teslimat teslimat)
        {
            try
            {
                efVatandasTeslimatDal.Delete(vatandasTeslimat);
                EfTeslimatDal.Delete(teslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        public IResult TransactionalOperation(VatandasTeslimat vatandasteslimat)
        {
            throw new NotImplementedException();
        }

        [TransactionScopeAspect()]
        public IResult TransactionalOperation(VatandasTeslimat vatandasteslimat, Teslimat teslimat)
        {
            try
            {
                efVatandasTeslimatDal.Add(vatandasteslimat);
                EfTeslimatDal.Add(teslimat);
                return new SuccessResult(DbOperationMessages.Basarisiz_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        [TransactionScopeAspect()]
        public IResult TransactionalOperationWithTalep(VatandasTeslimat vatandasTeslimat, Teslimat teslimat, Talep talep, VatandasTalep vatandasTalep)
        {
            try
            {
                efVatandasTeslimatDal.Update(vatandasTeslimat);
                EfTeslimatDal.Update(teslimat);

                efVatandasTeslimatDal.Delete(vatandasTeslimat);
                EfTeslimatDal.Delete(teslimat);

                efvatandastalepDal.Delete(vatandasTalep);
                efTalepDal.Delete(talep);

                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme+" ve  "+DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        [TransactionScopeAspect()]
        public IResult TransactionalUpdate(VatandasTeslimat vatandasTeslimat, Teslimat teslimat)
        {
            try
            {
                efVatandasTeslimatDal.Update(vatandasTeslimat);
                EfTeslimatDal.Update(teslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }


        public IResult Update(VatandasTeslimat vatandasteslimat)
        {
            try
            {
                efVatandasTeslimatDal.Update(vatandasteslimat);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

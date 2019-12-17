using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Business.BusinessAspects;
using IkematgahDegisim.Core.Aspects.Autofac.Transaction;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.Dapper;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using IkematgahDegisim.Core.Utilities.Constants;

namespace IkematgahDegisim.Business.Concerete
{

  
    public class VatandasTalepManager : IVatandasTalepService
    {
        private IEfVatandasTalepDal efVatandasTalepDal;
        private IEfTalepDal efTalepDal;
        private IDapperVatandasTalepDal dapperVatandasTalepDal;
        private IEfTeslimatDal efTeslimatDal;
        private IEfVatandasTeslimatDal efVatandasTeslimatDal;


        public VatandasTalepManager(IEfVatandasTalepDal efVatandasTalepDal,IEfTalepDal efTalepDal,IDapperVatandasTalepDal dapperVatandasTalepDal,IEfTeslimatDal teslimatDal,IEfVatandasTeslimatDal efVatandasTeslimatDal)
        {
            this.efVatandasTalepDal = efVatandasTalepDal;
            this.efTalepDal = efTalepDal;
            this.dapperVatandasTalepDal = dapperVatandasTalepDal;
            this.efVatandasTeslimatDal = efVatandasTeslimatDal;
            this.efTeslimatDal = teslimatDal;
        }



        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult Add(VatandasTalep vatandastalep)
        {
            try
            {
                efVatandasTalepDal.Add(vatandastalep);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch(Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        [ClaimRolesAspect("Vatandas,vatandas,admin,Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IResult Delete(VatandasTalep vatandastalep)
        {
            try
            {
                efVatandasTalepDal.Delete(vatandastalep);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IDataResult<List<VatandasTalep>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<VatandasTalep>>(efVatandasTalepDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch(Exception e)
            {
                return new FailDataResult<List<VatandasTalep>>(DbOperationMessages.Listeleme_Basarisiz);

            }
        }

        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IDataResult<VatandasTalep> GetByID(int id)
        {
            try
            {
                return new SuccessDataResult<VatandasTalep>(efVatandasTalepDal.GetByFilter(vt=>vt.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<VatandasTalep>(DbOperationMessages.Listeleme_Basarisiz);

            }
        }

        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IDataResult<IEnumerable<VatandasTalep>> GetRelatedToTalep()
        {
            throw new NotImplementedException();
        }

        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IDataResult<IEnumerable<VatandasTalep>> GetRelatedToTalepAndVatandas()
        {
            throw new NotImplementedException();
        }

        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IDataResult<IEnumerable<VatandasTalep>> GetRelatedToVatandas()
        {
            throw new NotImplementedException();
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IResult TransactionalDelete(VatandasTalep vatandasTalep, Talep talep)
        {
            try
            {
                efVatandasTalepDal.Delete(vatandasTalep);
                efTalepDal.Delete(talep);

                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Listeleme_Basarili);
            }
        }

        public IResult TransactionalOperation(VatandasTalep vatandastalep)
        {
            throw new NotImplementedException();
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalOperation(VatandasTalep vatandasTalep, Talep talep)
        {
            try
            {
                efVatandasTalepDal.Add(vatandasTalep);
                efTalepDal.Add(talep);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IResult TransactionalOperation(VatandasTalep vatandasTalep, Talep talep, VatandasTeslimat vatandasteslimat, Teslimat teslimat)
        {
            try
            {
                efVatandasTalepDal.Update(vatandasTalep);
                efTalepDal.Update(talep);
                efTeslimatDal.Add(teslimat);
                efVatandasTeslimatDal.Add(vatandasteslimat);
                
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme+" ve "+DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme+" ve "+DbOperationMessages.Basarisiz_Ekleme);
            }
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IResult TransactionalUpdate(VatandasTalep vatandasTalep, Talep talep)
        {
            try
            {
                efVatandasTalepDal.Update(vatandasTalep);
                efTalepDal.Update(talep);

                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }

        [ClaimRolesAspect("Vatandas,vatandas,admin,Memur,memur,superAdmin,superadmin,SuperAdmin")]
        public IResult Update(VatandasTalep vatandastalep)
        {
            try
            {
                efVatandasTalepDal.Update(vatandastalep);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

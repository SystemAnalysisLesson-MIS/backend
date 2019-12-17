using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Business.BusinessAspects;
using IkematgahDegisim.Business.ValidationRules.FluentValidation;
using IkematgahDegisim.Core.Aspects.Autofac.Transaction;
using IkematgahDegisim.Core.Aspects.Autofac.Validation;
using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.Dapper;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IkematgahDegisim.Business.Concerete
{


    
    [ValidationAspect(typeof(VatandasValidator))]
    public class VatandasManager : IVatandasService
    {
        private IEfVatandasDal efVatandasDal { get; set; }
        private IEfVatandasKisiselDal efVatandasKisiselDal { get; set; }
        private IDapperVatandasDal dapperVatandasDal { get; set; }
        private IEfIkematgahDal efıkematgahDal { get; set; }
        private IEfKullaniciDal ıefkullaniciDal { get; set; }


        public VatandasManager(IEfVatandasDal efVatandasDal,IDapperVatandasDal dapperVatandasDal,IEfVatandasKisiselDal efVatandasKisiselDal,IEfIkematgahDal efIkematgahDal,IEfKullaniciDal efKullaniciDal)
        {
            this.dapperVatandasDal = dapperVatandasDal;
            this.efVatandasDal = efVatandasDal;
            this.efVatandasKisiselDal = efVatandasKisiselDal;
            this.efıkematgahDal = efIkematgahDal;
            this.ıefkullaniciDal = efKullaniciDal;
        }

        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult Add(Vatandas vatandas)
        {
            try
            {
                efVatandasDal.Add(vatandas);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch(Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult Delete(Vatandas vatandas)
        {
            try
            {
                efVatandasDal.Delete(vatandas);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<List<Vatandas>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Vatandas>>(efVatandasDal.GetAll().ToList(),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<Vatandas>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<Vatandas> GetByID(int id)
        {
            try
            {
                return new SuccessDataResult<Vatandas>(efVatandasDal.GetByFilter(v=>v.Id==id),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<Vatandas>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<Vatandas> GetByIkematgahId(int ikematgahId)
        {
            try
            {
                return new SuccessDataResult<Vatandas>(efVatandasDal.GetByFilter(v => v.ikematgahId == ikematgahId),DbOperationMessages.Listeleme_Basarili);
            }

            catch(Exception e)
            {
                return new FailDataResult<Vatandas>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiestoIkematgah()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Vatandas>>(dapperVatandasDal.GetRelatedValues<Vatandas, Ikematgah>("query", (v, ı) =>
                {
                    v.ikematgah = ı;
                    return v;
                }, splitOn: "Id"),DbOperationMessages.Listeleme_Basarili);
            }

            catch(Exception e)
            {
                return new FailDataResult<IEnumerable<Vatandas>>(DbOperationMessages.Listeleme_Basarisiz);
            }           
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiesToVatandasKisisel()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Vatandas>>(dapperVatandasDal.GetRelatedValues<Vatandas,VatandasKisisel>("query", (v, vk) =>
                {
                    v.vatandasKisisel = vk;
                    return v;
                }, splitOn: "Id"),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<IEnumerable<Vatandas>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        [ClaimRolesAspect("Superadmin,superAdmin")]
        public IDataResult<IEnumerable<Vatandas>> GetRelatedEntitiesToIkematgahAndVatandasKisisel()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Vatandas>>(dapperVatandasDal.GetRelatedValues<Vatandas, VatandasKisisel,Ikematgah>("query", (v, vk,ı) =>
                {
                    v.vatandasKisisel = vk;
                    v.ikematgah = ı;
                    vk.vatandas = v;
                    return v;
                }, splitOn: "Id"),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<IEnumerable<Vatandas>>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel)
        {
            try
            {
                efVatandasDal.Add(vatandas);
                efVatandasKisiselDal.Add(vatandasKisisel);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch(Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Ikematgah ikematgah)
        {
            try
            {
                efVatandasDal.Add(vatandas);
                efVatandasKisiselDal.Add(vatandasKisisel);
                efıkematgahDal.Add(ikematgah);
                return new SuccessResult();
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici)
        {
            try
            {
                efVatandasDal.Add(vatandas);
                efVatandasKisiselDal.Add(vatandasKisisel);
                ıefkullaniciDal.Add(kullanici);         
                return new SuccessResult();
            }

            catch (Exception e)
            {
                return new FailResult(e.Message);
            }
        }

        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalOperation(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah)
        {
            try
            {
                efVatandasDal.Add(vatandas);
                efVatandasKisiselDal.Add(vatandasKisisel);
                ıefkullaniciDal.Add(kullanici);
                efıkematgahDal.Add(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        [TransactionScopeAspect()]
        
        public IResult TransactionalOperation(Vatandas vatandas)
        {
            throw new NotImplementedException();
        }

        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult Update(Vatandas vatandas)
        {
            try
            {
                efVatandasDal.Update(vatandas);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch(Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }


        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalDelete(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah)
        {
            try
            {
                efVatandasDal.Delete(vatandas);
                efVatandasKisiselDal.Delete(vatandasKisisel);
                ıefkullaniciDal.Delete(kullanici);
                efıkematgahDal.Delete(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Silme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Silme);
            }
        }

        [TransactionScopeAspect()]
        [ClaimRolesAspect("Vatandas,vatandas,admin")]
        public IResult TransactionalUpdate(Vatandas vatandas, VatandasKisisel vatandasKisisel, Kullanici kullanici, Ikematgah ikematgah)
        {
            try
            {
                efVatandasDal.Update(vatandas);
                efVatandasKisiselDal.Update(vatandasKisisel);
                ıefkullaniciDal.Update(kullanici);
                efıkematgahDal.Update(ikematgah);
                return new SuccessResult(DbOperationMessages.Basarili_Guncelleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Guncelleme);
            }
        }
    }
}

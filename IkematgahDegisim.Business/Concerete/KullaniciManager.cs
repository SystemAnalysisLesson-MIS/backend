using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Fail;
using IkematgahDegisim.Core.Utilities.Results.Concerete.Success;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IkematgahDegisim.Core.Utilities.Constants;
using IkematgahDegisim.Core.Aspects.Autofac.Validation;
using IkematgahDegisim.Business.ValidationRules.FluentValidation;

namespace IkematgahDegisim.Business.Concerete
{

    [ValidationAspect(typeof(KullaniciValidator))]
    public class KullaniciManager : IKullaniciService
    {

        private IEfKullaniciDal efKullaniciDal;

        public KullaniciManager(IEfKullaniciDal efKullaniciDal)
        {
            this.efKullaniciDal = efKullaniciDal;
        }
        public IResult AddUser(Kullanici kullanici)
        {
            try
            {
                efKullaniciDal.Add(kullanici);
                return new SuccessResult(DbOperationMessages.Basarili_Ekleme);
            }

            catch (Exception e)
            {
                return new FailResult(DbOperationMessages.Basarisiz_Ekleme);
            }
        }

        public IDataResult<Kullanici> GetByEmail(string mail)
        {
            try
            {
                return new SuccessDataResult<Kullanici>(efKullaniciDal.GetByFilter(k=>k.email==mail),DbOperationMessages.Listeleme_Basarili);
            }

            catch (Exception e)
            {
                return new FailDataResult<Kullanici>(DbOperationMessages.Listeleme_Basarisiz);
            }
        }

        public IDataResult<Kullanici> GetByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<OperasyonelTalep>> GetClaims(Kullanici kullanici)
        {
            try
            {
                return new SuccessDataResult<List<OperasyonelTalep>>(efKullaniciDal.GetClaims(kullanici).ToList(),UserOperationMessages.Kullanici_Operasyonel_Talepler_basarili_bir_sekilde_getirildi);
            }

            catch (Exception e)
            {
                return new FailDataResult<List<OperasyonelTalep>>(UserOperationMessages.Kullanici_Operasyonel_Talepler_basarisiz_bir_sekilde_getirildi);
            }
        }

        public IDataResult<Kullanici> GetLoginNameAndPassword(string loginName, string password)
        {
            throw new NotImplementedException();
        }
    }
}

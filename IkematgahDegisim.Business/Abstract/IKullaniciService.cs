using IkematgahDegisim.Core.Entities.Concerete;
using IkematgahDegisim.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.Abstract
{
    public interface IKullaniciService
    {
        IResult AddUser(Kullanici kullanici);
        IDataResult<List<OperasyonelTalep>> GetClaims(Kullanici kullanici);

        IDataResult<Kullanici> GetLoginNameAndPassword(string loginName, string password);

        IDataResult<Kullanici> GetByEmail(string mail);
        IDataResult<Kullanici> GetByPhoneNumber(string phoneNumber);
    }
}

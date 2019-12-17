using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using IkematgahDegisim.Business.Abstract;
using IkematgahDegisim.Business.Concerete;
using IkematgahDegisim.Core.DataAccess.Abstract;
using IkematgahDegisim.Core.DataAccess.Concerete.Dapper;
using IkematgahDegisim.Core.Utilities.Interceptors;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Abstract;
using IkematgahDegisim.Core.Utilities.Security.Jwt.Concerete;
using IkematgahDegisim.DataAccess.Abstract.Dapper;
using IkematgahDegisim.DataAccess.Abstract.EntityFramework;
using IkematgahDegisim.DataAccess.Concerete.Dapper;
using IkematgahDegisim.DataAccess.Concerete.EntityFramework;
using IkematgahDegisim.Entity.Concerete;
using System;
using System.Collections.Generic;
using System.Text;

namespace IkematgahDegisim.Business.DepencyResolver.Autofac
{
    public class AutofacDepenciesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region EntityFramework DAL
            builder.RegisterType<EfTalepDal>().As<IEfTalepDal>();
            builder.RegisterType<EfIkematgahDal>().As<IEfIkematgahDal>();
            builder.RegisterType<EfTeslimatDal>().As<IEfTeslimatDal>();
            builder.RegisterType<EfVatandasDal>().As<IEfVatandasDal>();
            builder.RegisterType<EfVatandasKisiselDal>().As<IEfVatandasKisiselDal>();
            builder.RegisterType<EfVatandasTalepDal>().As<IEfVatandasTalepDal>();
            builder.RegisterType<EfVatandasTeslimatDal>().As<IEfVatandasTeslimatDal>();
            builder.RegisterType<EfKullaniciDal>().As<IEfKullaniciDal>();
            #endregion

            #region Dapper DAL
            builder.RegisterType<DapperKullaniciDal>().As<IDapperKullaniciDal>();
            builder.RegisterType<DapperVatandasDal>().As<IDapperVatandasDal>();
            builder.RegisterType<DapperIkematgahDal>().As<IDapperIkematgahDal>();
            builder.RegisterType<DapperTalepDal>().As<IDapperTalepDal>();
            builder.RegisterType<DapperTeslimatDal>().As<IDapperTeslimatDal>();
            builder.RegisterType<DapperVatandasTeslimatDal>().As<IDapperVatandasTeslimatDal>();
            builder.RegisterType<DapperVatandasTaleplDal>().As<IDapperVatandasTalepDal>();
            builder.RegisterType<DapperVatandasKisiselDal>().As<IDapperVatandasKisiselDal>();
            #endregion

            #region Repository

            builder.RegisterType<GenericDapperRepositoryBase<Teslimat>>().As<IDapperRepositoryBase<Teslimat>>();
            builder.RegisterType<GenericDapperRepositoryBase<Talep>>().As<IDapperRepositoryBase<Talep>>();

            #endregion

            #region Business

            builder.RegisterType<VatandasManager>().As<IVatandasService>();
            builder.RegisterType<VatandasKisiselManager>().As<IVatandasKisiselService>();
            builder.RegisterType<VatandasTalepManager>().As<IVatandasTalepService>();
            builder.RegisterType<VatandasTeslimatManager>().As<IVatandasTeslimatService>();
            builder.RegisterType<IkematgahManager>().As<IIkematgahService>();
            builder.RegisterType<TalepManager>().As<ITalepService>();
            builder.RegisterType<TeslimatManager>().As<ITeslimatService>();
            builder.RegisterType<KullaniciManager>().As<IKullaniciService>();
            builder.RegisterType<AuthManager>().As<IAuthManager>();

            #endregion

            #region JWT

            builder.RegisterType<JwtTokenHelper>().As<ITokenHelper>();

            #endregion

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}

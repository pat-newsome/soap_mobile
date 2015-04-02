﻿using System;
using System.Reflection;
using Autofac;

using Acr.XamForms.Mobile.IO;
using Acr.XamForms.Mobile;

using Xamarin.Forms;
using Acr.XamForms.Mobile.Net;
using Acr.XamForms.UserDialogs;
using ALFC_SOAP.Model;

namespace ALFC_SOAP
{
    public class App : Xamarin.Forms.Application
    {
        
        public static IContainer Container { get; private set; }
        static SoapFolder soapFolder;

        internal static readonly string TransientFilename = "TempSOAP.save";

        internal static SoapFolder SoapFolder
        {
            get { return soapFolder; }
        }

   

        public App()
        {
            var builder = new ContainerBuilder();
            RegisterXamService<IFileSystem>(builder);
            RegisterXamService<INetworkService>(builder);
            RegisterXamService<IPhoneService>(builder);
            RegisterXamService<ISettings>(builder);
            RegisterXamService<IUserDialogService>(builder);

            var _app = typeof(App).GetTypeInfo().Assembly;
            builder
                .RegisterAssemblyTypes(_app)
                //.Where(x => x.Namespace.Equals("PartnerMobileApp.ddddferer", StringComparison.CurrentCultureIgnoreCase))
                .AsSelf()
                .InstancePerDependency();

            Container = builder.Build();
            IFileSystem fs = (IFileSystem)Container.Resolve(typeof(IFileSystem));

            ISettings settings = (ISettings)Container.Resolve(typeof(ISettings));
            soapFolder = new SoapFolder(fs);
            this.MainPage = new NavigationPage(new HomePage(settings));
        }

        private static void RegisterXamService<T>(ContainerBuilder builder) where T : class
        {
            builder
                .Register(x => DependencyService.Get<T>())
                .SingleInstance();
        }
    }
}

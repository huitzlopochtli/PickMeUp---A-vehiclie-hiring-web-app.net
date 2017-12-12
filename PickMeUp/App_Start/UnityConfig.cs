using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PickMeUp.Controllers;
using PickMeUp.Data;
using PickMeUp.Entity;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using System;
using System.Data.Entity;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace PickMeUp
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<AccountController>(new InjectionConstructor(typeof(IVehicleTypeRepository), typeof(IDriverRepository), typeof(IPassengerRepository), typeof(IVehicleRepository)));


            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor(typeof(IDriverRepository), typeof(IVehicleRepository), typeof(IVehicleTypeRepository)));


            container.RegisterType<RoleController>(new InjectionConstructor());

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            


            container.RegisterType<IVehicleTypeRepository, VehicleTypeRepository>();
            container.RegisterType<IVehicleRepository, VehicleRepository>();
            container.RegisterType<IDriverRepository, DriverRepository>();
            container.RegisterType<IPassengerRepository, PassengerRepository>();
            container.RegisterType<IPaymentTypeRepository, PaymentTypeRepository>();
            container.RegisterType<IPaymentRepository, PaymentRepository>();
            container.RegisterType<IRideRepository, RideRepository>();


        }
    }
}
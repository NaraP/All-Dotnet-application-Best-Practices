using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFCustomControlLibrary.View;

namespace WPFCustomControlLibrary
{
   public class CustomerModule : IModule
    {
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer container;

        public CustomerModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            var view = this.container.Resolve<CustomerDetails>();
            this.regionManager.Regions["CustomerRegion"].Add(view, "CustomerDetails");
        }
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly:OwinStartup(typeof(AzureBillingViewer.Startup))]

namespace AzureBillingViewer {
  public partial class Startup {
    public void Configuration(IAppBuilder app) {
      ConfigureAuth(app);
    }
  }
}

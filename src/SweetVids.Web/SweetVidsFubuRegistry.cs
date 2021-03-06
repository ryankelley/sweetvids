using System;
using System.Xml.Serialization;
using FubuCore;
using FubuMVC.Core;
using FubuMVC.UI;
using SweetVids.Web.Actions.Rss;
using SweetVids.Web.Behaviors;
using SweetVids.Web.Conventions;

namespace SweetVids.Web
{
    public class SweetVidsFubuRegistry : FubuRegistry
    {
        public SweetVidsFubuRegistry(bool enableDiagnostics, string controllerAssemblyName)
        {
            IncludeDiagnostics(enableDiagnostics);

            Applies.ToThisAssembly();

            this.UseDefaultHtmlConventions();

            //Setup Actions
            Actions
              .IncludeTypesNamed(x => x.EndsWith("Action"));
         
            //Setup Routes
            Routes
                .IgnoreControllerNamespaceEntirely()
                .IgnoreClassSuffix("Action")
                .IgnoreMethodSuffix("Get")
                .IgnoreMethodSuffix("Post")
                .IgnoreMethodSuffix("Delete")
                .ConstrainToHttpMethod(call => call.Method.Name.Equals("Get"), "GET")
                .ConstrainToHttpMethod(call => call.Method.Name.Equals("Post"), "POST")
                .ConstrainToHttpMethod(call => call.Method.Name.Equals("Delete"), "DELETE")
                .ForInputTypesOf<IRequestById>(call => call.RouteInputFor(request => request.Id));
                

            this.StringConversions(x =>
                                       {
                                           
                                           x.IfIsType<DateTime>().ConvertBy(d => d.ToString("g"));
                                           x.IfIsType<decimal>().ConvertBy(d => d.ToString("N2"));
                                           x.IfIsType<float>().ConvertBy(f => f.ToString("N2"));
                                           x.IfIsType<double>().ConvertBy(d => d.ToString("N2"));
                                       });

         
            Views.TryToAttach(x =>
                                  {
                                      x.by_ViewModel_and_Namespace_and_MethodName();
                                      x.by_ViewModel_and_Namespace();
                                      x.by_ViewModel();
                                  });

            Output.To(call => new RssOutputNode(call.OutputType())).WhenTheOutputModelIs<RssFeed>();
        }
    }

    

   
}

#pragma checksum "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\home_reg.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9591ef35c327055b9f94da9362e28a9592ebd4ab"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GameWebSiteProject.Pages.Pages_home_reg), @"mvc.1.0.razor-page", @"/Pages/home_reg.cshtml")]
namespace GameWebSiteProject.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\_ViewImports.cshtml"
using GameWebSiteProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\home_reg.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9591ef35c327055b9f94da9362e28a9592ebd4ab", @"/Pages/home_reg.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d45aa2a4772bf641dcf4704a1c23489fee57be6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_home_reg : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"main\">\r\n    <div class=\"home-box\">\r\n        <h1>\r\n            Welcome, ");
#nullable restore
#line 9 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\home_reg.cshtml"
                Write(HttpContext.Session.GetString("username"));

#line default
#line hidden
#nullable disable
            WriteLiteral("!\r\n            <img src=\"https://4pubg.com/wp-content/uploads/2020/10/among-us.png\"/>\r\n        </h1>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameWebSiteProject.Pages.home_regModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GameWebSiteProject.Pages.home_regModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GameWebSiteProject.Pages.home_regModel>)PageContext?.ViewData;
        public GameWebSiteProject.Pages.home_regModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

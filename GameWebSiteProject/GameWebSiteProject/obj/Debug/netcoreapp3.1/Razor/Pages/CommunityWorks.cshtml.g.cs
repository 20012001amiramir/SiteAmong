#pragma checksum "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dacd85e5695cee7336dc1d4ed3324915c28295fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(GameWebSiteProject.Pages.Pages_CommunityWorks), @"mvc.1.0.razor-page", @"/Pages/CommunityWorks.cshtml")]
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
#line 7 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dacd85e5695cee7336dc1d4ed3324915c28295fe", @"/Pages/CommunityWorks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d45aa2a4772bf641dcf4704a1c23489fee57be6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_CommunityWorks : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page-handler", "Comment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
  
    ViewData["Title"] = "COMMUNITY WORKS";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 9 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
 for (int i = 0; i < Model.Works.Count; i = i + 2)
{
    string author = Model.GetAuthorUsername(Model.Works[i].User_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"display:flex; flex-direction:row; align-items:center; justify-content:space-evenly; margin-top:50px;\">\r\n        <div class=\"card\" style=\"width:540px; height:750px; overflow-y: auto\">\r\n            <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 512, "\"", 590, 3);
            WriteAttributeValue("", 518, "data:image/jpeg;", 518, 16, true);
            WriteAttributeValue(" ", 534, "base64,", 535, 8, true);
#nullable restore
#line 14 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 542, Convert.ToBase64String(Model.Works[i].Image), 543, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image\">\r\n            <div class=\"card-body\">\r\n                <h4 class=\"card-title\">");
#nullable restore
#line 16 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                  Write(Model.Works[i].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                <p class=\"card-text\">Author - <strong>");
#nullable restore
#line 17 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                                 Write(author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> <img class=\"card-img-top\" style=\"width:80px\"");
            BeginWriteAttribute("src", " src=\"", 829, "\"", 932, 3);
            WriteAttributeValue("", 835, "data:image/jpeg;", 835, 16, true);
            WriteAttributeValue(" ", 851, "base64,", 852, 8, true);
#nullable restore
#line 17 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 859, Convert.ToBase64String(Model.GetAuthorAvatar(Model.Works[i].User_Id)), 860, 72, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image\"></p>\r\n                <p class=\"card-text\">It\'s a ");
#nullable restore
#line 18 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                       Write(Model.Works[i].Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <span class=\"label label-primary\">Description:</span>\r\n                <p class=\"card-text\" style=\"max-height: 100px; overflow-y: auto\">");
#nullable restore
#line 20 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                                                            Write(Model.Works[i].Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <p class=\"card-text\">Publish date - ");
#nullable restore
#line 21 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                               Write(Model.Works[i].DateSent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                <input id=\"like\" class=\"btn btn-success\" disabled");
            BeginWriteAttribute("placeholder", " placeholder=\"", 1359, "\"", 1400, 2);
            WriteAttributeValue("", 1373, "Likes", 1373, 5, true);
#nullable restore
#line 22 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 1378, Model.Works[i].Likes, 1379, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" /> \r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dacd85e5695cee7336dc1d4ed3324915c28295fe9305", async() => {
                WriteLiteral("\r\n                    <input style=\"display:none\" name=\"workname\"");
                BeginWriteAttribute("value", " value=\"", 1508, "\"", 1536, 1);
#nullable restore
#line 24 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue("", 1516, Model.Works[i].Name, 1516, 20, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dacd85e5695cee7336dc1d4ed3324915c28295fe10061", async() => {
                    WriteLiteral("<p class=\"card-text\">Leave a comment</p>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                \r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 30 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
         if (i + 1 != Model.Works.Count)
        {
            author = Model.GetAuthorUsername(Model.Works[i + 1].User_Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card\" style=\"width:540px; height:750px; overflow-y: auto\">\r\n                <img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 2018, "\"", 2098, 3);
            WriteAttributeValue("", 2024, "data:image/jpeg;", 2024, 16, true);
            WriteAttributeValue(" ", 2040, "base64,", 2041, 8, true);
#nullable restore
#line 34 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 2048, Convert.ToBase64String(Model.Works[i+1].Image), 2049, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image\">\r\n                <div class=\"card-body\">\r\n                    <h4 class=\"card-title\">");
#nullable restore
#line 36 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                      Write(Model.Works[i + 1].Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <p class=\"card-text\">Author - <strong>");
#nullable restore
#line 37 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                                     Write(author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> <img class=\"card-img-top\" style=\"width:80px\"");
            BeginWriteAttribute("src", " src=\"", 2353, "\"", 2458, 3);
            WriteAttributeValue("", 2359, "data:image/jpeg;", 2359, 16, true);
            WriteAttributeValue(" ", 2375, "base64,", 2376, 8, true);
#nullable restore
#line 37 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 2383, Convert.ToBase64String(Model.GetAuthorAvatar(Model.Works[i+1].User_Id)), 2384, 74, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Card image\"></p>\r\n                    <p class=\"card-text\">It\'s a ");
#nullable restore
#line 38 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                           Write(Model.Works[i + 1].Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <span class=\"label label-primary\">Description:</span>\r\n                    <p class=\"card-text\" style=\"max-height:100px; overflow-y:auto\">");
#nullable restore
#line 40 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                                                              Write(Model.Works[i + 1].Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <p class=\"card-text\">Publish date - ");
#nullable restore
#line 41 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
                                                   Write(Model.Works[i + 1].DateSent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <input id=\"like\" class=\"btn btn-success\" disabled");
            BeginWriteAttribute("placeholder", " placeholder=\"", 2915, "\"", 2958, 2);
            WriteAttributeValue("", 2929, "Likes", 2929, 5, true);
#nullable restore
#line 42 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue(" ", 2934, Model.Works[i+1].Likes, 2935, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dacd85e5695cee7336dc1d4ed3324915c28295fe17018", async() => {
                WriteLiteral("\r\n                        <input style=\"display:none\" name=\"workname\"");
                BeginWriteAttribute("value", " value=\"", 3073, "\"", 3103, 1);
#nullable restore
#line 44 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
WriteAttributeValue("", 3081, Model.Works[i+1].Name, 3081, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dacd85e5695cee7336dc1d4ed3324915c28295fe17785", async() => {
                    WriteLiteral("<p class=\"card-text\">Leave a comment</p>");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.PageHandler = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 49 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
#nullable restore
#line 51 "D:\Study 2\Информатика\SiteAmong\GameWebSiteProject\GameWebSiteProject\Pages\CommunityWorks.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GameWebSiteProject.Pages.CommunityWorksModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GameWebSiteProject.Pages.CommunityWorksModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GameWebSiteProject.Pages.CommunityWorksModel>)PageContext?.ViewData;
        public GameWebSiteProject.Pages.CommunityWorksModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591

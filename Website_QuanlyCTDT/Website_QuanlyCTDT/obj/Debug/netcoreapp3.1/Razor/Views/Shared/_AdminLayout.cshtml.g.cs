#pragma checksum "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5fcbc744ecc9814a40027fd19cff51bcd79119b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__AdminLayout), @"mvc.1.0.view", @"/Views/Shared/_AdminLayout.cshtml")]
namespace AspNetCore
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
#line 1 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\_ViewImports.cshtml"
using Website_QuanlyCTDT;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\_ViewImports.cshtml"
using Website_QuanlyCTDT.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5fcbc744ecc9814a40027fd19cff51bcd79119b", @"/Views/Shared/_AdminLayout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ebace2b0cdf7f9849543aee989cd764c59d1f5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__AdminLayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\n<html>\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5fcbc744ecc9814a40027fd19cff51bcd79119b3321", async() => {
                WriteLiteral("\n    <meta charset=\"utf-8\" />\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\n    <title>");
#nullable restore
#line 6 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@" - Quản lý CTĐT khoa CNTT </title>
    <link rel=""stylesheet"" href=""//fonts.googleapis.com/css?family=Roboto:300,400,500,700,400italic"">
    <link rel=""stylesheet"" href=""//fonts.googleapis.com/icon?family=Material+Icons"">
    <link href=""https://use.fontawesome.com/releases/v5.0.8/css/all.css"" rel=""stylesheet"">

    <script");
                BeginWriteAttribute("src", " src=\"", 490, "\"", 530, 1);
#nullable restore
#line 11 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml"
WriteAttributeValue("", 496, Url.Content("~/bundle/assets.js"), 496, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d5fcbc744ecc9814a40027fd19cff51bcd79119b5411", async() => {
                WriteLiteral(@"
    <div id=""app"">



        <div class=""wrapper"">

            

            <!--</side-bar>-->
            <div data-color=""green"" class=""sidebar"" style=""background-image: url('/bundle/sidebar-2.jpg')"">
                <div class=""logo"">
                    <a href=""#"" class=""simple-text logo-mini""><div class=""logo-img""><img src=""/bundle/vue-logo.png""");
                BeginWriteAttribute("alt", " alt=\"", 913, "\"", 919, 0);
                EndWriteAttribute();
                WriteLiteral(@"></div></a> <a href=""https://www.creative-tim.com/product/vue-material-dashboard"" target=""_blank"" class=""simple-text logo-normal"">
                        Admin
                    </a>
                </div>
                <div class=""sidebar-wrapper"">

                    <ul class=""md-list nav md-theme-default"">
                        <li class=""md-list-item"">
                            <a href=""/AdminHome/Index"" class=""md-list-item-router md-list-item-container md-button-clean"">
                                <div class=""md-list-item-content md-ripple""><md-icon>dashboard</md-icon> <p>Trang chủ</p></div>
                            </a>
                        </li>
                        <li class=""md-list-item"">
                            <a href=""/AdminMonhoc/Index"" class=""md-list-item-router md-list-item-container md-button-clean"">
                                <div class=""md-list-item-content md-ripple""> <md-icon>content_paste</md-icon> <p>Môn học</p></div>
                            </a>
   ");
                WriteLiteral(@"                     </li>
                        <li class=""md-list-item"">
                            <a href=""/TienQuyets/Index"" class=""md-list-item-router md-list-item-container md-button-clean"">
                                <div class=""md-list-item-content md-ripple""> <md-icon>content_paste</md-icon> <p>Môn học tiên quyết</p></div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class=""main-panel"">
               

                <script");
                BeginWriteAttribute("src", " src=\"", 2495, "\"", 2541, 1);
#nullable restore
#line 53 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml"
WriteAttributeValue("", 2501, Url.Content("~/bundle/assets_admin.js"), 2501, 40, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n                ");
#nullable restore
#line 54 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml"
           Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"

                <footer class=""footer"">
                    <div class=""container"">
                        <nav><ul><li><a href=""https://www.creative-tim.com"">Creative Tim</a></li> <li><a href=""https://creative-tim.com/presentation""> About Us </a></li> <li><a href=""http://blog.creative-tim.com""> Blog </a></li> <li><a href=""https://www.creative-tim.com/license""> Licenses </a></li></ul></nav> <div class=""copyright text-center"">
                            © 2021
                            <a href=""https://www.creative-tim.com/?ref=mdf-vuejs"" target=""_blank"">Creative Tim</a>, made with <i class=""fa fa-heart heart""></i> for a better web
                        </div>
                    </div>
                </footer>
            </div>

        </div>



    </div>


");
                WriteLiteral("\n    ");
#nullable restore
#line 75 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Shared\_AdminLayout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\n\n\n\n\n\n\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n</html>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5966aaeba13b34249b71c937a70652b05b1bd5a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5966aaeba13b34249b71c937a70652b05b1bd5a", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ebace2b0cdf7f9849543aee989cd764c59d1f5a", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Home\About.cshtml"
   ViewData["Title"] = "About";
    Layout = "~/Views/Shared/_Layout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"content\">\n    <div id=\"app\">\n        <about-component></about-component>\n\n    </div>\n</div>\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\n    <script");
                BeginWriteAttribute("src", " src=\"", 215, "\"", 253, 1);
#nullable restore
#line 11 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\Home\About.cshtml"
WriteAttributeValue("", 221, Url.Content("~/bundle/Home.js"), 221, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\n   \n");
            }
            );
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

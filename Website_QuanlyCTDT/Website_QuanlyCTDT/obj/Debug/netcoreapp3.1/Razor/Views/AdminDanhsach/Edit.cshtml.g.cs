#pragma checksum "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4f386214fbf3a0c12b4db8355e6c8fcb0e083f6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminDanhsach_Edit), @"mvc.1.0.view", @"/Views/AdminDanhsach/Edit.cshtml")]
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
#nullable restore
#line 1 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4f386214fbf3a0c12b4db8355e6c8fcb0e083f6", @"/Views/AdminDanhsach/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ebace2b0cdf7f9849543aee989cd764c59d1f5a", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminDanhsach_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
   ViewData["Title"] = "Monhoc";
    Layout = "~/Views/Shared/_AdminLayout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"content\">\r\n    <div id=\"app\">\r\n        <edit-component");
            BeginWriteAttribute(":listmons", " :listmons=\"", 183, "\"", 240, 1);
#nullable restore
#line 8 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
WriteAttributeValue("", 195, JsonConvert.SerializeObject(ViewBag.listmon), 195, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("khoa", "  khoa=\"", 241, "\"", 262, 1);
#nullable restore
#line 8 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
WriteAttributeValue("", 249, ViewBag.khoa, 249, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("nganh", "  nganh=\"", 263, "\"", 286, 1);
#nullable restore
#line 8 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
WriteAttributeValue("", 272, ViewBag.nganh, 272, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute(":monhocs", " :monhocs=\"", 287, "\"", 342, 1);
#nullable restore
#line 8 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
WriteAttributeValue("", 298, JsonConvert.SerializeObject(ViewBag.monhoc), 298, 44, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></edit-component>\r\n\r\n    </div>\r\n\r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 422, "\"", 469, 1);
#nullable restore
#line 16 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminDanhsach\Edit.cshtml"
WriteAttributeValue("", 428, Url.Content("~/bundle/AdminDanhsach.js"), 428, 41, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
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
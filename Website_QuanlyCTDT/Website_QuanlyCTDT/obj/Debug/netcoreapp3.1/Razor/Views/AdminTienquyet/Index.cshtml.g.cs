#pragma checksum "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14e69dacd5daf34f230980de8fc460ca17827dbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AdminTienquyet_Index), @"mvc.1.0.view", @"/Views/AdminTienquyet/Index.cshtml")]
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
#line 2 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14e69dacd5daf34f230980de8fc460ca17827dbd", @"/Views/AdminTienquyet/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ebace2b0cdf7f9849543aee989cd764c59d1f5a", @"/Views/_ViewImports.cshtml")]
    public class Views_AdminTienquyet_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
 if (TempData["message"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script>alert(\'");
#nullable restore
#line 9 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
              Write(TempData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');</script>\r\n");
#nullable restore
#line 10 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"content\">\r\n    <div id=\"app\">\r\n        <admintienquyet-component");
            BeginWriteAttribute(":monhocs", " :monhocs=\"", 292, "\"", 348, 1);
#nullable restore
#line 14 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
WriteAttributeValue("", 303, JsonConvert.SerializeObject(ViewBag.listmon), 303, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute(":mhtqs", " :mhtqs=\"", 349, "\"", 400, 1);
#nullable restore
#line 14 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
WriteAttributeValue("", 358, JsonConvert.SerializeObject(ViewBag.mhtq), 358, 42, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" Edit-url=\"/AdminTienquyet/Edit\"></admintienquyet-component>\r\n\r\n    </div>\r\n</div>\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 516, "\"", 564, 1);
#nullable restore
#line 19 "D:\laptrinhweb\QuanlyCTDT\Website_QuanlyCTDT\Website_QuanlyCTDT\Views\AdminTienquyet\Index.cshtml"
WriteAttributeValue("", 522, Url.Content("~/bundle/AdminTienquyet.js"), 522, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n");
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
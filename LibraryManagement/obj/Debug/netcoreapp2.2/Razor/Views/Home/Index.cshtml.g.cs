#pragma checksum "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9751628934a55d70b2854e5370381ef3a1fdf73c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement;

#line default
#line hidden
#line 2 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9751628934a55d70b2854e5370381ef3a1fdf73c", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a03b079343b697176e720de9fa2d2a7e6e87ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Lakeview LSD";

#line default
#line hidden
            BeginContext(48, 80, true);
            WriteLiteral("\r\n<div id=\"showcase\" class=\"d-flex align-items-center justify-content-center\">\r\n");
            EndContext();
#line 6 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml"
      
        if (DateTime.Now.Hour > 12 && DateTime.Now.Hour < 18)
        {


#line default
#line hidden
            BeginContext(212, 114, true);
            WriteLiteral("            <h2 class=\"mb-4 text-light p-2 bg-dark rounded\">\r\n                Good Afternoon!\r\n            </h2>\r\n");
            EndContext();
#line 13 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml"
        }
        else if (DateTime.Now.Hour < 12)
        {

#line default
#line hidden
            BeginContext(390, 112, true);
            WriteLiteral("            <h2 class=\"mb-4 text-light p-2 bg-dark rounded\">\r\n                Good Morning!\r\n            </h2>\r\n");
            EndContext();
#line 19 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(538, 112, true);
            WriteLiteral("            <h2 class=\"mb-4 text-light p-2 bg-dark rounded\">\r\n                Good Evening!\r\n            </h2>\r\n");
            EndContext();
#line 25 "C:\Dev\LibraryManagementSystem_\LibraryManagement\Views\Home\Index.cshtml"
        }
    

#line default
#line hidden
            BeginContext(668, 6, true);
            WriteLiteral("</div>");
            EndContext();
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

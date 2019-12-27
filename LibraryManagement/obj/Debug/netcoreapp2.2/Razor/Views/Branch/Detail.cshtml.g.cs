#pragma checksum "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c26f10ee85e2cbf9ade9ec7e418bd3bc71331db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Branch_Detail), @"mvc.1.0.view", @"/Views/Branch/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Branch/Detail.cshtml", typeof(AspNetCore.Views_Branch_Detail))]
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
#line 1 "C:\Dev\LibraryManagement\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement;

#line default
#line hidden
#line 2 "C:\Dev\LibraryManagement\LibraryManagement\Views\_ViewImports.cshtml"
using LibraryManagement.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c26f10ee85e2cbf9ade9ec7e418bd3bc71331db", @"/Views/Branch/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a03b079343b697176e720de9fa2d2a7e6e87ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Branch_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibraryManagement.Models.Branch.BranchDetailModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
  
    ViewBag.Title = @Model.Name + " Branch";

#line default
#line hidden
            BeginContext(113, 152, true);
            WriteLiteral("\r\n<div class=\"container content\">\r\n    <h3>Branch Information</h3>\r\n    <hr />\r\n    <div class=\"jumbotron\">\r\n        <div class=\"row\">\r\n            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 265, "\"", 286, 1);
#line 12 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
WriteAttributeValue("", 271, Model.ImageUrl, 271, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(287, 153, true);
            WriteLiteral(" class=\"branches\" />\r\n        </div>\r\n        <div class=\"row mt-4\">\r\n            <div class=\"col-md-8\">\r\n                <div>\r\n                    <h2>");
            EndContext();
            BeginContext(441, 10, false);
#line 17 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                   Write(Model.Name);

#line default
#line hidden
            EndContext();
            BeginContext(451, 90, true);
            WriteLiteral("</h2>\r\n                    <div\">\r\n                        <p class=\"text-muted\">Address: ");
            EndContext();
            BeginContext(542, 13, false);
#line 19 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                                                  Write(Model.Address);

#line default
#line hidden
            EndContext();
            BeginContext(555, 63, true);
            WriteLiteral("</p>\r\n                        <p class=\"text-muted\">Telephone: ");
            EndContext();
            BeginContext(619, 15, false);
#line 20 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                                                    Write(Model.Telephone);

#line default
#line hidden
            EndContext();
            BeginContext(634, 95, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div>\r\n                    <p class=\"text-muted\">");
            EndContext();
            BeginContext(730, 17, false);
#line 23 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                                     Write(Model.Description);

#line default
#line hidden
            EndContext();
            BeginContext(747, 227, true);
            WriteLiteral("</p>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <table class=\"table\">\r\n                    <tr>\r\n                        <td>Date Opened: </td>\r\n                        <td>");
            EndContext();
            BeginContext(975, 39, false);
#line 30 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                       Write(Model.OpenedDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 142, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Number Of Patrons: </td>\r\n                        <td>");
            EndContext();
            BeginContext(1157, 21, false);
#line 34 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                       Write(Model.NumberOfPatrons);

#line default
#line hidden
            EndContext();
            BeginContext(1178, 141, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Number of Assets: </td>\r\n                        <td>");
            EndContext();
            BeginContext(1320, 20, false);
#line 38 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                       Write(Model.NumberOfAssets);

#line default
#line hidden
            EndContext();
            BeginContext(1340, 141, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td>Value of Assets: </td>\r\n                        <td>$");
            EndContext();
            BeginContext(1482, 22, false);
#line 42 "C:\Dev\LibraryManagement\LibraryManagement\Views\Branch\Detail.cshtml"
                        Write(Model.TotalAssetsValue);

#line default
#line hidden
            EndContext();
            BeginContext(1504, 147, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div id=\"space\"></div>   \r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibraryManagement.Models.Branch.BranchDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

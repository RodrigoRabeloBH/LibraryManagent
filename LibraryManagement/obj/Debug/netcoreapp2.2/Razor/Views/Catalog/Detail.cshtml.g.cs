#pragma checksum "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bc80f7f38075b0e926a911838eceb24281e0c95c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_Detail), @"mvc.1.0.view", @"/Views/Catalog/Detail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Catalog/Detail.cshtml", typeof(AspNetCore.Views_Catalog_Detail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bc80f7f38075b0e926a911838eceb24281e0c95c", @"/Views/Catalog/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a03b079343b697176e720de9fa2d2a7e6e87ff5", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<LibraryManagement.Models.Catalog.AssetDetailModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("button"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Catalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CheckIn", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Hold", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-info"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Checkout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MarkFound", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
  
    ViewData["Title"] = "View Library Item";

#line default
#line hidden
            BeginContext(113, 120, true);
            WriteLiteral("\r\n<div class=\"container content\">\r\n    <div class=\"page-header clearfix detailHeading\">\r\n        <h3 class=\"text-muted\">");
            EndContext();
            BeginContext(234, 17, false);
#line 9 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                          Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(251, 170, true);
            WriteLiteral("</h3>\r\n    </div>\r\n    <hr />\r\n    <div class=\"jumbotron\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-4\">\r\n                <div>\r\n                    <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 421, "\"", 442, 1);
#line 16 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
WriteAttributeValue("", 427, Model.ImageUrl, 427, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 443, "\"", 461, 1);
#line 16 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
WriteAttributeValue("", 449, Model.Title, 449, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(462, 146, true);
            WriteLiteral(" class=\"detailImage\" />\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <p id=\"itemTitle\">Title: ");
            EndContext();
            BeginContext(609, 11, false);
#line 20 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                    Write(Model.Title);

#line default
#line hidden
            EndContext();
            BeginContext(620, 49, true);
            WriteLiteral("</p>\r\n                <p id=\"itemAuthor\">Author: ");
            EndContext();
            BeginContext(670, 22, false);
#line 21 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                      Write(Model.AuthorOrDirector);

#line default
#line hidden
            EndContext();
            BeginContext(692, 49, true);
            WriteLiteral("</p>\r\n                <p id=\"itemStatus\">Status: ");
            EndContext();
            BeginContext(742, 12, false);
#line 22 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                      Write(Model.Status);

#line default
#line hidden
            EndContext();
            BeginContext(754, 45, true);
            WriteLiteral("</p>\r\n                <p id=\"itemType\">Type: ");
            EndContext();
            BeginContext(800, 10, false);
#line 23 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                  Write(Model.Type);

#line default
#line hidden
            EndContext();
            BeginContext(810, 53, true);
            WriteLiteral("</p>\r\n                <p id=\"itemLocation\">Location: ");
            EndContext();
            BeginContext(864, 21, false);
#line 24 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                          Write(Model.CurrentLocation);

#line default
#line hidden
            EndContext();
            BeginContext(885, 8, true);
            WriteLiteral("</p>\r\n\r\n");
            EndContext();
#line 26 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                  
                    if (Model.Status == "Checked Out")
                    {

#line default
#line hidden
            BeginContext(992, 59, true);
            WriteLiteral("                        <p id=\"itemPatron\">Checked Out By: ");
            EndContext();
            BeginContext(1052, 16, false);
#line 29 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                                      Write(Model.PatronName);

#line default
#line hidden
            EndContext();
            BeginContext(1068, 63, true);
            WriteLiteral("</p>\r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(1131, 136, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc80f7f38075b0e926a911838eceb24281e0c95c11032", async() => {
                BeginContext(1255, 8, true);
                WriteLiteral("Check In");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 31 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                                                                                                            WriteLiteral(Model.AssetId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1267, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(1297, 135, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc80f7f38075b0e926a911838eceb24281e0c95c13847", async() => {
                BeginContext(1418, 10, true);
                WriteLiteral("Place Hold");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 32 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                                                                                                         WriteLiteral(Model.AssetId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1432, 32, true);
            WriteLiteral("\r\n                        </p>\r\n");
            EndContext();
#line 34 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                    }
                    if (Model.Status == "Available")
                    {

#line default
#line hidden
            BeginContext(1564, 57, true);
            WriteLiteral("                        <p>\r\n                            ");
            EndContext();
            BeginContext(1621, 135, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc80f7f38075b0e926a911838eceb24281e0c95c17040", async() => {
                BeginContext(1743, 9, true);
                WriteLiteral("Check Out");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 38 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                                                                                                          WriteLiteral(Model.AssetId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1756, 32, true);
            WriteLiteral("\r\n                        </p>\r\n");
            EndContext();
#line 40 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                    }
                    if (Model.Status == "Lost")
                    {

#line default
#line hidden
            BeginContext(1883, 140, true);
            WriteLiteral("                        <p>This item has been lost. It cannot be checked out.</p>\r\n                        <p>\r\n                            ");
            EndContext();
            BeginContext(2023, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bc80f7f38075b0e926a911838eceb24281e0c95c20313", async() => {
                BeginContext(2148, 15, true);
                WriteLiteral("Mark Item Found");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                                                                                                             WriteLiteral(Model.AssetId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2167, 32, true);
            WriteLiteral("\r\n                        </p>\r\n");
            EndContext();
#line 47 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                    }
                

#line default
#line hidden
            BeginContext(2241, 236, true);
            WriteLiteral("            </div>\r\n            <div class=\"col-md-4 detailInfo\">\r\n                <table class=\"table\">\r\n                    <tr>\r\n                        <td class=\"itemLabel\">ISBN:</td>\r\n                        <td class=\"itemValue\">");
            EndContext();
            BeginContext(2478, 10, false);
#line 54 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                         Write(Model.ISBN);

#line default
#line hidden
            EndContext();
            BeginContext(2488, 176, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"itemLabel\">Replacement Cost:</td>\r\n                        <td class=\"itemValue\">");
            EndContext();
            BeginContext(2665, 10, false);
#line 58 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                         Write(Model.Cost);

#line default
#line hidden
            EndContext();
            BeginContext(2675, 171, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td class=\"itemLabel\">Call Number:</td>\r\n                        <td class=\"itemValue\">");
            EndContext();
            BeginContext(2847, 21, false);
#line 62 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                                         Write(Model.DeweyCallNumber);

#line default
#line hidden
            EndContext();
            BeginContext(2868, 529, true);
            WriteLiteral(@"</td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-lg-6"">
            <h4>Checkout History</h4>
            <table class=""table table-bordered table-hover"">
                <thead>
                    <tr>
                        <th>Date Loaned</th>
                        <th>Date Returned</th>
                        <th>Card Id</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 80 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                     foreach (var checkout in @Model.CheckoutHistory)
                    {

#line default
#line hidden
            BeginContext(3491, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3588, 19, false);
#line 84 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                           Write(checkout.CheckedOut);

#line default
#line hidden
            EndContext();
            BeginContext(3607, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3711, 18, false);
#line 87 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                           Write(checkout.CheckedIn);

#line default
#line hidden
            EndContext();
            BeginContext(3729, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(3833, 23, false);
#line 90 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                           Write(checkout.LibraryCard.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3856, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 93 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                    }

#line default
#line hidden
            BeginContext(3947, 411, true);
            WriteLiteral(@"                </tbody>
            </table>
        </div>
        <div class=""col-lg-6"">
            <h4>Current Holds</h4>
            <table class=""table table-bordered table-hover "">
                <thead>
                    <tr>
                        <th>Hold Placed</th>
                        <th>Patron</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 107 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                     foreach (var hold in @Model.CurrentHolds)
                    {

#line default
#line hidden
            BeginContext(4445, 96, true);
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4542, 15, false);
#line 111 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                           Write(hold.HoldPlaced);

#line default
#line hidden
            EndContext();
            BeginContext(4557, 103, true);
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
            EndContext();
            BeginContext(4661, 15, false);
#line 114 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                           Write(hold.PatronName);

#line default
#line hidden
            EndContext();
            BeginContext(4676, 68, true);
            WriteLiteral("\r\n                            </td>\r\n                        </tr>\r\n");
            EndContext();
#line 117 "C:\Dev\LibraryManagement\LibraryManagement\Views\Catalog\Detail.cshtml"
                    }

#line default
#line hidden
            BeginContext(4767, 88, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<LibraryManagement.Models.Catalog.AssetDetailModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

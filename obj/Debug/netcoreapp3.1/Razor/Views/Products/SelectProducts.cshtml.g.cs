#pragma checksum "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8b51211a8c52898f1a5ebb80bce8332dc91a31d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_SelectProducts), @"mvc.1.0.view", @"/Views/Products/SelectProducts.cshtml")]
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
#line 1 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\_ViewImports.cshtml"
using CheckSeparatorMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\_ViewImports.cshtml"
using CheckSeparatorMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b51211a8c52898f1a5ebb80bce8332dc91a31d6", @"/Views/Products/SelectProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"049e696212ad5ee7eb78debbbf094036487c45f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_SelectProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckSeparatorMVC.Models.ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ConfirmSelectedProducts", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Products", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
  
    ViewData["Title"] = "Select Products";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Products</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b51211a8c52898f1a5ebb80bce8332dc91a31d64940", async() => {
                WriteLiteral(@"

    <h3>Type your name please.</h3>

    <label>Name</label>
    <input type=""text"" name=""model.userName"" />

    <h3>Select products from the list.</h3>

    <table>
        <thead>
            <tr>
                <th>
                    Name
                </th>
                <th>
                    Price
                </th>
                <th>
                    Amount
                </th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 32 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
             if (Model.Products is null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p class=\"ModelEmpty\">\r\n                    There is no products!\r\n                </p>\r\n");
#nullable restore
#line 37 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                 for (int i = 0; i < Model.Products.Count; i++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Price));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"checkbox\"");
                BeginWriteAttribute("name", " name=\"", 1512, "\"", 1547, 3);
                WriteAttributeValue("", 1519, "model.Products[", 1519, 15, true);
#nullable restore
#line 53 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1534, i, 1534, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1536, "].IsChecked", 1536, 11, true);
                EndWriteAttribute();
                WriteLiteral(" value=\"true\" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1614, "\"", 1644, 3);
                WriteAttributeValue("", 1621, "model.Products[", 1621, 15, true);
#nullable restore
#line 54 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1636, i, 1636, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1638, "].Name", 1638, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1645, "\"", 1676, 1);
#nullable restore
#line 54 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1653, Model.Products[i].Name, 1653, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1730, "\"", 1761, 3);
                WriteAttributeValue("", 1737, "model.Products[", 1737, 15, true);
#nullable restore
#line 55 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1752, i, 1752, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1754, "].Price", 1754, 7, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1762, "\"", 1794, 1);
#nullable restore
#line 55 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1770, Model.Products[i].Price, 1770, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1848, "\"", 1880, 3);
                WriteAttributeValue("", 1855, "model.Products[", 1855, 15, true);
#nullable restore
#line 56 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1870, i, 1870, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1872, "].Amount", 1872, 8, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1881, "\"", 1914, 1);
#nullable restore
#line 56 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1889, Model.Products[i].Amount, 1889, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1968, "\"", 1996, 3);
                WriteAttributeValue("", 1975, "model.Products[", 1975, 15, true);
#nullable restore
#line 57 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1990, i, 1990, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1992, "].Id", 1992, 4, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1997, "\"", 2033, 1);
#nullable restore
#line 57 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 2005, Model.Products[i].ProductId, 2005, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 60 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "C:\GitHub\CheckSeparatorMVC\Check-Separator\Views\Products\SelectProducts.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n    <input type=\"submit\" value=\"Confirm\" class=\"btn btn-primary\" />\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8b51211a8c52898f1a5ebb80bce8332dc91a31d614073", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckSeparatorMVC.Models.ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

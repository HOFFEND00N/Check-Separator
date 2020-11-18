#pragma checksum "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "616615160a4a70ca9cc8ab4bef8192e5734add7e"
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
#line 1 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\_ViewImports.cshtml"
using CheckSeparatorMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\_ViewImports.cshtml"
using CheckSeparatorMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"616615160a4a70ca9cc8ab4bef8192e5734add7e", @"/Views/Products/SelectProducts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"049e696212ad5ee7eb78debbbf094036487c45f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_SelectProducts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CheckSeparatorMVC.Models.Check>
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
#line 2 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
  
    ViewData["Title"] = "Select Products";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Products</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "616615160a4a70ca9cc8ab4bef8192e5734add7e4985", async() => {
                WriteLiteral(@"

    <h3>Type your name please.</h3>

    <label>Name</label>
    <input type=""text"" name=""userName"" />

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
#line 32 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
             if (Model.Products is null)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <p class=\"ModelEmpty\">\r\n                    There is no products!\r\n                </p>\r\n");
#nullable restore
#line 37 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                 for (int i = 0; i < Model.Products.Count; i++)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 44 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 47 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Price));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 50 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                       Write(Html.DisplayFor(modelItem => Model.Products[i].Amount));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <input type=\"checkbox\"");
                BeginWriteAttribute("name", " name=\"", 1495, "\"", 1530, 3);
                WriteAttributeValue("", 1502, "model.Products[", 1502, 15, true);
#nullable restore
#line 53 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1517, i, 1517, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1519, "].IsChecked", 1519, 11, true);
                EndWriteAttribute();
                WriteLiteral(" value=\"true\" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1597, "\"", 1627, 3);
                WriteAttributeValue("", 1604, "model.Products[", 1604, 15, true);
#nullable restore
#line 54 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1619, i, 1619, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1621, "].Name", 1621, 6, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1628, "\"", 1659, 1);
#nullable restore
#line 54 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1636, Model.Products[i].Name, 1636, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1713, "\"", 1744, 3);
                WriteAttributeValue("", 1720, "model.Products[", 1720, 15, true);
#nullable restore
#line 55 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1735, i, 1735, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1737, "].Price", 1737, 7, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1745, "\"", 1777, 1);
#nullable restore
#line 55 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1753, Model.Products[i].Price, 1753, 24, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1831, "\"", 1863, 3);
                WriteAttributeValue("", 1838, "model.Products[", 1838, 15, true);
#nullable restore
#line 56 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1853, i, 1853, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1855, "].Amount", 1855, 8, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1864, "\"", 1897, 1);
#nullable restore
#line 56 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1872, Model.Products[i].Amount, 1872, 25, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 1951, "\"", 1986, 3);
                WriteAttributeValue("", 1958, "model.Products[", 1958, 15, true);
#nullable restore
#line 57 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1973, i, 1973, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 1975, "].ProductId", 1975, 11, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 1987, "\"", 2023, 1);
#nullable restore
#line 57 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 1995, Model.Products[i].ProductId, 1995, 28, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\"");
                BeginWriteAttribute("name", " name=\"", 2077, "\"", 2110, 3);
                WriteAttributeValue("", 2084, "model.Products[", 2084, 15, true);
#nullable restore
#line 58 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 2099, i, 2099, 2, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2101, "].CheckId", 2101, 9, true);
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 2111, "\"", 2145, 1);
#nullable restore
#line 58 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 2119, Model.Products[i].CheckId, 2119, 26, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 61 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 61 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </tbody>\r\n    </table>\r\n\r\n    <input type=\"hidden\" name=\"model.OwnerName\"");
                BeginWriteAttribute("value", " value=\"", 2324, "\"", 2348, 1);
#nullable restore
#line 66 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 2332, Model.OwnerName, 2332, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input type=\"hidden\" name=\"model.CheckId\"");
                BeginWriteAttribute("value", " value=\"", 2399, "\"", 2421, 1);
#nullable restore
#line 67 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\SelectProducts.cshtml"
WriteAttributeValue("", 2407, Model.CheckId, 2407, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <input type=\"submit\" value=\"Confirm\" class=\"btn btn-primary\" />\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "616615160a4a70ca9cc8ab4bef8192e5734add7e16228", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CheckSeparatorMVC.Models.Check> Html { get; private set; }
    }
}
#pragma warning restore 1591

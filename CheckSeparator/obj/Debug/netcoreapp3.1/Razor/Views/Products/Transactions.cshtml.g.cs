#pragma checksum "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6ddb913c23f3a3304f9767b7f665ed64a5eeddd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Transactions), @"mvc.1.0.view", @"/Views/Products/Transactions.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6ddb913c23f3a3304f9767b7f665ed64a5eeddd", @"/Views/Products/Transactions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"049e696212ad5ee7eb78debbbf094036487c45f6", @"/Views/_ViewImports.cshtml")]
    public class Views_Products_Transactions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CheckSeparatorMVC.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
  
    ViewData["Title"] = "Transactions";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List of transactions</h1>\r\n\r\n<table>\r\n    <thead>\r\n        <tr>\r\n            <th> Sender </th>\r\n            <th> Transacton size </th>\r\n            <th> Recipient </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 17 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 21 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
               Write(item.Sender);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 24 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
               Write(item.TransactionSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 27 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
               Write(item.Recipient);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 30 "C:\Users\Ivan\source\repos\Check-Separator\CheckSeparator\Views\Products\Transactions.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CheckSeparatorMVC.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4064ec2e9c068dac9c1b9ab8b75c2a713f02133a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GeneratedTickets_Details), @"mvc.1.0.view", @"/Views/GeneratedTickets/Details.cshtml")]
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
#line 1 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\_ViewImports.cshtml"
using SaleTheaterTickets;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\_ViewImports.cshtml"
using SaleTheaterTickets.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\_ViewImports.cshtml"
using ReflectionIT.Mvc.Paging;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4064ec2e9c068dac9c1b9ab8b75c2a713f02133a", @"/Views/GeneratedTickets/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"137ed6948205a88f9f2990e431f5993eb7f5fedb", @"/Views/_ViewImports.cshtml")]
    public class Views_GeneratedTickets_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GeneratedTicketViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminSalesTicketsReport", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Detalhes</h1>\r\n\r\n<div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-md-2\">\r\n            ");
#nullable restore
#line 9 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 12 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 15 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 18 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.BirthDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 21 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ticket.Piece.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 24 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ticket.Piece.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 27 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ticket.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 30 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ticket.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 33 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 36 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Seat));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 39 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Ticket.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 42 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ticket.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 45 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 48 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Total));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 51 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FormOfPayment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 54 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.FormOfPayment));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 57 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.NeedyChild));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 60 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.NeedyChild));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-6\">\r\n            ");
#nullable restore
#line 63 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-6\">\r\n            ");
#nullable restore
#line 66 "C:\projetos\SaleTheaterTickets\SaleTheaterTickets\SaleTheaterTickets\Views\GeneratedTickets\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4064ec2e9c068dac9c1b9ab8b75c2a713f02133a11414", async() => {
                WriteLiteral("Voltar ao relatório");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4064ec2e9c068dac9c1b9ab8b75c2a713f02133a12993", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GeneratedTicketViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

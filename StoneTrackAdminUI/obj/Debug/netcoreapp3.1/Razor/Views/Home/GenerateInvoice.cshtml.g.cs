#pragma checksum "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4115d478fba0a00af39738d5667df299405b20b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GenerateInvoice), @"mvc.1.0.view", @"/Views/Home/GenerateInvoice.cshtml")]
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
#line 1 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\_ViewImports.cshtml"
using StoneTrackApi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\_ViewImports.cshtml"
using StoneTrackApi.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4115d478fba0a00af39738d5667df299405b20b", @"/Views/Home/GenerateInvoice.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68bda8c060d4560485f98aded4d7493523da8388", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GenerateInvoice : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<StoneTrackAdmin.Models.InvoiceModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/logo1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Your Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("height", new global::Microsoft.AspNetCore.Html.HtmlString("100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
  
    ViewData["Title"] = "GenerateInvoice";
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<style>
    .top_rw {
        background-color: #f4f4f4;
    }

    button {
        padding: 5px 10px;
        font-size: 14px;
    }

    .invoice-box {
        max-width: 750px;
        margin: auto;
        padding: 10px;
        border: 2px solid #000000;
        border-radius: 15px;
        /*box-shadow: 0 0 10px rgba(0, 0, 0, .15);*/
        font-size: 5px;
        line-height: 24px;
        font-family: 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
        color: #555;
    }

        .invoice-box table {
            width: 100%;
            line-height: inherit;
            text-align: left;
            border-bottom: solid 1px #ccc;
        }

            .invoice-box table td {
                padding: 5px;
                vertical-align: middle;
            }

            .invoice-box table tr td:nth-child(2) {
                text-align: right;
            }

            .invoice-box table tr.top table td {
                padding-bottom: ");
            WriteLiteral(@"20px;
                text-align: left;
            }

                .invoice-box table tr.top table td.title {
                    font-size: 45px;
                    line-height: 45px;
                    color: #333;
                }

            .invoice-box table tr.information table td {
                padding-bottom: 40px;
            }

            .invoice-box table tr.heading td {
                background: #eee;
                border-bottom: 1px solid #ddd;
                font-weight: bold;
                font-size: 12px;
            }

            .invoice-box table tr.details td {
                padding-bottom: 20px;
            }

            .invoice-box table tr.item td {
                border-bottom: 1px solid #eee;
            }

            .invoice-box table tr.item.last td {
                border-bottom: none;
            }

            .invoice-box table tr.total td:nth-child(2) {
                border-top: 2px solid #eee;
                f");
            WriteLiteral(@"ont-weight: bold;
            }

    .rtl {
        direction: rtl;
        font-family: Tahoma, 'Helvetica Neue', 'Helvetica', Helvetica, Arial, sans-serif;
    }

        .rtl table {
            text-align: right;
        }

            .rtl table tr td:nth-child(2) {
                text-align: left;
            }
</style>

<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js""></script>

<div class=""invoice-box"">
    <table cellpadding=""0"" cellspacing=""0"">

        <tr class=""top"">
            <td colspan=""5"">
                <table>
                    <tr>
                        <td style=""vertical-align: top;"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "a4115d478fba0a00af39738d5667df299405b20b7655", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </td>
                        <td style=""padding-left: 10px;"">
                            <b><h2 style=""margin: 0;"">R INSPRIO IT PRIVATE LIMITED </h2></b>
                            GSTIN: 09AAHCR4278D1Z6<br>
                            E-160, Sector 63, Gautambuddha Nagar, <br>
                            Uttar Pradesh - 201301<br>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr class=""information"">
            <td colspan=""3"">
                <table>
                    <tr>
                        <td colspan=""2"">
                            <b><h3>Buyer (Bill To), </h3> </b> 
                            <b><h3> ");
#nullable restore
#line 128 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                               Write(Model.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h3> </b> \r\n                            Address: ");
#nullable restore
#line 129 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                                Write(Model.CustomerAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                            GST No: ");
#nullable restore
#line 130 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                               Write(Model.GSTNO);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        </td>\r\n                        <td>\r\n                            Invoice: RIIPL/24-25/");
#nullable restore
#line 133 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                                            Write(Model.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br>\r\n                            Date: ");
#nullable restore
#line 134 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                             Write(Model.UpdatedDate.ToString("dd MMM yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                            Vehicle No: ");
#nullable restore
#line 135 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                                   Write(Model.VehicleNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br>
                            HSV/SAC: 25171090
                            <br>
                            <br>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <td colspan=""3"">
            <table cellspacing=""0px"" cellpadding=""2px"">
                <tr class=""heading"">
                    <td style=""width:25%;"">
                        SI No.
                    </td>
                    <td style=""width:30%; text-align:center;"">
                        DESCRIPTION OF GOODS
                    </td>
                    <td style=""width:10%; text-align:center;"">
                        QTY.
                    </td>
                    <td style=""width:10%; text-align:right;"">
                        PRICE (INR)
                    </td>
                    <td style=""width:15%; text-align:right;"">
                        AMOUNT
                    </td>
                </tr>
                <tr class=""ite");
            WriteLiteral("m\">\r\n                    <td style=\"width:25%;\">\r\n                        1\r\n                    </td>\r\n                    <td style=\"width:31%; text-align:center;\">\r\n                        R Stone Chips - ");
#nullable restore
#line 168 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                                   Write(Model.MaterialType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width:45%; text-align:center;\">\r\n                         ");
#nullable restore
#line 171 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                    Write(Model.ActualWeight);

#line default
#line hidden
#nullable disable
            WriteLiteral(" MT\r\n                    </td>\r\n                    <td style=\"width:10%; text-align:right;\">\r\n                        ₹");
#nullable restore
#line 174 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                    Write(Model.WeightPer);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td style=\"width:15%; text-align:right;\">\r\n                        ₹");
#nullable restore
#line 177 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                    Write(Model.ActualAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n\r\n\r\n");
            WriteLiteral(@"                <tr class=""item"">
                    <td style=""width:25%;""> </td>
                    <td style=""width:10%; text-align:center;""></td>
                    <td style=""width:10%; text-align:center;""></td>
                    <td style=""width:20%; text-align:right; padding-right:10px;"">
                        IGST (5%):<br>
                        <b>Net Amount</b>
                    </td>
                    <td style=""width:25%; text-align:right; padding-right:10px;"">
                        ₹");
#nullable restore
#line 201 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                    Write(Model.GSTAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral("<br>\r\n                        <b>₹");
#nullable restore
#line 202 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\Home\GenerateInvoice.cshtml"
                       Write(Model.NetAmount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</b>
                    </td>
                </tr>
            </table>
        </td>
    </table>

    <br>
    <br>
    <br>
    <br>

    <tr>
        <td colspan=""3"">
            <table cellspacing=""0px"" cellpadding=""2px"">
                <tr>
                    <td width=""50%"">
                        <b>Notice:</b>
                    </td>
                    <br>
                    <td>
                        Signature Of R INSPRIO <br>
                        IT PRIVATE LIMITED
                    </td>
                </tr>
            </table>
        </td>
    </tr>

    <tr>
        <td colspan=""3"">
            <table cellspacing=""0px"" cellpadding=""2px"">
                <tr>
                    <td width=""50%"">
                        <b>Terms:</b>
                    </td>

                    <td>
                        Receiver Signature
                    </td>
                </tr>
            </table>
        </td>
    </tr>

</div>

 <s");
            WriteLiteral("cript> \r\n     $(document).ready(function () { \r\n      window.print(); \r\n       setTimeout(function () { \r\n           window.close();\r\n       }, 1000);\r\n     }); \r\n </script> \r\n ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<StoneTrackAdmin.Models.InvoiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

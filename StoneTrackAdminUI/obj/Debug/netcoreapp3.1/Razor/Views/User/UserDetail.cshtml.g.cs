#pragma checksum "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cab198dd6ef1edb7b21f0f5057463ae02553c19e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserDetail), @"mvc.1.0.view", @"/Views/User/UserDetail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cab198dd6ef1edb7b21f0f5057463ae02553c19e", @"/Views/User/UserDetail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68bda8c060d4560485f98aded4d7493523da8388", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserDetail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<StoneTrackAdmin.Models.UserModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/listing/1.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
  
    ViewData["Title"] = "User Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""sb2-2"">
    <div class=""sb2-2-2"">
        <ul>
            <li>
                <a href=""/Home/Index""><i class=""fa fa-home"" aria-hidden=""true""></i> Home</a>
            </li>
            <li class=""active-bre"">
                <a href=""/User/UserDetail""> User Details</a>
            </li>
        </ul>
    </div>
    <div class=""sb2-2-3"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""box-inn-sp"">
                    <div class=""inn-title"">
                        <h4>User Details</h4>
                        <a");
            BeginWriteAttribute("href", " href=\"", 732, "\"", 768, 1);
#nullable restore
#line 24 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 739, Url.Action("AddUser","User"), 739, 29, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-primary float-right"" style=""margin-left: 78%; margin-top: -34px;""> Add New User</a>
                    </div>

                    <div class=""tab-inn"">
                        <div class=""table-responsive table-desi"">
                            <table class=""table table-bordered nowrap"" id=""scroll-vert-hor"">
                                <thead>
                                    <tr>
                                        <th>User</th>
                                        <th>User Id</th>
                                        <th>Name</th>
                                        <th>User Name</th>
                                        <th>Password</th>
                                        <th>Mobile No</th>
                                        <th>Email Address</th>
                                        <th>User Type</th>
                                        <th>Edit</th>
                                        <th>Delete</th>
                       ");
            WriteLiteral("             </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 45 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                     foreach (var item in Model)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n");
            WriteLiteral("                                             <td>\r\n                                                 <span class=\"list-img\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "cab198dd6ef1edb7b21f0f5057463ae02553c19e6843", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n                                             </td>\r\n                                            <td>");
#nullable restore
#line 54 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                ");
#nullable restore
#line 56 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </td>\r\n                                            <td>");
#nullable restore
#line 58 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 59 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.PasswordView);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 60 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.MobileNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 61 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.EmailAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 62 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                           Write(item.UserType);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("href", " href=\"", 3166, "\"", 3220, 1);
#nullable restore
#line 64 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 3173, Url.Action("AddUser","User",new {item.UserId}), 3173, 47, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-pencil-square-o\" aria-hidden=\"true\"></i></a>\r\n                                            </td>\r\n                                            <td>\r\n                                                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 3435, "\"", 3474, 3);
            WriteAttributeValue("", 3445, "DeleteProject(\'", 3445, 15, true);
#nullable restore
#line 67 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
WriteAttributeValue("", 3460, item.UserId, 3460, 12, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3472, "\')", 3472, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-trash-o\" aria-hidden=\"true\"></i></a>\r\n                                            </td>\r\n                                        </tr>\r\n");
#nullable restore
#line 70 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
                        </div>
                        <br /><br />
                        <div class=""row mt-5 ml-3 mb-5"">
                            <div class=""exportList"">
                                <button onclick=""downloadExcel()"" class=""btn btn-success btn-sm""><i class=""fa fa-file-excel-o""></i> Save as XLSX</button>
                                <button onclick=""downloadPDF()"" class=""btn btn-success btn-sm""><i class=""fa fa-file-pdf-o""></i> Save as PDF</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>


<script>
    new DataTable('#scroll-vert-hor', {
        pagingType: 'simple_numbers'
    });
</script>

");
#nullable restore
#line 95 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
 if (TempData["SuccessMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n            window.onload = function () {\r\n                alert(\"");
#nullable restore
#line 99 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
                  Write(TempData["SuccessMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\");\r\n            };\r\n    </script>\r\n");
#nullable restore
#line 102 "H:\Stone Track All Project\StoneTrackAdmin\StoneTrackAdminUI\Views\User\UserDetail.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    function DeleteProject(idd) {
        swal({
            title: ""Are you sure?"",
            text: ""Once deleted, you will not be able to recover this data!"",
            icon: ""warning"",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $.ajax({
                        url: ""/User/DeleteUser"",
                        method: ""get"",
                        contentType: ""application/json"",
                        data: {
                            UserId: idd
                        },
                        success: function (result) {
                            if (result.status == true) {
                                location.href = ""/User/UserDetail"";
                            }
                            else {
                                toastr.error(result.msg);
                            }
                        },
                        er");
            WriteLiteral(@"ror: function (err) {

                            if (err.status == '401') {
                                location.href = ""/"";
                            }
                        }
                    });
                } else {
                    swal(""Your data is safe!"");
                }
            });
    };
</script>

<script src=""https://cdnjs.cloudflare.com/ajax/libs/xlsx/0.17.0/xlsx.full.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jspdf/2.5.0/jspdf.umd.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/jspdf-autotable/3.5.16/jspdf.plugin.autotable.min.js""></script>
<script src=""https://cdnjs.cloudflare.com/ajax/libs/FileSaver.js/2.0.5/FileSaver.min.js""></script>

<script>
    function cloneTableWithoutEditDelete() {
        debugger
        const originalTable = document.getElementById('scroll-vert-hor');
        const clonedTable = originalTable.cloneNode(true);
        const clonedHeaderRow = clonedTable.querySelector('t");
            WriteLiteral(@"head tr');
        clonedHeaderRow.deleteCell(0);
        clonedHeaderRow.deleteCell(-1);
        clonedHeaderRow.deleteCell(-1);
        const clonedBodyRows = clonedTable.querySelectorAll('tbody tr');
        clonedBodyRows.forEach(row => {
            row.deleteCell(0);
            row.deleteCell(-1);
            row.deleteCell(-1);
        });
        return clonedTable;
    }

    function downloadExcel() {
        debugger
        const table = cloneTableWithoutEditDelete();
        const wb = XLSX.utils.table_to_book(table, { sheet: ""Sheet1"" });
        const wbout = XLSX.write(wb, { bookType: 'xlsx', type: 'array' });
        saveAs(new Blob([wbout], { type: ""application/octet-stream"" }), 'User_List.xlsx');
    }

    async function downloadPDF() {
        const table = cloneTableWithoutEditDelete();
        const { jsPDF } = window.jspdf;
        const doc = new jsPDF();
        const pageWidth = doc.internal.pageSize.getWidth();
        const headerText = 'User List';
    ");
            WriteLiteral(@"    const textWidth = doc.getTextWidth(headerText);
        const x = (pageWidth - textWidth) / 2;
        doc.autoTable({
            html: table,
            didDrawPage: function (data) {
                doc.text(headerText, x, 10);
            },
            margin: { top: 20 }
        });
        doc.save('User_List.pdf');
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<StoneTrackAdmin.Models.UserModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

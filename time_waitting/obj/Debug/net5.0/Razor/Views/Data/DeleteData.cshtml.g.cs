#pragma checksum "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf45764fd3bb6e8edbd707b580e3d0bf3ef384ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Data_DeleteData), @"mvc.1.0.view", @"/Views/Data/DeleteData.cshtml")]
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
#line 1 "D:\time_waitting\time_waitting\Views\_ViewImports.cshtml"
using time_waitting;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\time_waitting\time_waitting\Views\_ViewImports.cshtml"
using time_waitting.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cf45764fd3bb6e8edbd707b580e3d0bf3ef384ce", @"/Views/Data/DeleteData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"689f38ef9143bbbf445bb08f4f741d43b8143de5", @"/Views/_ViewImports.cshtml")]
    public class Views_Data_DeleteData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<time_waitting.Models.timeWaittingModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Data", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteData", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
  
    IEnumerable<timeWaittingModel> displaydata = ViewData["ShowData"] as IEnumerable<timeWaittingModel>;
    ViewData["Title"] = "Data";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card mt-5"">
    <div class=""card-header"">
        <h4 class=""card-title"">รายละเอียด</h4>
    </div>
    <div class=""card-body"">
        <div class=""data-table-area"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                        <div class=""data-table-list"">
                            <!--<div class=""basic-tb-hd"">
                            <h2>รายละเอียดข้อมูล</h2>-->
");
            WriteLiteral("                            <!--</div>-->\r\n                            <div class=\"table-responsive\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf45764fd3bb6e8edbd707b580e3d0bf3ef384ce5600", async() => {
                WriteLiteral(@"
                                    <table id=""table1"" class=""table table-striped"">
                                        <thead>
                                            <tr>
                                                <th>ลบ</th>
                                                <th>หน่วยงาน</th>
                                                <th>ปีงบประมาณ</th>
                                                <th>เดือน</th>
                                                <th>วันที่นำเข้า</th>
                                                <th>ประเภทผู้ป่วย</th>
                                                <th>รายละเอียด</th>
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 37 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                             foreach (var item in displaydata)
                                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                <tr>\r\n                                                    <td><input");
                BeginWriteAttribute("id", " id=\"", 2126, "\"", 2141, 1);
#nullable restore
#line 40 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
WriteAttributeValue("", 2131, item.t_id, 2131, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" type=\"checkbox\" name=\"t_id\"");
                BeginWriteAttribute("value", " value=\"", 2170, "\"", 2188, 1);
#nullable restore
#line 40 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
WriteAttributeValue("", 2178, item.t_id, 2178, 10, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-check\" /></td>\r\n                                                    <td>");
#nullable restore
#line 41 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                   Write(item.hname);

#line default
#line hidden
#nullable disable
                WriteLiteral(" [");
#nullable restore
#line 41 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                                Write(item.t_hcode);

#line default
#line hidden
#nullable disable
                WriteLiteral("]</td>\r\n                                                    <td>");
#nullable restore
#line 42 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                   Write(item.t_year);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 43 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                   Write(item.m_name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 44 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                   Write(item.t_date);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                                    <td>\r\n");
#nullable restore
#line 46 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                         if (item.type == 1)
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <p>ผู้ป่วยเก่า </p>\r\n");
#nullable restore
#line 49 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                        }
                                                        else
                                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                            <p>ผู้ป่วยใหม่</p>\r\n");
#nullable restore
#line 53 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    </td>\r\n                                                    <td>\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "cf45764fd3bb6e8edbd707b580e3d0bf3ef384ce10680", async() => {
                    WriteLiteral("รายละเอียด");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#nullable restore
#line 58 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                             WriteLiteral(item.t_id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                    </td>\r\n                                                </tr>\r\n");
#nullable restore
#line 61 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        </tbody>\r\n                                        <tfoot>\r\n                                            <tr>\r\n");
#nullable restore
#line 65 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                 if (ViewData["status"].ToString() == "2")
                                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                                    <th>หน่วยงาน</th>\r\n");
#nullable restore
#line 68 "D:\time_waitting\time_waitting\Views\Data\DeleteData.cshtml"
                                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                                <th>ปีงบประมาณ</th>
                                                <th>เดือน</th>
                                                <th>วันที่นำเข้า</th>
                                                <th>รายละเอียด</th>
                                            </tr>
                                        </tfoot>
                                    </table>
                                    <p></p> <input type=""submit"" value=""ลบข้อมูล"" class=""btn btn-success"" />
                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<time_waitting.Models.timeWaittingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

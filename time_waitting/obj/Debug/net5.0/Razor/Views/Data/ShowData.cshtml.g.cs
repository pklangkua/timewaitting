#pragma checksum "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0b04d6218b55c4678599f14aec779774b1a0ba9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Data_ShowData), @"mvc.1.0.view", @"/Views/Data/ShowData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0b04d6218b55c4678599f14aec779774b1a0ba9", @"/Views/Data/ShowData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"689f38ef9143bbbf445bb08f4f741d43b8143de5", @"/Views/_ViewImports.cshtml")]
    public class Views_Data_ShowData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<time_waitting.Models.timeWaittingModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Data", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
  
    IEnumerable<timeWaittingModel> displaydata = ViewData["ShowData"] as IEnumerable<timeWaittingModel>;
    ViewData["Title"] = "Data";


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""card mt-5"">
    <div class=""card-header"">
        <h4 class=""card-title"">??????????????????????????????</h4>
    </div>
    <div class=""card-body"">
        <div class=""data-table-area"">
            <div class=""container"">
                <div class=""row"">
                    <div class=""col-lg-12 col-md-12 col-sm-12 col-xs-12"">
                        <div class=""data-table-list"">
                            <!--<div class=""basic-tb-hd"">
                            <h2>????????????????????????????????????????????????</h2>-->
");
            WriteLiteral(@"                            <!--</div>-->
                            <div class=""table-responsive"">
                                <table id=""table1"" class=""table table-striped"">
                                    <thead>
                                        <tr>
");
#nullable restore
#line 26 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                             if (ViewData["status"].ToString() == "2")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>????????????????????????</th>\r\n");
#nullable restore
#line 29 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <th>??????????????????????????????</th>
                                            <th>???????????????</th>
                                            <th>????????????????????????????????????</th>
                                            <th>???????????????????????????????????????</th>
                                            <th>??????????????????????????????</th>
");
#nullable restore
#line 35 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                             if (ViewData["status"].ToString() == "2")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>????????????????????????????????????</th>\r\n");
#nullable restore
#line 38 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 42 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                         foreach (var item in displaydata)
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <tr>\r\n");
#nullable restore
#line 45 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                 if (ViewData["status"].ToString() == "2")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <th>");
#nullable restore
#line 47 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                   Write(item.hname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" [");
#nullable restore
#line 47 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                                Write(item.t_hcode);

#line default
#line hidden
#nullable disable
            WriteLiteral("]</th>\r\n");
#nullable restore
#line 48 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <td>");
#nullable restore
#line 49 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                               Write(item.t_year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 50 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                               Write(item.m_name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>");
#nullable restore
#line 51 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                               Write(item.t_date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                <td>\r\n");
#nullable restore
#line 53 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                     if (item.type == 1)
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <p>????????????????????????????????? </p>\r\n");
#nullable restore
#line 56 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                    }
                                                    else
                                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                        <p>?????????????????????????????????</p>\r\n");
#nullable restore
#line 60 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                </td>\r\n                                                <td>\r\n                                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0b04d6218b55c4678599f14aec779774b1a0ba911670", async() => {
                WriteLiteral("??????????????????????????????");
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
#line 65 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
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
            WriteLiteral("\r\n                                                </td>\r\n");
#nullable restore
#line 67 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                 if (ViewData["status"].ToString() == "2")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <td>\r\n");
#nullable restore
#line 75 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                         if (item.t_edit == 0)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <button type=\"button\" class=\"btn btn-danger btn-sm edit\" data-toggle=\"modal\"\r\n                                                                    data-target=\"#EditModal\"");
            BeginWriteAttribute("id", " id=\"", 4826, "\"", 4841, 1);
#nullable restore
#line 78 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
WriteAttributeValue("", 4831, item.t_id, 4831, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                ?????????????????????\r\n                                                            </button>\r\n");
#nullable restore
#line 81 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                        }
                                                        else if (item.t_edit == 1)
                                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                            <button type=\"button\" class=\"btn btn-success btn-sm edit\" data-toggle=\"modal\"\r\n                                                                    data-target=\"#EditModal\"");
            BeginWriteAttribute("id", " id=\"", 5422, "\"", 5437, 1);
#nullable restore
#line 85 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
WriteAttributeValue("", 5427, item.t_id, 5427, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                                ?????????????????????\r\n                                                            </button>\r\n");
#nullable restore
#line 88 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                                    </td>\r\n");
#nullable restore
#line 91 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            </tr>\r\n");
#nullable restore
#line 93 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    </tbody>\r\n                                    <tfoot>\r\n                                        <tr>\r\n");
#nullable restore
#line 97 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                             if (ViewData["status"].ToString() == "2")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>????????????????????????</th>\r\n");
#nullable restore
#line 100 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            <th>??????????????????????????????</th>
                                            <th>???????????????</th>
                                            <th>????????????????????????????????????</th>
                                            <th>??????????????????????????????</th>
");
#nullable restore
#line 105 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                             if (ViewData["status"].ToString() == "2")
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>????????????????????????????????????</th>\r\n");
#nullable restore
#line 108 "D:\time_waitting\time_waitting\Views\Data\ShowData.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tr>
                                    </tfoot>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0b04d6218b55c4678599f14aec779774b1a0ba919364", async() => {
                WriteLiteral(@"
    <div id=""EditModal"" class=""modal modal-child fade addNewRequestModal"" tabindex=""-1"" role=""dialog""
         aria-labelledby=""myLargeModalLabel"" aria-hidden=""true"" data-modal-parent=""#ViewDetailModal"">
        <div class=""modal-dialog modal-md"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"">?????????????????????????????????????????????</h4>
                </div>
                <div class=""modal-body"">
                    <select class=""form-control"" name=""t_edit"">
                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0b04d6218b55c4678599f14aec779774b1a0ba920207", async() => {
                    WriteLiteral("??????????????????????????????");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0b04d6218b55c4678599f14aec779774b1a0ba921459", async() => {
                    WriteLiteral("?????????????????????");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                    </select>
                    <div class=""modal-footer"">
                        <input type=""hidden"" name=""t_id"" id=""t_id"" />
                        <input type=""submit"" class=""btn btn-success"" value=""??????????????????"">
                        <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">?????????</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    $(document).ready(function () {

        $(""body"").on(""click"", "".edit"", function (event) {

            var uid = $(this).attr(""id"");
            $('#t_id').val(uid);
            //document.getElementById(""fullname"").innerHTML = $(this).attr(""fullname"");
        });

    });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<time_waitting.Models.timeWaittingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "84b907339b6842ad1cebaa47cab2e5cfa8e806b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_Report3), @"mvc.1.0.view", @"/Views/Report/Report3.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"84b907339b6842ad1cebaa47cab2e5cfa8e806b1", @"/Views/Report/Report3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"689f38ef9143bbbf445bb08f4f741d43b8143de5", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_Report3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SumpatienModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-select"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "t_year", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("t_year"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("this.form.submit()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Report3", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
  
    var displaydata = ViewData["Sumpoint"] as IEnumerable<DataPoint>;
    var displaydata2 = ViewData["Sumpoint_old"] as IEnumerable<DataPoint>;
    IEnumerable<hospModel> hosp = ViewData["hosp"] as IEnumerable<hospModel>;

    int oldyear = 2563;
    int years = (int)ViewData["Date2"];
    // int oldyear2 = 2562;
    int years2 = (int)ViewData["Date2"];


#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script>
    document.addEventListener('DOMContentLoaded', function () {
        Highcharts.chart('ChartNew', {
            data: {
                table: 'tableNew'
            },
            chart: {
                type: 'column'
            },
            title: {
                text: ''
            },
            yAxis: {
                allowDecimals: false,
                title: {
                    text: 'เวลาเฉลี่ย (นาที)'
                }
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.series.name + '</b><br/>' +
                        this.point.y + ' ' + this.point.name.toLowerCase();
                }
            }
        });
    });
</script><script>
    document.addEventListener('DOMContentLoaded', function () {
        Highcharts.chart('ChartOld', {
            data: {
                table: 'tableOld'
            },
            chart: {
                type: 'column'
            },");
            WriteLiteral(@"
            title: {
                text: ''
            },
            yAxis: {
                allowDecimals: false,
                title: {
                    text: 'เวลาเฉลี่ย (นาที)'
                }
            },
            tooltip: {
                formatter: function () {
                    return '<b>' + this.series.name + '</b><br/>' +
                        this.point.y + ' ' + this.point.name.toLowerCase();
                }
            }
        });
    });
</script>

<div class=""page-content"">
    <section class=""row"">
        <div class=""col-12 col-lg-12 "">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body px-3 py-4-5"">
                            <div class=""row"">
                                <div class=""card"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b907339b6842ad1cebaa47cab2e5cfa8e806b17880", async() => {
                WriteLiteral("\r\n                                        <div class=\"card-header\">\r\n                                            <h4>ค่าเฉลี่ยระยะเวลาบริการรายจุดบริการปีงบประมาณ </h4>\r\n                                            <p>");
#nullable restore
#line 80 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                          Write(ViewData["ReportPoint"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
                                            <div class=""row"">
                                                <div class=""col-md-6"">
                                                    <div class=""form-group row align-items-center"">
                                                        <div class=""col-lg-3 col-5"">
                                                            <label class=""control-label"">ปีงบประมาณ:</label>
                                                        </div>
                                                        <div class=""col-lg-9 col-7"">
                                                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b907339b6842ad1cebaa47cab2e5cfa8e806b19270", async() => {
                    WriteLiteral("\r\n                                                                ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b907339b6842ad1cebaa47cab2e5cfa8e806b19602", async() => {
                        WriteLiteral("ทั้งหมด");
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 90 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                                 while (oldyear <= years)
                                                                {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                                    ");
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "84b907339b6842ad1cebaa47cab2e5cfa8e806b111630", async() => {
#nullable restore
#line 92 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                                                      Write(years);

#line default
#line hidden
#nullable disable
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                                       WriteLiteral(years);

#line default
#line hidden
#nullable disable
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    WriteLiteral("\r\n");
#nullable restore
#line 93 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                                    years--;
                                                                }

#line default
#line hidden
#nullable disable
                    WriteLiteral("                                                            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#nullable restore
#line 88 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.t_year);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
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
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n</div>");
            WriteLiteral(@"
<div class=""page-content"">
    <section class=""row"">
        <div class=""col-12 col-lg-6 "">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body px-3 py-4-5"">
                            <div class=""row"">
                                <div class=""card-header"">
                                    <h4>ผู้ป่วยนอกใหม่</h4>
                                    <div id=""ChartNew"" style=""width:100%; height:400px;""></div>
                                </div>
                                <div class=""card-body"">
                                    <div class=""card-body"">
                                        <h4>รายละเอียด</h4>
                                        <p>ผู้ป่วยนอกใหม่</p>
                                        <table id=""tableNew"" class=""table table-striped"">
                                            <thead>
                                                <tr>
             ");
            WriteLiteral("                                       <th>จุดบริการ</th>\r\n                                                    <th>");
#nullable restore
#line 132 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                   Write(ViewData["Y1"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
            WriteLiteral("                                                </tr>\r\n                                            </thead>\r\n                                            <tbody>\r\n");
#nullable restore
#line 137 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                 foreach (var item in displaydata) //foreach (var item in displaydata.Zip(displaydata2, (a, b) => new { a, b }))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n\r\n                                                        <th>");
#nullable restore
#line 141 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                       Write(item.Label);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                        <td>");
#nullable restore
#line 142 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                       Write(item.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                                    </tr>\r\n");
#nullable restore
#line 145 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-12 col-lg-6 "">
            <div class=""row"">
                <div class=""col-12"">
                    <div class=""card"">
                        <div class=""card-body px-3 py-4-5"">
                            <div class=""row"">
                                <div class=""card-header"">
                                    <h4>ผู้ป่วยนอกเก่า</h4>
                                    <div id=""ChartOld"" style=""width:100%; height:400px;""></div>
                                </div>
                                <div class=""card-body"">
                                    <div class=""card-body"">
                                        <h4>รายล");
            WriteLiteral(@"ะเอียด</h4>
                                        <p>ผู้ป่วยนอกเก่า</p>
                                        <table id=""tableOld"" class=""table table-striped"">
                                            <thead>
                                                <tr>
                                                    <th>จุดบริการ</th>
                                                    <th>");
#nullable restore
#line 174 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                   Write(ViewData["Y1"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
            WriteLiteral("                                                </tr>\r\n                                            </thead>\r\n                                            <tbody>\r\n");
#nullable restore
#line 179 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                 foreach (var item in displaydata2) //foreach (var item in displaydata.Zip(displaydata2, (a, b) => new { a, b }))
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <tr>\r\n\r\n                                                        <th>");
#nullable restore
#line 183 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                       Write(item.Label);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                                                        <td>");
#nullable restore
#line 184 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                       Write(item.Y);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
            WriteLiteral("                                                    </tr>\r\n");
#nullable restore
#line 187 "D:\time_waitting\time_waitting\Views\Report\Report3.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SumpatienModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

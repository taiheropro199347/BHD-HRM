#pragma checksum "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60de8155a6a3d1ad39ae6330a95fe10402a45a64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Areas_Index), @"mvc.1.0.view", @"/Views/Areas/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"60de8155a6a3d1ad39ae6330a95fe10402a45a64", @"/Views/Areas/Index.cshtml")]
    #nullable restore
    public class Views_Areas_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BHDHRMWebAPI.Models.Area>>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60de8155a6a3d1ad39ae6330a95fe10402a45a643032", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Index</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60de8155a6a3d1ad39ae6330a95fe10402a45a644091", async() => {
                WriteLiteral("\r\n<p>\r\n    <a asp-action=\"Create\">Create New</a>\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreateBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdateDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.UpdateBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Isvisible));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 43 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 46 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreateBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 52 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.CreateDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 55 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdateDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 58 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.UpdateBy));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 61 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Isvisible));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a asp-action=\"Edit\"");
                BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1679, "\"", 1702, 1);
#nullable restore
#line 64 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
WriteAttributeValue("", 1694, item.Id, 1694, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Edit</a> |\r\n                <a asp-action=\"Details\"");
                BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1755, "\"", 1778, 1);
#nullable restore
#line 65 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
WriteAttributeValue("", 1770, item.Id, 1770, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Details</a> |\r\n                <a asp-action=\"Delete\"");
                BeginWriteAttribute("asp-route-id", " asp-route-id=\"", 1833, "\"", 1856, 1);
#nullable restore
#line 66 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
WriteAttributeValue("", 1848, item.Id, 1848, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">Delete</a>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 69 "D:\BHD-HR\BHD-HR\BHD-HRM-git\BHD-HRM\BHD_HRMWebAPI\BHDHRMWebAPI\Views\Areas\Index.cshtml"
}

#line default
#line hidden
#nullable disable
                WriteLiteral("    </tbody>\r\n</table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BHDHRMWebAPI.Models.Area>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

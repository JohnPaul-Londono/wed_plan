#pragma checksum "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7f2e15a91dbf0b389f34dd67665a917040ea5b11"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OneWedding), @"mvc.1.0.view", @"/Views/Home/OneWedding.cshtml")]
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
#line 1 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/_ViewImports.cshtml"
using wed_plan;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/_ViewImports.cshtml"
using wed_plan.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7f2e15a91dbf0b389f34dd67665a917040ea5b11", @"/Views/Home/OneWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93d8a04f403f410372a0bc17526433aad42868e4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OneWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Wedding>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\n    <a href=\"/dashboard\" class=\"btn btn-info\">Dashboard</a>\n</div>\n<h1>");
#nullable restore
#line 6 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
Write(Model.person1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" and ");
#nullable restore
#line 6 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
                  Write(Model.person2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Wedding</h1>\n<h1>");
#nullable restore
#line 7 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
Write(Model.UserId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n<h3>Date: ");
#nullable restore
#line 9 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
     Write(Model.dateofWedding.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n<h3>Address: ");
#nullable restore
#line 10 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
        Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\n\n\n");
#nullable restore
#line 13 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
  
    foreach (RSVP we in Model.guestlist)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul>\n            <li>");
#nullable restore
#line 17 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
           Write(we.User.firstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n        </ul>\n");
#nullable restore
#line 19 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
    }


#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
  
    if (Model.UserId == Context.Session.GetInt32("LoggedIn")) 
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\n            <a");
            BeginWriteAttribute("href", " href=\"", 521, "\"", 550, 2);
            WriteAttributeValue("", 528, "/edit/", 528, 6, true);
#nullable restore
#line 26 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
WriteAttributeValue("", 534, Model.WeddingId, 534, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning\">Edit</a>\n            <a");
            BeginWriteAttribute("href", " href=\"", 599, "\"", 630, 2);
            WriteAttributeValue("", 606, "/delete/", 606, 8, true);
#nullable restore
#line 27 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
WriteAttributeValue("", 614, Model.WeddingId, 614, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\n        </div>\n");
#nullable restore
#line 29 "/Users/johnlondono/Desktop/Coding_Dojo/C#/Wk_3/wed_plan/Views/Home/OneWedding.cshtml"
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n\n\n\n\n\n<div>\n    <a href=\"/logout\" class=\"btn btn-danger\">Logout</a>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Wedding> Html { get; private set; }
    }
}
#pragma warning restore 1591

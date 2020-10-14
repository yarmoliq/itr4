#pragma checksum "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0a077710dbb4399ab10c02cbb071468194dc2e7a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListUsers_List), @"mvc.1.0.view", @"/Views/ListUsers/List.cshtml")]
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
#line 1 "/home/yarmoliq/dev/itr4/main/Views/_ViewImports.cshtml"
using main;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/yarmoliq/dev/itr4/main/Views/_ViewImports.cshtml"
using main.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/yarmoliq/dev/itr4/main/Views/_ViewImports.cshtml"
using Identity.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0a077710dbb4399ab10c02cbb071468194dc2e7a", @"/Views/ListUsers/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab08e4052234f45dd32569dadc73246d99e7d291", @"/Views/_ViewImports.cshtml")]
    public class Views_ListUsers_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Microsoft.AspNetCore.Identity.IdentityUser>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
  
    ViewData["Title"] = "Listing";

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n<h1>Users table</h1>\n\n<table class=\"table\" id=\"usersTable\">\n  <thead>\n    <tr>\n      <th scope=\"col\">Select</th>\n      <th scope=\"col\">ID</th>\n      <th scope=\"col\">E-mail</th>\n    </tr>\n  </thead>\n  \n  <tbody>\n\n");
#nullable restore
#line 19 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
     foreach(var user in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\n        <th><input type=\"checkbox\"");
            BeginWriteAttribute("id", " id=\"", 402, "\"", 417, 2);
            WriteAttributeValue("", 407, "c_", 407, 2, true);
#nullable restore
#line 22 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
WriteAttributeValue("", 409, user.Id, 409, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></th>\n        <td>");
#nullable restore
#line 23 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
       Write(user.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>");
#nullable restore
#line 24 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
       Write(user.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n");
#nullable restore
#line 26 "/home/yarmoliq/dev/itr4/main/Views/ListUsers/List.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("  </tbody>\n</table>\n\n<input type=\"button\" value=\"button\" onclick=\"PrintSelected()\"/>\n");
            WriteLiteral("\n");
            WriteLiteral(@"
<script>

  var PrintSelected = function() {

    var arrItems = [];

    var answer = """";

    $(""#usersTable tbody Input[type=checkbox]"").each(function(index, val){

      // debugger

      var checkId = $(val).attr(""Id"");

      var arr = checkId.split('_');

      var id = arr[1];

      if($(""#""+checkId).is("":checked"", true))
      {
        arrItems.push(id);
      }

    })

    if(arrItems.length != 0)
    {
      // debugger

      var resultString = arrItems.toString();

      $.post(""ListUsers/DeleteUser"", ""048fd6e1-4d7c-4e44-9e46-c677bd873d80"");
    }

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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Microsoft.AspNetCore.Identity.IdentityUser>> Html { get; private set; }
    }
}
#pragma warning restore 1591

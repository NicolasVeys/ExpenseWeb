#pragma checksum "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\Statistics\Stats.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "806ebe27c799e2b6a21c7f5bc9e34f34e95a9676"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Statistics_Stats), @"mvc.1.0.view", @"/Views/Statistics/Stats.cshtml")]
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
#line 1 "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\_ViewImports.cshtml"
using ExpenseWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\_ViewImports.cshtml"
using ExpenseWeb.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"806ebe27c799e2b6a21c7f5bc9e34f34e95a9676", @"/Views/Statistics/Stats.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e2983b609b6cff1a9314bbc5cda839556ddc61f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Statistics_Stats : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ExpenseWeb.Models.ExpenseStatsViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\Statistics\Stats.cshtml"
 foreach (var stat in Model)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\Statistics\Stats.cshtml"
Write(stat.MaxExpense);

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Ginger\source\repos\ExpenseWeb\ExpenseWeb\Views\Statistics\Stats.cshtml"
                    ;
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ExpenseWeb.Models.ExpenseStatsViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2fc85d9b59e1b87a3d7f9db56cd1ec616802842f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clubes_Crear), @"mvc.1.0.view", @"/Views/Clubes/Crear.cshtml")]
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
#line 1 "C:\Proyectos\Herramientas programacion\Arqueria\Views\_ViewImports.cshtml"
using Arqueria;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Proyectos\Herramientas programacion\Arqueria\Views\_ViewImports.cshtml"
using Arqueria.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2fc85d9b59e1b87a3d7f9db56cd1ec616802842f", @"/Views/Clubes/Crear.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1840fae4d91c53cfa46ecd4f882827d8c3350910", @"/Views/_ViewImports.cshtml")]
    public class Views_Clubes_Crear : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Club>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
  
    ViewData["Title"] = "Home Page"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div");
            BeginWriteAttribute("class", " class=\"", 60, "\"", 68, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"tabla\">\n    <h1 class=\"display-4\">Crear un Club</h1>\n    <button type=\"button\" class=\"btn btn-dark mb-3 mt-3\">");
#nullable restore
#line 8 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
                                                    Write(Html.ActionLink("Volver","ListaClubes"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\n\n");
#nullable restore
#line 10 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
 using (@Html.BeginForm())
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form-group\">\n        ");
#nullable restore
#line 14 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
   Write(Html.LabelFor(m=> m.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        ");
#nullable restore
#line 15 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
   Write(Html.TextBoxFor(m=> m.Nombre, new {@class="form-control",@required="true"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </div>\n    <div class=\"form-group\">\n");
#nullable restore
#line 18 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
             if (!ViewData.ModelState.IsValid)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
           Write(Html.ValidationSummary(false,"Solucionar los siguientes errores:",
                    new{@class="text-danger"}));

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
                                              
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n    <input type=\"submit\" value=\"Crear Club\" class=\"btn btn-success\"/>\n");
#nullable restore
#line 25 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Clubes\Crear.cshtml"
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral(" \n\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Club> Html { get; private set; }
    }
}
#pragma warning restore 1591

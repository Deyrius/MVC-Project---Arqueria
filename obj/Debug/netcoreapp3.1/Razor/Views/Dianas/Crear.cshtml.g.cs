#pragma checksum "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2959b70af21d4a24310bd0d7a6e8edd2d90c08df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dianas_Crear), @"mvc.1.0.view", @"/Views/Dianas/Crear.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2959b70af21d4a24310bd0d7a6e8edd2d90c08df", @"/Views/Dianas/Crear.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1840fae4d91c53cfa46ecd4f882827d8c3350910", @"/Views/_ViewImports.cshtml")]
    public class Views_Dianas_Crear : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Diana>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<div");
            BeginWriteAttribute("class", " class=\"", 18, "\"", 26, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"tabla\">\n        <h1 class=\"display-4\">Crear una Diana</h1>\n        <a");
            BeginWriteAttribute("href", " href=\'", 101, "\'", 142, 1);
#nullable restore
#line 5 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
WriteAttributeValue("", 108, Url.Action("ListaDiana","Dianas"), 108, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@">
            <svg xmlns=""http://www.w3.org/2000/svg"" xmlns:xlink=""http://www.w3.org/1999/xlink"" xmlns:svgjs=""http://svgjs.com/svgjs"" version=""1.1"" width=""50"" height=""50"" x=""0"" y=""0"" viewBox=""0 0 512 512"" style=""enable-background:new 0 0 512 512"" xml:space=""preserve""");
            BeginWriteAttribute("class", " class=\"", 410, "\"", 418, 0);
            EndWriteAttribute();
            WriteLiteral("><g transform=\"matrix(-1.8369701987210297e-16,-1,1,-1.8369701987210297e-16,-2.842170943040401e-14,512)\">\n            <g xmlns=\"http://www.w3.org/2000/svg\">\n                <path");
            BeginWriteAttribute("style", " style=\"", 596, "\"", 604, 0);
            EndWriteAttribute();
            WriteLiteral(" d=\"M236.662,337.591l-50.299,40.406c-1.229,0.988-1.944,2.479-1.944,4.054v124.736   c0,4.246,4.814,6.703,8.252,4.212l43.99-31.873V337.591H236.662z\" fill=\"#ff4f19\" data-original=\"#ff4f19\"/>\n                <path");
            BeginWriteAttribute("style", " style=\"", 814, "\"", 822, 0);
            EndWriteAttribute();
            WriteLiteral(@" d=""M275.338,337.591l50.299,40.406c1.229,0.988,1.944,2.479,1.944,4.054v124.736   c0,4.246-4.814,6.703-8.252,4.212l-43.99-31.873L275.338,337.591L275.338,337.591z"" fill=""#ff4f19"" data-original=""#ff4f19""/>
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
                <path");
            BeginWriteAttribute("style", " style=\"", 1115, "\"", 1123, 0);
            EndWriteAttribute();
            WriteLiteral(@" d=""M327.576,382.056v124.73c0,4.254-4.806,6.709-8.249,4.213l-13.273-9.622   c0.791-0.936,1.279-2.153,1.279-3.547V364.964c0-0.676-0.125-1.341-0.375-1.966l18.682,15   C326.868,378.987,327.576,380.474,327.576,382.056z"" fill=""#e23d17"" data-original=""#e23d17""/>
                <path");
            BeginWriteAttribute("style", " style=\"", 1402, "\"", 1410, 0);
            EndWriteAttribute();
            WriteLiteral(@" d=""M184.419,382.056v124.73c0,4.254,4.806,6.709,8.249,4.213l13.273-9.622   c-0.791-0.936-1.279-2.153-1.279-3.547V364.964c0-0.676,0.125-1.341,0.375-1.966l-18.682,15   C185.127,378.987,184.419,380.474,184.419,382.056z"" fill=""#e23d17"" data-original=""#e23d17""/>
            </g>
            <path xmlns=""http://www.w3.org/2000/svg""");
            BeginWriteAttribute("style", " style=\"", 1738, "\"", 1746, 0);
            EndWriteAttribute();
            WriteLiteral(@" d=""M251.526,2.176L215.78,50.797c-2.59,3.523-0.074,8.495,4.298,8.495h35.746h35.746  c4.373,0,6.889-4.972,4.298-8.495L260.123,2.176C257.99-0.725,253.658-0.725,251.526,2.176z"" fill=""#b7c1ca"" data-original=""#b7c1ca""/>
            <path xmlns=""http://www.w3.org/2000/svg""");
            BeginWriteAttribute("style", " style=\"", 2014, "\"", 2022, 0);
            EndWriteAttribute();
            WriteLiteral(@" d=""M291.573,59.292h-16.64L242.237,14.82l9.289-12.642c2.131-2.901,6.465-2.902,8.598-0.001  l35.749,48.62C298.462,54.319,295.946,59.292,291.573,59.292z"" fill=""#a3aeb7"" data-original=""#a3aeb7""/>
            <rect xmlns=""http://www.w3.org/2000/svg"" x=""236.663"" y=""59.292""");
            BeginWriteAttribute("style", " style=\"", 2291, "\"", 2299, 0);
            EndWriteAttribute();
            WriteLiteral(" width=\"38.677\" height=\"418.918\" fill=\"#ffdba9\" data-original=\"#ffdba9\"/>\n            <rect xmlns=\"http://www.w3.org/2000/svg\" x=\"255.995\" y=\"59.292\"");
            BeginWriteAttribute("style", " style=\"", 2449, "\"", 2457, 0);
            EndWriteAttribute();
            WriteLiteral(@" width=""19.338"" height=""418.918"" fill=""#ffc473"" data-original=""#ffc473""/>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g>
            <g xmlns=""http://www.w3.org/2000/svg"">
            </g");
            WriteLiteral(">\n            <g xmlns=\"http://www.w3.org/2000/svg\">\n            </g>\n            </g></svg>\n        </a>\n");
#nullable restore
#line 51 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
     using (@Html.BeginForm())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-group\">\n            ");
#nullable restore
#line 54 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
       Write(Html.LabelFor(m=> m.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            ");
#nullable restore
#line 55 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
       Write(Html.TextBoxFor(m=> m.Nombre,  new {@class="form-control",@required="true"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </div>\n");
            WriteLiteral("        <input type=\"submit\" value=\"Crear Diana\" class=\"btn btn-success mb-3 ml-3\"/>\n");
            WriteLiteral("        <div class=\"form-group\">\n");
#nullable restore
#line 61 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
                 if (!ViewData.ModelState.IsValid)
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 63 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
               Write(Html.ValidationSummary(
                        false,
                        "Solucionar los siguientes errores:",
                        new{@class="text-danger"}
                    ));

#line default
#line hidden
#nullable disable
#nullable restore
#line 67 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n");
#nullable restore
#line 70 "C:\Proyectos\Herramientas programacion\Arqueria\Views\Dianas\Crear.cshtml"
        
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Diana> Html { get; private set; }
    }
}
#pragma warning restore 1591

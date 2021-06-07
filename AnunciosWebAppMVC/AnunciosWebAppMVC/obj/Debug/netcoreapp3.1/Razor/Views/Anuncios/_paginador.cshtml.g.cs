#pragma checksum "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d29570bc34d93242f097290356d98e9b426862fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Anuncios__paginador), @"mvc.1.0.view", @"/Views/Anuncios/_paginador.cshtml")]
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
#line 1 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\_ViewImports.cshtml"
using AnunciosWebAppMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\_ViewImports.cshtml"
using AnunciosWebMVC.Anuncios.Servicios.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d29570bc34d93242f097290356d98e9b426862fa", @"/Views/Anuncios/_paginador.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2bd7d8e4ce88689f4974065ceb7b925e4a705c08", @"/Views/_ViewImports.cshtml")]
    public class Views_Anuncios__paginador : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AnunciosWebMVC.Anuncios.Servicios.Models.PaginaModelo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
      

        var cantidadPaginas = (int)Math.Ceiling((double)Model.TotalDeRegistros / Model.RegistrosPorPagina);
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <!--Funcionalidad: Páginas-->\r\n\r\n");
#nullable restore
#line 10 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
      
        int Inicial = 1;
        var radio = 3;
        var cantidadMaximaDePaginas = radio * 2 + 1;
        int Final = (cantidadPaginas > cantidadMaximaDePaginas) ? cantidadMaximaDePaginas : cantidadPaginas;
        if (Model.PaginaActual > radio + 1)
        {
            Inicial = Model.PaginaActual - radio;
            if (cantidadPaginas > Model.PaginaActual + radio)
            {
                Final = Model.PaginaActual + radio;
            }
            else
            {
                Final = cantidadPaginas;
            }
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <ul class=\"pagination\">\r\n");
#nullable restore
#line 31 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
          Model.ValoresQueryString["pagina"] = 1; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"btn btn-secondary\">");
#nullable restore
#line 32 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
                                 Write(Html.ActionLink("Primera", null, Model.ValoresQueryString));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 33 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
         for (int i = Inicial; i <= Final; i++)
        {
            Model.ValoresQueryString["pagina"] = i;
            if (i == Model.PaginaActual)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"btn btn-outline-secondary\">");
#nullable restore
#line 38 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
                                                 Write(Html.ActionLink(i.ToString(), null, Model.ValoresQueryString));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 39 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"btn btn-secondary\">");
#nullable restore
#line 42 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
                                         Write(Html.ActionLink(i.ToString(), null, Model.ValoresQueryString));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 43 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
            }
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
          Model.ValoresQueryString["pagina"] = cantidadPaginas; 

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"btn btn-secondary\">");
#nullable restore
#line 46 "C:\ProyectoAnuncios\FrontEnd\AnunciosWebAppMVC\AnunciosWebAppMVC\Views\Anuncios\_paginador.cshtml"
                                 Write(Html.ActionLink("Ultima", null, Model.ValoresQueryString));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    </ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AnunciosWebMVC.Anuncios.Servicios.Models.PaginaModelo> Html { get; private set; }
    }
}
#pragma warning restore 1591
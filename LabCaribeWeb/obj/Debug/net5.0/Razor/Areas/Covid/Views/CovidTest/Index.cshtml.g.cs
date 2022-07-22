#pragma checksum "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Covid/Views/CovidTest/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52f014b6906004002e5f807fa3f15c2a01f0f7bd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Covid_Views_CovidTest_Index), @"mvc.1.0.view", @"/Areas/Covid/Views/CovidTest/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52f014b6906004002e5f807fa3f15c2a01f0f7bd", @"/Areas/Covid/Views/CovidTest/Index.cshtml")]
    public class Areas_Covid_Views_CovidTest_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Covid/Views/CovidTest/Index.cshtml"
  
    ViewData["Title"] = "COVID Test";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<!-- Encabezado -->\n<!-- ============================================================== -->\n<div class=\"row page-titles\">\n    <div class=\"col-md-5 align-self-center\">\n        <h3 class=\"text-themecolor\">");
#nullable restore
#line 10 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Covid/Views/CovidTest/Index.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""javascript:void(0)"">Home</a></li>
            <li class=""breadcrumb-item"">COVID</li>
            <li class=""breadcrumb-item active"">COVID Test</li>
        </ol>
    </div>
    <div class=""col-md-7 align-self-center text-right"">

    </div>
</div>
<!-- ============================================================== -->
<div id=""CovidTest"">
    <div class=""row"">
        <div class=""col-lg-6"">
            <div class=""card border-success"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Datos del Cliente</h5>
                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <el-autocomplete placeholder=""Buscar cliente""
                                             v-model=""cliente.nombre""
                                             v-bind:fetch-suggestions=""getAutocompleteClientes""
                                             :trigger-on-focus=""f");
            WriteLiteral(@"alse""
                                             v-bind:value-key=""'value'""
                                             v-bind:popper-class=""'fix-autocomplete-lg'""
                                             v-on:select=""autocompleteClienteSeleccionar""
                                             v-on:clear=""autocompleteClienteLimpiar""
                                             size=""mini""
                                             clearable
                                             :disabled=""cliente.actualizar"">
                                <template slot-scope=""{ item }"">
                                    <span v-if=""item.id"">{{item.item}}</span>
                                    <span v-else>{{item}}</span>
                                </template>
                            </el-autocomplete>
                        </div>
                    </div>
                    <el-form :model=""cliente.datos"" ref=""cliente"" :rules=""cliente.reglas"">
                        <div class=""row"">
   ");
            WriteLiteral(@"                         <div class=""col-lg-6"">
                                <el-form-item label=""Nombre"" prop=""nombre"">
                                    <el-input v-model=""cliente.datos.nombre"" size=""mini"" :disabled=""!cliente.actualizar""></el-input>
                                </el-form-item>
                            </div>
                            <div class=""col-lg-6"">
                                <el-form-item label=""Edad"" prop=""edad"">
                                    <el-input v-model.number=""cliente.datos.edad"" size=""mini"" :disabled=""!cliente.actualizar""></el-input>
                                </el-form-item>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-lg-6"">
                                <el-form-item label=""Fecha de Nacimiento"" prop=""fechaNacimiento"">
                                    <el-date-picker type=""date"" format=""dd-MM-yyyy"" placeholder=""Fecha"" v-model=""clien");
            WriteLiteral(@"te.datos.fechaNacimiento"" style=""width: 100%;"" size=""mini"" :disabled=""!cliente.actualizar""></el-date-picker>
                                </el-form-item>
                            </div>
                            <div class=""col-lg-6"">
                                <el-form-item label=""Sexo"" prop=""sexo"">
                                    <br />
                                    <el-radio-group v-model=""cliente.datos.sexo"" :disabled=""!cliente.actualizar"">
                                        <el-radio label=""H"">Hombre</el-radio>
                                        <el-radio label=""M"">Mujer</el-radio>
                                    </el-radio-group>
                                </el-form-item>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-lg-6"">
                                <el-form-item label=""Teléfono"" prop=""telefono"">
                                    <el-input v-model=""c");
            WriteLiteral(@"liente.datos.telefono"" size=""mini"" :disabled=""!cliente.actualizar""></el-input>
                                </el-form-item>
                            </div>
                            <div class=""col-lg-6"">
                                <el-form-item label=""Email"" prop=""email"">
                                    <el-input v-model=""cliente.datos.email"" size=""mini"" :disabled=""!cliente.actualizar""></el-input>
                                </el-form-item>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-lg-6"">
                                <el-form-item label=""Número Pasaporte"" prop=""numeroPasaporte"">
                                    <el-input v-model=""cliente.datos.numeroPasaporte"" size=""mini"" :disabled=""!cliente.actualizar""></el-input>
                                </el-form-item>
                            </div>
                            <div class=""col-lg-6"">
                           ");
            WriteLiteral(@"     <el-checkbox v-model=""cliente.actualizar"" label=""Actualizar datos"" border></el-checkbox>
                            </div>
                        </div>
                    </el-form>
                </div>
            </div>
        </div>
        <div class=""col-lg-6"">
            <div class=""card border-success"">
                <div class=""card-body"">
                    <h5 class=""card-title"">Datos COVID Test</h5>
                    <div class=""row"">
                        <div");
            BeginWriteAttribute("class", " class=\"", 5927, "\"", 5935, 0);
            EndWriteAttribute();
            WriteLiteral(">\n\n                        </div>\n                    </div>\n                </div>\n            </div>\n        </div>\n    </div>\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var app = new Vue({
            el: '#CovidTest',
            data: {
                comportamiento: {
                    mostrarDialogNuevoTest: false
                },
                covidTest: {
                    id: -1,
                    idCatalogoTest: null,
                    resultado: null,
                    numeroAutorizacion: null,
                    rdrp: null,
                    idCliente: null
                },
                cliente: {
                    nombre: null,
                    actualizar: false,
                    datos: {
                        id: null,
                        nombre: null,
                        edad: null,
                        fechaNacimiento: new Date(),
                        sexo: null,
                        telefono: null,
                        nombreDoctor: null,
                        email: null,
                        numeroPasaporte: null,
                        usuario: null
                    },
     ");
                WriteLiteral(@"               reglas: {
                        nombre: { required: true, message: 'El nombre es requerido.', trigger: 'blur' },
                        edad: [
                            { required: true, message: 'La edad es requerida', trigger: 'blur' },
                            { type: 'number', message: 'La edad debe ser numérica' }
                        ],
                        fechaNacimiento: { required: true, message: 'La fecha de nacimiento es requerida', trigger: 'change' },
                        sexo: { required: true, message: 'El sexo es requerido', trigger: 'change' },
                        email: { required: true, message: 'El email es requerido', trigger: 'blur' },
                        numeroPasaporte: { required: true, message: 'El número de pasaporte es requerido', trigger: 'blur' }
                    },
                    listaClientes: []
                }
            },
            methods: {
                getAutocompleteClientes: function (texto, cb) {
              ");
                WriteLiteral("      if (texto.length > 1) {\n                        axios.get(\'");
#nullable restore
#line 166 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Covid/Views/CovidTest/Index.cshtml"
                              Write(Url.Action("AutocompleteCliente", "Clientes", new { Area="Catalogos"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?texto=' + texto)
                        .then(response => {
                            if (response.data.length > 0) cb(response.data)
                            else {
                                this.cliente.actualizar = true
                                this.cliente.datos = {
                                    id: -1,
                                    nombre: texto,
                                    edad: null,
                                    fechaNacimiento: null,
                                    sexo: null,
                                    telefono: null,
                                    nombreDoctor: null,
                                    email: null,
                                    numeroPasaporte: null,
                                    usuario: null
                                }
                                cb([""No se encontraron clientes...""]);
                            }
                        }).catch(e => {
                            this.cliente.a");
                WriteLiteral(@"ctualizar = true
                            this.cliente.datos = {
                                id: -1,
                                nombre: texto,
                                edad: null,
                                fechaNacimiento: null,
                                sexo: null,
                                telefono: null,
                                nombreDoctor: null,
                                email: null,
                                numeroPasaporte: null,
                                usuario: null
                            }
                            cb([""No se cargaron los clientes...""]);
                        });
                    } else {
                        this.cliente.actualizar = true
                        this.cliente.datos = {
                            id: -1,
                            nombre: texto,
                            edad: null,
                            fechaNacimiento: null,
                            sexo: null,
             ");
                WriteLiteral(@"               telefono: null,
                            nombreDoctor: null,
                            email: null,
                            numeroPasaporte: null,
                            usuario: null
                        }
                        cb([]);
                    }
                },
                autocompleteClienteSeleccionar: async function (item) {
                    await axios.get('");
#nullable restore
#line 219 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Covid/Views/CovidTest/Index.cshtml"
                                Write(Url.Action("GetCliente", "Clientes", new { Area="Catalogos"}));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?idCliente=' + item.id)
                        .then(response => {
                        if (response.data != null) {
                            this.cliente.datos = response.data
                        } else {
                            this.cliente.datos.id = -1
                        }
                    }).catch(e => {
                        this.$message.error('Error al obtener los datos del cliente.');
                    });
                },
                autocompleteClienteLimpiar: function () {
                    this.cliente.datos = {
                        id: -1,
                        nombre: null,
                        edad: null,
                        fechaNacimiento: null,
                        sexo: null,
                        telefono: null,
                        nombreDoctor: null,
                        email: null,
                        numeroPasaporte: null,
                        usuario: null
                    }
                }
            },
        ");
                WriteLiteral("    mounted: function () {\n\n            }\n        });\n    </script>\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

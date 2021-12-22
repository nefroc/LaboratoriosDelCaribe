#pragma checksum "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5cfe018fa45091ff2e06ad52f25a5be1f30ffb27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Catalogos_Views_Usuarios_Index), @"mvc.1.0.view", @"/Areas/Catalogos/Views/Usuarios/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5cfe018fa45091ff2e06ad52f25a5be1f30ffb27", @"/Areas/Catalogos/Views/Usuarios/Index.cshtml")]
    public class Areas_Catalogos_Views_Usuarios_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
  
    ViewData["Title"] = "Usuarios";
    Layout = "~/Views/Shared/_Layout.cshtml";


#line default
#line hidden
#nullable disable
            WriteLiteral("<!-- Encabezado -->\n<!-- ============================================================== -->\n<div class=\"row page-titles\">\n    <div class=\"col-md-5 align-self-center\">\n        <h3 class=\"text-themecolor\">");
#nullable restore
#line 10 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                               Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>
        <ol class=""breadcrumb"">
            <li class=""breadcrumb-item""><a href=""javascript:void(0)"">Home</a></li>
            <li class=""breadcrumb-item"">Catálogos</li>
            <li class=""breadcrumb-item active"">Usuarios</li>
        </ol>
    </div>
    <div class=""col-md-7 align-self-center text-right"">
        
    </div>
</div>
<!-- ============================================================== -->
<!-- End Bread crumb and right sidebar toggle -->
<div id=""Usuarios"">
    <div class=""row"">
        <div class=""col-lg-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <button type=""button"" class=""btn btn-info btn-sm"" ");
            WriteLiteral(@"@click=""dialogNuevoUsuario = true""><i class=""fa fa-plus-circle""></i>Nuevo Usuario</button>
                            <div class=""table-responsive"">
                                <table class=""table table-hover"">
                                    <thead>
                                        <tr>
                                            <th>NOMBRE</th>
                                            <th>APELLIDOS</th>
                                            <th>CORREO</th>
                                            <th>PERFIL</th>
                                            <th>ACTIVO</th>
                                            <th>ACCIONES</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr v-for=""item in listaUsuarios"">
                                            <td>{{item.nombre}}</td>
                                            <td>{{item.apellidos}}</td>
   ");
            WriteLiteral(@"                                         <td>{{item.correo}}</td>
                                            <td>{{item.perfil}}</td>
                                            <td>{{item.activo | activo}}</td>
                                            <td nowrap>
                                                <button type=""button"" class=""btn waves-effect waves-light btn-outline-info btn-sm"" ");
            WriteLiteral("@click=\"btnBuscarUsuario_click(item.id)\">Editar</button>\n                                                <button type=\"button\" class=\"btn waves-effect waves-light btn-outline-danger btn-sm\" ");
            WriteLiteral(@"@click=""btnEliminarUsuario_click(item)"">Eliminar</button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

");
            WriteLiteral(@"    <el-dialog title=""Nuevo Usuario"" :visible.sync=""dialogNuevoUsuario"">
        <el-form :model=""nuevoUsuario"" ref=""nuevoUsuario"" :rules=""rulesUsuario"">
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <label>Correo</label>
                    <el-form-item prop=""correo"">
                        <el-input v-model=""nuevoUsuario.correo""></el-input>
                    </el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Contraseña</label>
                    <el-form-item prop=""contrasena"">
                        <el-input v-model=""nuevoUsuario.contrasena""></el-input>
                    </el-form-item>
                </div>
            </div>
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <label>Nombre</label>
                    <el-form-item prop=""nombre"">
                        <el-input v-model=""nuevoUsuario.nombre""></el-input>
                    <");
            WriteLiteral(@"/el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Apellidos</label>
                    <el-form-item prop=""apellidos"">
                        <el-input v-model=""nuevoUsuario.apellidos""></el-input>
                    </el-form-item>
                </div>
            </div>
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <el-form-item label=""Activo"" prop=""activo"">
                        <el-switch v-model=""nuevoUsuario.activo""></el-switch>
                    </el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Apellidos</label>
                    <el-form-item prop=""idPerfil"">
                        <el-select v-model=""nuevoUsuario.idPerfil"" placeholder=""please select your zone"">
                            <el-option label=""Administrador"" value=""1""></el-option>
                        </el-select>
                    </el-form-item>
              ");
            WriteLiteral("  </div>\n            </div>\n        </el-form>\n        <span slot=\"footer\" class=\"dialog-footer\">\n            <el-button ");
            WriteLiteral("@click=\"dialogNuevoUsuario = false\">Cancelar</el-button>\n            <el-button type=\"primary\" ");
            WriteLiteral("@click=\"btnNuevoUsuario_click\">Guardar</el-button>\n        </span>\n    </el-dialog>\n");
            WriteLiteral(@"    <el-dialog title=""Actualizar Usuario"" :visible.sync=""dialogActualizarUsuario"">
        <el-form :model=""actualizarUsuario"" ref=""actualizarUsuario"" :rules=""rulesUsuario"">
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <label>Correo</label>
                    <el-form-item prop=""correo"">
                        <el-input v-model=""actualizarUsuario.correo""></el-input>
                    </el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Contraseña</label>
                    <el-form-item prop=""contrasena"">
                        <el-input v-model=""actualizarUsuario.contrasena""></el-input>
                    </el-form-item>
                </div>
            </div>
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <label>Nombre</label>
                    <el-form-item prop=""nombre"">
                        <el-input v-model=""actualizarUsuario.nombre");
            WriteLiteral(@"""></el-input>
                    </el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Apellidos</label>
                    <el-form-item prop=""apellidos"">
                        <el-input v-model=""actualizarUsuario.apellidos""></el-input>
                    </el-form-item>
                </div>
            </div>
            <div class=""row form-group"">
                <div class=""col-lg-6"">
                    <el-form-item label=""Activo"" prop=""activo"">
                        <el-switch v-model=""actualizarUsuario.activo""></el-switch>
                    </el-form-item>
                </div>
                <div class=""col-lg-6"">
                    <label>Apellidos</label>
                    <el-form-item prop=""idPerfil"">
                        <el-select v-model=""actualizarUsuario.idPerfil"" placeholder=""please select your zone"">
                            <el-option v-for=""item in listaPerfiles"" :key=""item.id"" :value=""item.id"" :label=""item.item""><");
            WriteLiteral("/el-option>\n                        </el-select>\n                    </el-form-item>\n                </div>\n            </div>\n        </el-form>\n        <span slot=\"footer\" class=\"dialog-footer\">\n            <el-button ");
            WriteLiteral("@click=\"dialogActualizarUsuario = false\">Cancelar</el-button>\n            <el-button type=\"primary\" ");
            WriteLiteral("@click=\"btnActualizarUsuario_click\">Guardar</el-button>\n        </span>\n    </el-dialog>\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script>
        var app = new Vue({
            el: '#Usuarios',
            data: {
                listaUsuarios: [],
                listaPerfiles: [],
                dialogNuevoUsuario: false,
                nuevoUsuario: {
                    id: null,
                    correo: null,
                    contrasena: null,
                    nombre: null,
                    apellidos: null,
                    activo: true,
                    creadoPor: 0,
                    idPerfil: 1
                },
                rulesUsuario: {
                    correo: { required: true, message: 'El correo es requerido.', trigger: 'blur' },
                    contrasena: { required: true, message: 'La contraseña es requerida', trigger: 'blur' },
                    nombre: { required: true, message: 'El nombre es requerido.', trigger: 'blur' },
                    apellidos: { required: true, message: 'Los apellidos son requeridos', trigger: 'blur' }
                },
                actualizarU");
                WriteLiteral(@"suario: {
                    id: null,
                    correo: null,
                    contrasena: null,
                    nombre: null,
                    apellidos: null,
                    activo: true,
                    creadoPor: 0,
                    idPerfil: 1
                },
                dialogActualizarUsuario: false
            },
            methods: {
                obtenerListaUsuarios: function () {
                    axios.get('");
#nullable restore
#line 209 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                          Write(Url.Action("GetListaUsuarios", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"').then(response => {
                        console.log(response.data)
                        this.listaUsuarios = response.data;
                    }).catch(e => {
                        this.$message.error('No se han podido cargar los Usuarios.');
                    });
                },
                btnEliminarUsuario_click: function (item) {
                    this.$confirm('El usuario ' + item.nombre + ' ' + item.apellidos + ' se eliminará permanentemente. ¿Desea continuar?', 'Confirmar', {
                        confirmButtonText: 'Si',
                        cancelButtonText: 'No',
                        type: 'warning'
                    }).then(() => {
                        try {
                            axios.delete('");
#nullable restore
#line 223 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                                     Write(Url.Action("SetEliminarUsuario", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?idUsuario=' + item.id).then(response => {
                                console.log(response.data)
                                if (response.data === true) {
                                    this.obtenerListaUsuarios()

                                    this.$message({
                                        type: 'success',
                                        message: 'El usuario ' + item.nombre + ' ' + item.apellidos + ' se ha eliminado'
                                    });
                                } else {
                                    this.$message.error(response.data);
                                }
                            }).catch(e => {
                                this.$message.error('Error al eliminar el usuario.');
                            });
                        } catch (error) {
                            this.$message.error(error);
                        }
                    }).catch(() => {
                        this.$message({
               ");
                WriteLiteral(@"             type: 'info',
                            message: 'Proceso cancelado.'
                        });
                    });
                },
                btnNuevoUsuario_click: function () {
                    this.$refs['nuevoUsuario'].validate((valid) => {
                        if (valid) {
                            try {
                                axios.post('");
#nullable restore
#line 252 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                                       Write(Url.Action("SetNuevoUsuario", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', this.nuevoUsuario).then(response => {
                                    console.log(response.data)
                                    if (response.data === 'ok') {
                                        this.dialogNuevoUsuario = false
                                        this.obtenerListaUsuarios()

                                        this.$message.success('El usuario se ha creado.');
                                    } else {
                                        this.$message.error(response.data);
                                    }
                                }).catch(e => {
                                    this.$message.error('Error al crear el usuario.');
                                });
                            } catch (error) {
                                this.$message.error(error);
                            }
                        } else {
                            console.log('Error de validacion')
                            return false;
                  ");
                WriteLiteral("      }\n                    });\n                },\n                btnBuscarUsuario_click: function (id) {\n                    this.obtenerListaPerfiles();\n                    axios.get(\'");
#nullable restore
#line 276 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                          Write(Url.Action("GetUsuario", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?idUsuario=' + id).then(response => {
                            console.log(response.data)
                        this.actualizarUsuario = response.data
                        this.dialogActualizarUsuario = true;

                        }).catch(e => {
                            this.$message.error('Error al obtener el usuario.');
                        });
                },
                btnActualizarUsuario_click: function () {
                    this.$refs['actualizarUsuario'].validate((valid) => {
                        if (valid) {
                            try {
                                this.actualizarUsuario.idPerfil = parseInt(this.nuevoUsuario.idPerfil)
                                axios.put('");
#nullable restore
#line 290 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                                      Write(Url.Action("SetActualizarUsuario", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', this.actualizarUsuario).then(response => {
                                    console.log('Data', response.data)
                                    if (response.data === 'ok') {
                                        this.dialogActualizarUsuario = false
                                        this.obtenerListaUsuarios()

                                        this.$message.success('El usuario se ha actualizado.');
                                    } else {
                                        this.$message.error(response.data);
                                    }
                                }).catch(e => {
                                    this.$message.error('Error al actualizar el usuario.');
                                });
                            } catch (error) {
                                this.$message.error(error);
                            }
                        } else {
                            return false;
                        }
                    });
   ");
                WriteLiteral("             },\n                obtenerListaPerfiles: function () {\n                    axios.get(\'");
#nullable restore
#line 312 "/Users/neftalirodriguez/Projects/LaboratoriosDelCaribe/LabCaribeWeb/Areas/Catalogos/Views/Usuarios/Index.cshtml"
                          Write(Url.Action("GetPerfiles", "Usuarios"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"').then(response => {
                        console.log(response.data)
                        this.listaPerfiles = response.data;
                    }).catch(e => {
                        
                    });
                }
            },
            mounted: function () {
                this.obtenerListaUsuarios()
            }
        });
    </script>
");
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

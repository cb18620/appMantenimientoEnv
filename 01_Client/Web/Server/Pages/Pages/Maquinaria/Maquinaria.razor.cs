using Aplicacion.DTOs.Maquinaria;
using Infraestructura.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MudBlazor;
using Newtonsoft.Json;
using Server.Pages.Pages.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Web;
using Infraestructura.Models.Clasificador;
using Dominio.Entities;
using Infraestructura.Models.Authentication;
using Infraestructura.Models.Maquinaria;
using Microsoft.JSInterop;

namespace Server.Pages.Pages.Maquinaria
{
    public partial class Maquinaria
    {
        public MaquinariaDto _maquinarianuevo = new MaquinariaDto();

        private static List<MaqCaractVehiculoDto> listadetalles { get; set; }
        private static List<MaqCaractInfraDto> listadetallesInfra { get; set; }
        private static List<MaqCaractMaquinariaDto> listadetallesMaquinaria { get; set; }
        private static List<MaqMaquinaElementoDto> listadetallesMaqMaquinariaElemento { get; set; }
        public static List<MaquinariaDto> maquinaria { get; set; }

        public MaqCaractVehiculoDto _maqCaractVehiculo = new MaqCaractVehiculoDto();
        public MaqCaractMaquinariaDto _maqCaractMaquinaria = new MaqCaractMaquinariaDto();
        public MaqCaractInfraDto _maqCaractInfra = new MaqCaractInfraDto(); 
        public MaqMaquinaElementoDto _MaqMaquinaElemento =new MaqMaquinaElementoDto();

        public MaquinariaDto _maquinariaSeleccionada = new MaquinariaDto();

        

        private bool visible;
        
        private void OpenDialog() => visible = true;
        void Submit() => visible = false;
        
        private DialogOptions dialogOptions = new() { FullWidth = true };
        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        private bool striped2 = true;
        //private bool bordered2 = true;
       
        private bool popupAdmView { get; set; } = false;
        private bool popupAdmView1 { get; set; } = false;
        string _TituloPopup; string _TituloPopup1; int _TituloPopup2;
        private string searchString = "";
        public string jsonColor { get; set; }
        public string jsonProceso { get; set; } 
        public string jsonTipoMaquina { get; set; }
        public string ImageBase64 { get; set; }

        private static List<GenClasificadorDto> AreaList { get; set; }
        private static List<GenClasificadorDto> procesosList { get; set; }
        private static List<GenClasificadorDto> TipoMaquinaList { get; set; }

        private bool FilterFunc2(MaqCaractVehiculoDto element) => FilterFunc2(element, searchString);
        private bool FilterFunc2(MaqCaractVehiculoDto element, string searchString1)
        {
            if (string.IsNullOrWhiteSpace(searchString1))
                return true;
            return false;
        }

        //AGREGAR FUNCIONES DEL DETALLE DETALLE  VEHICULOS INICIO
        private async Task onTablaAsyncVehiculoDetalle(EditContext context)
        {
            await SaveVehiculoDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveVehiculoDetalle()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqCaractVehiculo", new { maqCaractVehiculo = _maqCaractVehiculo });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncdetalle(_TituloPopup2);
                    _maqCaractVehiculo = new MaqCaractVehiculoDto();    
                    _MessageShow("Agregado Correctamente",State.Success);
                }
                else
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }
                
                // _navMgr.NavigateTo("/Afiliacion/Empresas", true);
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }


        protected async Task onTablaAsyncdetalle(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqCaractVehiculoDto>>("MaqCaractVehiculo/"+id);

                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                listadetalles = _result.Data;
           
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        public async Task ShowBtnEliminaDetalle(int idExtraccion)
        {
            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqCaractVehiculo", idExtraccion);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncdetalle(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }

        protected async Task EditHorExtracciondetalle(MaqCaractVehiculoDto DtoVehiculodetalle)
        {

            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("MaqCaractVehiculo", DtoVehiculodetalle, DtoVehiculodetalle.IdmaqCaractVehiculo);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    DtoVehiculodetalle.IdmaqCaractVehiculo = _update.Data;
                    DtoVehiculodetalle.VerDetalle = !DtoVehiculodetalle.VerDetalle;
                }
                else
                {
                    _MessageShow(_update.Message, _update.State);
                }
            }
            catch (Exception e)
            {
                _DialogShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        } 
        protected async Task ShowBtnadd(MaquinariaDto maquinariaSeleccionada, int v_Id)
        {
            // Asegúrate de inicializar _maqCaractVehiculo antes de utilizarlo
            _maqCaractVehiculo = new MaqCaractVehiculoDto();
            _maqCaractInfra = new MaqCaractInfraDto();
            _maqCaractMaquinaria = new MaqCaractMaquinariaDto();

            _maquinariaSeleccionada = maquinariaSeleccionada;
            _TituloPopup = "REGISTRO  ";
            _TituloPopup1 = "";
            if (maquinariaSeleccionada.Tipo == 13) { await onTablaAsyncdetalleMaquinaria(v_Id); }
            if (maquinariaSeleccionada.Tipo == 14) { await onTablaAsyncdetalle(v_Id); }
            if (maquinariaSeleccionada.Tipo == 15) { await onTablaAsyncdetalleInfra(v_Id); }

            _TituloPopup2 = v_Id;

            _maqCaractVehiculo.Idmaquinaria = _TituloPopup2;  
            this.popupAdmView = true;
        }
     

        protected void ShowBtnEdit1(int v_IdRecepcion)
        {
            var vAfiliacion = maquinaria.First(f => f.Idmaquinaria == v_IdRecepcion);
            vAfiliacion.VerDetalle = !vAfiliacion.VerDetalle;
        }
        protected async Task btnCancelPop()
        {

            this.popupAdmView = false;
        }
        //AGREGAR FUNCIONES DEL DETALLE DETALLE VEHICULOS FIN-------------------------


        //---------AGREGAR FUNCIONES DEL DETALLE DETALLE  MAQUINARIAS INICIO--------------------------
        private async Task onTablaAsyncmaquinariaDetalle(EditContext context)
        {
            await SaveMaquinariaDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveMaquinariaDetalle()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqCaractMaquinaria", new { maqCaractMaquinaria = _maqCaractMaquinaria });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncdetalle(_TituloPopup2);
                    _maqCaractMaquinaria = new MaqCaractMaquinariaDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                }
                else
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }

                // _navMgr.NavigateTo("/Afiliacion/Empresas", true);
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task onTablaAsyncdetalleMaquinaria(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqCaractMaquinariaDto>>("MaqCaractMaquinaria/" + id);

                if (_result.State != State.Success)
                {
                    listadetallesMaquinaria = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }
                listadetallesMaquinaria = _result.Data;
                //_MessageShow(id.ToString(), State.Success);
                
              
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        public async Task ShowBtnEliminaDetalleMaquinaria(int idExtraccion)
        {
            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqCaractMaquinaria", idExtraccion);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncdetalle(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        protected async Task EditHorExtracciondetalle(MaqCaractMaquinariaDto DtoMaquinariadetalle)
        {

            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("MaqCaractVehiculo", DtoMaquinariadetalle, DtoMaquinariadetalle.IdmaqCaractMaquinaria);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    DtoMaquinariadetalle.IdmaqCaractMaquinaria = _update.Data;
                    DtoMaquinariadetalle.VerDetalle = !DtoMaquinariadetalle.VerDetalle;
                }
                else
                {
                    _MessageShow(_update.Message, _update.State);
                }
            }
            catch (Exception e)
            {
                _DialogShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        }
        //---------AGREGAR FUNCIONES DEL DETALLE DETALLE  MAQUINARIAS FIN FIN FIN--------------------------

        //---------AGREGAR FUNCIONES DEL DETALLE DETALLE  INFRAESTRUCTURA INICIO--------------------------
        private async Task onTablaAsynCInfraestructuraDetalle(EditContext context)
        {
            await SaveInfraestructuraDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveInfraestructuraDetalle()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqCaractInfra", new { maqCaractInfra = _maqCaractInfra });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncdetalle(_TituloPopup2);
                    _maqCaractInfra = new MaqCaractInfraDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                }
                else
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }

                // _navMgr.NavigateTo("/Afiliacion/Empresas", true);
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task onTablaAsyncdetalleInfra(int id)
        {
          
            try
            {
                var _result = await _Rest.GetAsync<List<MaqCaractInfraDto>>("MaqCaractInfra/"+id);
                //codigo para ver si esta guardando 
                //_MessageShow("hola", State.Success);
                if (_result.State != State.Success)
                {
                    listadetallesInfra = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }
                //_MessageShow(id.ToString(), State.Success);  
                listadetallesInfra = _result.Data;
                //string clienteJson = JsonConvert.SerializeObject(listadetallesInfra);
                //_MessageShow(clienteJson, State.Warning);
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        public async Task ShowBtnEliminaDetalleInfra(int idExtraccion)
        {
            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqCaractInfra", idExtraccion);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncdetalle(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        //---------AGREGAR FUNCIONES DEL DETALLE DETALLE  INFRAESTRUCTURA fIN--------------------------



        //---------AGREGAR DETALLES DE ELEMENTO  DE ELEMENTO INICIO--------------------------
        private void Expandelement()
        {
            popupAdmView1 = true;
        }
        protected async Task ShowBtnaddElementoAsync(int v_Id)
        {

            var vAfiliacion = listadetallesMaqMaquinariaElemento.First(f => f.Idmaquinaria == v_Id);
            Expandelement();
            _TituloPopup = "REGISTRO - ELEMENTOS ";
            _TituloPopup1 = "ELEMENTOS";
            
            await onTablaAsyncdetalleMaqMaquianriaElemento(vAfiliacion.Idmaquinaria);
            StateHasChanged();
            _TituloPopup2 = vAfiliacion.Idmaquinaria;
            this.popupAdmView1 = true;
        }
        protected async Task btnCancelPop1()
        {

            this.popupAdmView1 = false;
        }
        protected async Task onTablaAsyncdetalleMaqMaquianriaElemento(int id)
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<MaqMaquinaElementoDto>>($"MaqMaquinaElemento/{id}");
                _Loading.Hide();

                if (_result.State != State.Success)
                {
                    listadetallesMaqMaquinariaElemento = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }
                listadetallesMaqMaquinariaElemento = _result.Data;
                //_MessageShow(id.ToString(), State.Success);


            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        }
        //---------AGREGAR DETALLES DE ELEMENTO  DE ELEMENTO fIN--------------------------
        protected async Task GetArea()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Maquinaria/area");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                AreaList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task GetProceso()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Maquinaria/proceso");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                procesosList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
      
        protected async Task GetTipoMaquinaria()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Maquinaria/Tipomaquinaria");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                TipoMaquinaList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected override async void OnInitialized()
        {

            await onTablaAsyncMaquinas();
            

            await GetArea();
            jsonColor = System.Text.Json.JsonSerializer.Serialize(AreaList);
            await GetProceso();
            jsonProceso = System.Text.Json.JsonSerializer.Serialize(procesosList);
           
            await GetTipoMaquinaria();
            jsonTipoMaquina = System.Text.Json.JsonSerializer.Serialize(TipoMaquinaList);


            //MOSTRAR DATOS DEL DTO

            StateHasChanged();   
        }

        private async Task OnValidMaquinariaNuevo(EditContext context)
        {
            await SavePersona();
            Console.WriteLine("OnValidMaquinariaNuevo");
        }
      


        protected async Task onTablaAsyncMaquinas()
        {
            try
            {
                _Loading.Show(); 
                var _result = await _Rest.GetAsync<List<MaquinariaDto>>("Maquinaria/Get");
                
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                maquinaria = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task SavePersona()
        {
            try
            {
                _Loading.Show();
                Console.WriteLine(".........");
                var vrespost = await _Rest.PostAsync<int>("Maquinaria", new { _Maquinaria =  _maquinarianuevo} );
                Console.WriteLine(vrespost.Message);
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncMaquinas();
                    _MessageShow("<b>Registro exitoso</b>",State.Success);
                    _maquinarianuevo = new MaquinariaDto();
                    return;
                }

                vrespost.Errors.ForEach(x =>
                {
                    _MessageShow(x, State.Warning);
                });
                return;
                
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task EditPersona(MaquinariaDto dtoPersona)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("Maquinaria", dtoPersona, dtoPersona.Idmaquinaria);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dtoPersona.Idmaquinaria = _update.Data;
                    dtoPersona.VerDetalle = !dtoPersona.VerDetalle;
                }
                else
                {
                    _MessageShow(_update.Message, _update.State);
                }
            }
            catch (Exception e)
            {
                _DialogShow(e.Message, State.Error);
            }
            finally
            {
                _Loading.Hide();
            }
        }
        public async Task ShowBtnEliminaPersona(int idPersona)
        {


            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("Maquinaria", idPersona);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncMaquinas();
                    StateHasChanged();
                }
            });
        }
        protected void ShowBtnEditCancelPersona(int v_idpersona)
        {
            var vpersona = maquinaria.First(f => f.Idmaquinaria == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }
        protected void ShowBtnEdit(int v_idpersona)
        {
            var vpersona = maquinaria.First(f => f.Idmaquinaria == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }
        // ---------------------- SECCIÓN DE FILE UPLOAD ----------------------------
        public async Task OnFileChange(MaquinariaDto aa, InputFileChangeEventArgs e)
        {

            var files = e.GetMultipleFiles();

            if (files != null && files.Count > 0)
            {
                var file = files[0];

                // Cambiar el límite de tamaño del archivo aquí (en bytes)
                const long maxFileSize = 7 * 1024 * 1024; // 7 MB

                if (file != null)
                {
                    if (file.Size > maxFileSize)
                    {

                        // Console.WriteLine("El archivo es demasiado grande. El tamaño máximo permitido es de 6 MB.");
                        _MessageShow("El archivo es demasiado grande. El tamaño máximo permitido es de 6 MB.", State.Warning);
                    }
                    else
                    {
                        _Loading.Show();
                        using (var stream = file.OpenReadStream(maxFileSize))
                        {
                            // Cargar la imagen y reducir su tamaño
                            using (var image = await Image.LoadAsync(stream))
                            {
                                // Cambiar el tamaño máximo permitido para la imagen aquí (en píxeles)
                                const int maxImageWidth = 1200;
                                const int maxImageHeight = 1200;

                                image.Mutate(x => x.Resize(new ResizeOptions
                                {
                                    Size = new SixLabors.ImageSharp.Size(maxImageWidth, maxImageHeight),
                                    Mode = ResizeMode.Max
                                }));

                                // Convertir la imagen a base64
                                using (var memoryStream = new System.IO.MemoryStream())
                                {
                                    // Ajustar la calidad de la imagen aquí (valores entre 0 y 100)
                                    var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = 90 };
                                    await image.SaveAsync(memoryStream, encoder);
                                    aa.FotoEquipo = Convert.ToBase64String(memoryStream.ToArray());
                                    _maquinarianuevo.FotoEquipo = aa.FotoEquipo;
                                    string base64Image = "data:image;base64," + aa.FotoEquipo;
                                    ImageBase64 = base64Image;
                                }
                            }
                            _Loading.Hide();
                        }
                    }
                }
            }
        }

        //----------------------- FIN SECCIÓN FILE UPLOAD -----------------------------
        protected async void Reporte()
        {
            await JSRuntime.InvokeVoidAsync("CargaReportePop", new { ruta = "/reports/ENVIBOL/PRODUCCION/Almacen/Reporte_actual_dia" });
        }
    }
}

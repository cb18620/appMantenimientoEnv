using Infraestructura.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing; 
using SixLabors.ImageSharp.Web;
using Infraestructura.Models.Clasificador;
using Infraestructura.Models.Maquinaria;
using Infraestructura.Models.Vistas;
using Microsoft.JSInterop;
using Dominio.Entities;

namespace Server.Pages.Pages.Maquinaria
{
    public partial class Maquinaria
    {
        public MaquinariaDto _maquinarianuevo = new MaquinariaDto();

        private static List<MaqCaractVehiculoDto> listadetalles { get; set; }
        private static List<MaqCaractInfraDto> listadetallesInfra { get; set; }
        private static List<MaqCaractMaquinariaDto> listadetallesMaquinaria { get; set; }
        private static List<MaqImpactoRcmDto> listaImapctoRcm { get; set; }
        public static List<MaquinariaDto> maquinaria { get; set; }
        public static List<MaquinariaDto> GetListMaquinaria { get; set; }
        public static List<MaqvImpactoRcmDto> ListVMaquinaria { get; set; }

        public MaqCaractVehiculoDto _maqCaractVehiculo = new MaqCaractVehiculoDto();
        public MaqCaractMaquinariaDto _maqCaractMaquinaria = new MaqCaractMaquinariaDto();
        public MaqCaractInfraDto _maqCaractInfra = new MaqCaractInfraDto();
        public MaqMaquinaElementoDto _MaqMaquinaElemento = new MaqMaquinaElementoDto();

        public MaqvImpactoRcmDto _maquinariaSeleccionada = new MaqvImpactoRcmDto();

        private List<MaqMaquinaElementoDto> listadetallesMaqMaquinariaElemento;
        public MaqMaquinaElementoDto _maqDetalleElement = new MaqMaquinaElementoDto();
        public MaqImpactoRcmDto _maqDetalleImpacto = new MaqImpactoRcmDto();

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
        private string maquinasSearchString = "";
        private bool FilterByMaquinaria(MaqvImpactoRcmDto element)
        {
            if (string.IsNullOrWhiteSpace(maquinasSearchString))
                return true;
            bool matchesNombreMaquina = element.NombreMaquina?.ToString().Contains(maquinasSearchString, StringComparison.OrdinalIgnoreCase) ?? false;
            bool matchesIdentificador = element.Identificador?.ToString().Contains(maquinasSearchString, StringComparison.OrdinalIgnoreCase) ?? false;
            bool matchesDesProceso = element.DesProceso?.ToString().Contains(maquinasSearchString, StringComparison.OrdinalIgnoreCase) ?? false;
            return matchesNombreMaquina || matchesIdentificador || matchesDesProceso;
        }

        private bool popupAdmView { get; set; } = false;


        string _TituloPopup; string _TituloPopup1; int _TituloPopup2;
        private string searchString = "";
        public string jsonColor { get; set; }
        public string jsonSup { get; set; }
        public string jsonProceso { get; set; }
        public string jsonTipoMaquina { get; set; }
        public string jsonElemento { get; set; }
        public string jsonRepuesto { get; set; }
        public string jsonConsumible { get; set; }
        public string jsonRcm { get; set; }
        public string jsonRcmClasificadorValor { get; set; }



        public string ImageBase64 { get; set; }

        private static List<GenClasificadorDto> AreaList { get; set; }
        private static List<GenClasificadorDto> procesosList { get; set; }
        private static List<GenClasificadorDto> SupList { get; set; }
        private static List<GenClasificadorDto> TipoMaquinaList { get; set; }
        private static List<GenClasificadorDto> RcmClasificadorValorList { get; set; }
        private static List<ConfigImpactoDto> ConfigImpactoList { get; set; }
        private static List<MaqElementoDto> TipoElementoList { get; set; }
        private static List<MaqRepuestoDto> TipoRepuestoList { get; set; }
        private static List<MaqConsumibleDto> TipoConsumibleList { get; set; }
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
                var _result = await _Rest.GetAsync<List<MaqCaractVehiculoDto>>("MaqCaractVehiculo/" + id);

                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                listadetalles = _result.Data;

                StateHasChanged();

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
        protected async Task ShowBtnadd(MaqvImpactoRcmDto maquinariaSeleccionada, int v_Id)
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
                _maqCaractMaquinaria.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqCaractMaquinaria = _maqCaractMaquinaria };
                var vrespost = await _Rest.PostAsync<int?>("MaqCaractMaquinaria", requestObj);
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncdetalleMaquinaria(_TituloPopup2);
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
                    await onTablaAsyncdetalleMaquinaria(_TituloPopup2);
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
        public async Task ShowBtnEliminarmaquiniariaDetalle(int idExtraccion)
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
                    await onTablaAsyncdetalleMaquinaria(_TituloPopup2);
                    StateHasChanged();
                }
            });
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
                _maqCaractInfra.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqCaractInfra = _maqCaractInfra };
                var vrespost = await _Rest.PostAsync<int?>("MaqCaractInfra", requestObj);
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncdetalleInfra(_TituloPopup2); // Esto debería actualizar la UI con los nuevos detalles
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
                var _result = await _Rest.GetAsync<List<MaqCaractInfraDto>>("MaqCaractInfra/" + id);
                //codigo para ver si esta guardando 
                //_MessageShow("hola", State.Success);
                if (_result.State != State.Success)
                {
                    listadetallesInfra = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }
 
                listadetallesInfra = _result.Data;

                StateHasChanged();
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
                    await onTablaAsyncdetalleInfra(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        //---------AGREGAR FUNCIONES DEL DETALLE DETALLE  INFRAESTRUCTURA fIN--------------------------


        //---------AGREGAR DETALLES DE IMPACTO  DE IMPACTO INICIO--------------------------
        protected async Task GetListaImpactoRcmAsync(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqImpactoRcmDto>>($"MaqImpactoRcm/{id}");
                if (_result.State != State.Success)
                {
                    listaImapctoRcm = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }

                listaImapctoRcm = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        private async Task onTablaAsyncImpactoDetalle(EditContext context)
        {
            await SaveListaImpactoRcmAsync();
            Console.WriteLine("OnValidAMedidaNuevo");


        }

        protected async Task SaveListaImpactoRcmAsync()
        {
            try
            {
                _Loading.Show();
                _maqDetalleImpacto.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqImpacto = _maqDetalleImpacto };
                var vrespost = await _Rest.PostAsync<int?>("MaqImpactoRcm", requestObj);
                _Loading.Hide();

                if (vrespost.State == State.Success)
                {

                    await GetListaImpactoRcmAsync(_TituloPopup2);
                    _maqDetalleImpacto = new MaqImpactoRcmDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                    StateHasChanged();
                }
                else
                {
                    vrespost.Errors.ForEach(x => _MessageShow(x, State.Warning));
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }


        private bool popupImpactoRcmView = false;
        protected async Task ShowBtnImpactoRcmAsync(int v_Id)
        {
            await GetListaImpactoRcmAsync(v_Id); 

            _TituloPopup = "IMPACTO RCM";
            _TituloPopup1 = "DETALLE RCM";
            _TituloPopup2 = v_Id;

            this.popupImpactoRcmView = true; 
            StateHasChanged();
        }
        protected void btnCancelPop2()
        {
            this.popupImpactoRcmView = false;
            StateHasChanged();
        }

        public async Task ShowBtnEliminaImapcto(int idExtraccion)
        {
            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqImpactoRcm", idExtraccion);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await GetListaImpactoRcmAsync(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        //---------AGREGAR DETALLES DE IMPACTO  DE IMPACTO FIN--------------------------

        //AGREGAR FUNCIONES DEL DETALLE DETALLE  CONSUMIBLES  INICIO
        public static List<MaqMaquinaConsumibleDto> listadetallesMaqMaquinariaConsumibles { get; set; }
        public MaqMaquinaConsumibleDto _postMaqMaquinaConsumible = new MaqMaquinaConsumibleDto();

        private async Task onTablaAsynMaqMaquinaConsumibleDetalle(EditContext context)
        {
            await SaveMaqMaquinaConsumibleDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveMaqMaquinaConsumibleDetalle()
        { 
            try
            {
                _Loading.Show();
                _postMaqMaquinaConsumible.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqMaquinaConsumible = _postMaqMaquinaConsumible };
                var vrespost = await _Rest.PostAsync<int?>("MaqMaquinaConsumible", requestObj);
                _Loading.Hide();

                if (vrespost.State == State.Success)
                {

                    await GetListaConsumibledetalleAsync(_TituloPopup2);
                    _postMaqMaquinaConsumible = new MaqMaquinaConsumibleDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                    StateHasChanged();
                }
                else
                {
                    vrespost.Errors.ForEach(x => _MessageShow(x, State.Warning));
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task GetListaConsumibledetalleAsync(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqMaquinaConsumibleDto>>($"MaqMaquinaConsumible/{id}");
                if (_result.State != State.Success)
                {
                    listadetallesMaqMaquinariaConsumibles = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }

                listadetallesMaqMaquinariaConsumibles = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        public async Task ShowBtnEliminarConsumible(int IdmaqMaquinaConsumible)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqMaquinaConsumible", IdmaqMaquinaConsumible);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await GetListaConsumibledetalleAsync(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        //AGREGAR FUNCIONES DEL DETALLE DETALLE  CONSUMIBLES  FIN

        //AGREGAR FUNCIONES DEL DETALLE DETALLE  REPUESTOS  INICIO
        public static List<MaqMaquinaRepuestoDto> listadetallesMaqMaquinariaRepuestos { get; set; }
        public MaqMaquinaRepuestoDto _postMaqMaquinaRepuesto = new MaqMaquinaRepuestoDto();

    
        protected async Task GetListaRepuestodetalleAsync(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqMaquinaRepuestoDto>>($"MaqMaquinaRepuesto/{id}");
                if (_result.State != State.Success)
                {
                    listadetallesMaqMaquinariaRepuestos = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }

                listadetallesMaqMaquinariaRepuestos = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        private async Task onTablaAsynMaqMaquinaRepuestoDetalle(EditContext context)
        {
            await SaveMaqMaquinaRepuestoDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveMaqMaquinaRepuestoDetalle()
        {
            try
            {
                _Loading.Show();
                _postMaqMaquinaRepuesto.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqMaquinaRepuesto = _postMaqMaquinaRepuesto };
                var vrespost = await _Rest.PostAsync<int?>("MaqMaquinaRepuesto", requestObj);
                _Loading.Hide();

                if (vrespost.State == State.Success)
                {

                    await GetListaRepuestodetalleAsync(_TituloPopup2);
                    _postMaqMaquinaRepuesto = new MaqMaquinaRepuestoDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                    StateHasChanged();
                }
                else
                {
                    vrespost.Errors.ForEach(x => _MessageShow(x, State.Warning));
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        public async Task ShowBtnEliminarRepuesto(int IdmaqMaquinaRepuesto)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqMaquinaRepuesto", IdmaqMaquinaRepuesto);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await GetListaRepuestodetalleAsync(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }
        //AGREGAR FUNCIONES DEL DETALLE DETALLE  REPUESTOS  FIN

        //---------AGREGAR DETALLES DE ELEMENTO  DE ELEMENTO INICIO--------------------------

        private bool popupAdmView1 = false;


        protected async Task ShowBtnaddElementoAsync(int v_Id)
        {
            await OnTablaDetalleMaqMaquinariaElementoAsync(v_Id);
            await GetListaRepuestodetalleAsync(v_Id);
            await GetListaConsumibledetalleAsync(v_Id);
            Expandelement();
            _TituloPopup = "REGISTRO - ELEMENTOS ";
            _TituloPopup1 = "ELEMENTOS";
            _TituloPopup2 = v_Id;
            this.popupAdmView1 = true;
            StateHasChanged();
        }


        private void Expandelement()
        {
            popupAdmView1 = true;
            StateHasChanged();
        }
        protected void btnCancelPop1()
        {
            this.popupAdmView1 = false;
            StateHasChanged();
        }

        private async Task onTablaAsynCElementoDetalle(EditContext context)
        {
            await SaveMaqElementoDetalle();
            Console.WriteLine("OnValidAMedidaNuevo");


        }
        protected async Task SaveMaqElementoDetalle()
        {
            try
            {
                _Loading.Show();
                _maqDetalleElement.Idmaquinaria = _TituloPopup2;
                var requestObj = new { maqElemento = _maqDetalleElement };
                var vrespost = await _Rest.PostAsync<int?>("MaqMaquinaElemento", requestObj);
                _Loading.Hide();

                if (vrespost.State == State.Success)
                {

                    await OnTablaDetalleMaqMaquinariaElementoAsync(_TituloPopup2);
                    _maqDetalleElement = new MaqMaquinaElementoDto();
                    _MessageShow("Agregado Correctamente", State.Success);
                    StateHasChanged();
                }
                else
                {
                    vrespost.Errors.ForEach(x => _MessageShow(x, State.Warning));
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }



        protected async Task OnTablaDetalleMaqMaquinariaElementoAsync(int id)
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqMaquinaElementoDto>>($"MaqMaquinaElemento/{id}");
                if (_result.State != State.Success)
                {
                    listadetallesMaqMaquinariaElemento = null;
                    _DialogShow(_result.Message, _result.State);
                    return;
                }

                listadetallesMaqMaquinariaElemento = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        public async Task ShowBtnEliminarElemento(int IdmaqMaquinaElemento)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqMaquinaElemento", IdmaqMaquinaElemento);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await OnTablaDetalleMaqMaquinariaElementoAsync(_TituloPopup2);
                    StateHasChanged();
                }
            });
        }


        //---------AGREGAR DETALLES DE ELEMENTO  DE ELEMENTO fIN--------------------------
        protected async Task GetRcmClasificadorValor()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Clasificador/rcm");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                RcmClasificadorValorList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task GetConfigImpactoList()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<ConfigImpactoDto>>("ConfigImpacto/ConfigImpacto");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                ConfigImpactoList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
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
        protected async Task GetSup()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Maquinaria/supervicion");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                SupList = _result.Data;
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
        protected async Task GetElemento()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqElementoDto>>("MaqElemento/Get");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                TipoElementoList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        } 
        protected async Task GetRepuesto()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqRepuestoDto>>("MaqRepuesto/Get");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                TipoRepuestoList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task GetConsumible()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<MaqConsumibleDto>>("MaqConsumible/Get");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                TipoConsumibleList = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected override async void OnInitialized()
        {

            //await onTablaAsyncMaquinas();
            await onTablaAsyncVmaquinas();
            await onTablaAsyncGetmaquinas();


            await GetArea();
            jsonColor = System.Text.Json.JsonSerializer.Serialize(AreaList);
            await GetProceso();
            jsonProceso = System.Text.Json.JsonSerializer.Serialize(procesosList);

            await GetSup();
            jsonSup = System.Text.Json.JsonSerializer.Serialize(SupList);

            await GetTipoMaquinaria();
            jsonTipoMaquina = System.Text.Json.JsonSerializer.Serialize(TipoMaquinaList);

            await GetElemento();
            jsonElemento = System.Text.Json.JsonSerializer.Serialize(TipoElementoList); 

            await GetRepuesto();
            jsonRepuesto = System.Text.Json.JsonSerializer.Serialize(TipoRepuestoList);

            await GetConsumible();
            jsonConsumible = System.Text.Json.JsonSerializer.Serialize(TipoConsumibleList);

            await GetConfigImpactoList();
            jsonRcm = System.Text.Json.JsonSerializer.Serialize(ConfigImpactoList);

            await GetRcmClasificadorValor();
            jsonRcmClasificadorValor = System.Text.Json.JsonSerializer.Serialize(RcmClasificadorValorList);

            //MOSTRAR DATOS DEL DTO

            StateHasChanged();
        }

        private async Task OnValidMaquinariaNuevo(EditContext context)
        {
            await SavePersona();
            Console.WriteLine("OnValidMaquinariaNuevo");
        }



        //vISTA MAQUINARIA CON CRITICIDAD
        protected async Task onTablaAsyncVmaquinas()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<MaqvImpactoRcmDto>>("VImpactoRcm/impacto");
                _Loading.Hide();

                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                else
                {
                    // Ordenar la lista en orden descendente por una propiedad, por ejemplo, Idmaquinaria
                    ListVMaquinaria = _result.Data.OrderByDescending(x => x.Idmaquinaria).ToList();
                }
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task onTablaAsyncGetmaquinas()
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
                GetListMaquinaria = _result.Data;
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
                var vrespost = await _Rest.PostAsync<int>("Maquinaria", new { _Maquinaria = _maquinarianuevo });
                Console.WriteLine(vrespost.Message);
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State == State.Success)
                {
                    await onTablaAsyncVmaquinas();
                    _MessageShow("<b>Registro exitoso</b>", State.Success);
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

        protected async Task EditPersona(MaqvImpactoRcmDto dtoPersona)
        {
            try
            {
                _Loading.Show();
                var maquinariaDto = new MaquinariaDto
                {
                    Idmaquinaria = dtoPersona.Idmaquinaria,
                    Descripcion = dtoPersona.Descripcion,
                    NombreMaquina = dtoPersona.NombreMaquina,
                    Modelo = dtoPersona.Modelo,
                    Identificador = dtoPersona.Identificador,
                    Area = dtoPersona.Area,
                    Caracteristicas = dtoPersona.Caracteristicas,
                    Marca = dtoPersona.Marca,
                    Tipo = dtoPersona.Tipo,
                    Ubicacion = dtoPersona.Ubicacion,
                    FotoEquipo = dtoPersona.FotoEquipo,
                    Año = dtoPersona.Año,
                    EntregadoA = dtoPersona.EntregadoA,
                    Funcion = dtoPersona.Funcion,
                    NSerie = dtoPersona.NSerie,
                    Fabricante = dtoPersona.Fabricante,
                    Industria = dtoPersona.Industria,
                    Proveedor = dtoPersona.Proveedor,
                    Origen = dtoPersona.Origen,
                    RecibidoDe = dtoPersona.RecibidoDe,
                    Proceso = dtoPersona.Proceso,
                    VerDetalle = dtoPersona.VerDetalle
                };

                var _update = await _Rest.PutAsync<int>("Maquinaria", maquinariaDto, maquinariaDto.Idmaquinaria);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dtoPersona.Idmaquinaria = _update.Data;
                    dtoPersona.VerDetalle = !dtoPersona.VerDetalle;
                    await onTablaAsyncVmaquinas();
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
      
        protected void ShowBtnEditCancelPersona(int v_idpersona)
        {
            var vpersona = ListVMaquinaria.First(f => f.Idmaquinaria == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }
        protected void ShowBtnEdit(int v_idpersona)
        {
            var vpersona = ListVMaquinaria.First(f => f.Idmaquinaria == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
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
                    await onTablaAsyncVmaquinas();
                    StateHasChanged();
                }
            });
        }
        public async Task repjasper(int IdMaqMaquinaria)
        {

            //Parametros en jasper "orden_produccion"


            await JSRuntime.InvokeVoidAsync("CargaReportePop",
            new
            {            //reports/ENVIBOL/PRODUCCION/Calidad/Inspeccion_critico
                ruta = "/reports/ENVIBOL/MANTENIMIENTO/Catalogo_de_equipos/Ficha_Tecnica",
                idmaquinaria = IdMaqMaquinaria,

            });
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

        public async Task OnFileChange(MaqvImpactoRcmDto context, InputFileChangeEventArgs e)
        {
            var files = e.GetMultipleFiles();

            if (files != null && files.Count > 0)
            {
                var file = files[0];

                const long maxFileSize = 7 * 1024 * 1024; // 7 MB

                if (file != null)
                {
                    if (file.Size > maxFileSize)
                    {
                        _MessageShow("El archivo es demasiado grande. El tamaño máximo permitido es de 6 MB.", State.Warning);
                    }
                    else
                    {
                        _Loading.Show();
                        using (var stream = file.OpenReadStream(maxFileSize))
                        {
                            using (var image = await Image.LoadAsync(stream))
                            {
                                const int maxImageWidth = 1200;
                                const int maxImageHeight = 1200;

                                image.Mutate(x => x.Resize(new ResizeOptions
                                {
                                    Size = new SixLabors.ImageSharp.Size(maxImageWidth, maxImageHeight),
                                    Mode = ResizeMode.Max
                                }));

                                using (var memoryStream = new System.IO.MemoryStream())
                                {
                                    var encoder = new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder { Quality = 90 };
                                    await image.SaveAsync(memoryStream, encoder);
                                    context.FotoEquipo = Convert.ToBase64String(memoryStream.ToArray());
                                    string base64Image = "data:image;base64," + context.FotoEquipo;
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

    }
}

using Infraestructura.Models.Maquinaria;
using System.Collections.Generic;
using Infraestructura.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Server.Models;
using System;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Web;
using Server.Pages.Pages.Persona;
using Dominio.Entities;

namespace Server.Pages.Pages.Maquinaria
{
   public partial class Elemento
    {
        public static List<MaqElementoDto> maqElementos { get; set; }   
          
        public MaqElementoDto _maqElemento = new MaqElementoDto();
        private bool visible;
        void Submit() => visible = false;
        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;
        //AGREGAR FUNCIONES DEL DETALLE DETALLE  CONSUMIBLES INICIO
        public static List<MaqConsumibleDto> ListConsumibles { get; set; }
        public MaqConsumibleDto _PostConsumible = new MaqConsumibleDto();
        protected async Task onTablaAsyncGetConsumibles()
        {
            try
            {
                _Loading.Show();
                var response = await _Rest.GetAsync<List<MaqConsumibleDto>>("MaqConsumible/Get");
                _Loading.Hide();
                if (response.Succeeded)
                {
                    ListConsumibles = response.Data;
                }
                else
                {
                    // Manejo si la respuesta no es exitosa
                    _DialogShow(response.Message, State.Warning);
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                // Aquí deberías tener un manejo de excepciones más detallado
                _MessageShow(e.Message, State.Error);
            }


        }
        private async Task OnValidConsumibleNuevo(EditContext context)
        {
            await SaveConsumible();
            Console.WriteLine("OnValidAMedidaNuevo");
        }
        protected async Task SaveConsumible()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqConsumible", new { maqConsumible = _PostConsumible });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }
                await onTablaAsyncGetConsumibles();
                _MessageShow("<b>Registro exitoso</b>", State.Success);

                // Reiniciar los campos después de un registro exitoso
                _PostConsumible = new MaqConsumibleDto();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        public async Task ShowBtnEliminarConsumible(int IdmaqConsumible)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqConsumible", IdmaqConsumible);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncGetConsumibles();
                    StateHasChanged();
                }
            });
        }
        //AGREGAR FUNCIONES DEL DETALLE DETALLE  CONSUMIBLES FIN

        //AGREGAR FUNCIONES DEL DETALLE DETALLE  REPUESTOS INICIO
        public static List<MaqRepuestoDto> ListRepuestos { get; set; }
        public MaqRepuestoDto _PostRepuesto = new MaqRepuestoDto();
        protected async Task onTablaAsyncGetRepuestos()
        {
            try
            {
                _Loading.Show();
                var response = await _Rest.GetAsync<List<MaqRepuestoDto>>("MaqRepuesto/Get");
                _Loading.Hide();
                if (response.Succeeded)
                {
                    ListRepuestos = response.Data;
                }
                else
                {
                    // Manejo si la respuesta no es exitosa
                    _DialogShow(response.Message, State.Warning);
                }
            }
            catch (Exception e)
            {
                _Loading.Hide();
                // Aquí deberías tener un manejo de excepciones más detallado
                _MessageShow(e.Message, State.Error);
            }

           
        }
        private async Task OnValidRepuestoNuevo(EditContext context)
        {
            await SaveRepuesto();
            Console.WriteLine("OnValidAMedidaNuevo");
        }
        protected async Task SaveRepuesto()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqRepuesto", new { maqRepuesto = _PostRepuesto });
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }
                await onTablaAsyncGetRepuestos();
                _MessageShow("<b>Registro exitoso</b>", State.Success);

                // Reiniciar los campos después de un registro exitoso
                _PostRepuesto = new MaqRepuestoDto();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }

        public async Task ShowBtnEliminarRepuesto(int IdmaqRepuesto)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqRepuesto", IdmaqRepuesto);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncGetRepuestos();
                    StateHasChanged();
                }
            });
        }
        //AGREGAR FUNCIONES DEL DETALLE DETALLE  REPUESTOS FIN

        protected async Task onTablaAsyncElemento()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<MaqElementoDto>>("MaqElemento/Get");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                maqElementos = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }
        protected override async void OnInitialized()
        {
            await onTablaAsyncElemento();           
            await onTablaAsyncGetRepuestos();
           await  onTablaAsyncGetConsumibles();
        }
        private async Task OnValidElementoNuevo(EditContext context)
        {
            await SaveElemento();
            Console.WriteLine("OnValidAMedidaNuevo");
        }
        protected async Task SaveElemento()
        {
            try
            {
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("MaqElemento", new { MaqElemento = _maqElemento } );
                _Loading.Hide();
                _MessageShow(vrespost.Message, vrespost.State);

                if (vrespost.State != State.Success)
                {
                    vrespost.Errors.ForEach(x =>
                    {
                        _MessageShow(x, State.Warning);
                    });
                    return;
                }
                await onTablaAsyncElemento();
                _MessageShow("<b>Registro exitoso</b>", State.Success);

                // Reiniciar los campos después de un registro exitoso
                _maqElemento = new MaqElementoDto();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }
        protected async Task EditElemento(MaqElementoDto dtoElemento)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("MaqElemento", dtoElemento, dtoElemento.Idelemento);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dtoElemento.Idelemento = _update.Data;
                    dtoElemento.VerDetalle = !dtoElemento.VerDetalle;
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

        protected void ShowBtnEdit(int v_idElemento)
        {
            var velemento = maqElementos.First(f => f.Idelemento == v_idElemento);
            velemento.VerDetalle = !velemento.VerDetalle;
        }

        public async Task ShowBtnEliminarElemento(int Idelemento)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("MaqElemento", Idelemento);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncElemento();
                    StateHasChanged();
                }
            });
        }
    }
}

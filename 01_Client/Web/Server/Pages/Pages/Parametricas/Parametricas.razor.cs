using Infraestructura.Abstract;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infraestructura.Models.Clasificador;


namespace Server.Pages.Pages.Parametricas

{
    public partial class Parametricas
    {
        public static List<GenClasificadorDto> genClasificador { get; set; } = new List<GenClasificadorDto>();
        public static List<GenClasificadortipoDto> clasificadortipo { get; set; } = new List<GenClasificadortipoDto>();

       
       
       
        public GenClasificadorDto _ClasificadorNuevo = new GenClasificadorDto();

        private bool visible;
        void Submit() => visible = false;

        private DialogOptions dialogOptions = new() { FullWidth = true };


        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;

        private string searchString = "";

        protected override async void OnInitialized()
        {
            await onTablaAsyncClasificador();
            await onTablaAsyncClasificadorTipo();
      
          
        }

        protected async Task onTablaAsyncClasificador()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Clasificador/GetAllGenClasificador");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                genClasificador = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

      

        protected async Task onTablaAsyncClasificadorTipo()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<GenClasificadortipoDto>>("GenClasificadortipo/GetAllGenClasificadortipo");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                clasificadortipo = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }


     


       

        private async Task OnValidGenClasificador(EditContext context)
        {
            await SaveClasificador();
            Console.WriteLine("OnValidAMedidaNuevo");
        }

        protected void ShowBtnEdit(int v_idpersona)
        {
            var vpersona = genClasificador.First(f => f.IdgenClasificador == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }
        public async Task ShowBtnEliminaClasificador(int idPersona)
        {

            await _MessageConfirm("�Esta seguro de eliminar el registro?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("Clasificador", idPersona);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncClasificador();
                    StateHasChanged();
                }
            });
        }



        protected async Task SaveClasificador()
        {
            try
            {

                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int?>("Clasificador", new { _GenClasificador = _ClasificadorNuevo });


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
                _MessageShow("<b>agregado exitosamente</b>", State.Success);
                await onTablaAsyncClasificador();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }



        protected async Task EditClasificador(GenClasificadorDto dtoTransporte)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("Clasificador", dtoTransporte, dtoTransporte.IdgenClasificador);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dtoTransporte.IdgenClasificador = _update.Data;
                    dtoTransporte.VerDetalle = !dtoTransporte.VerDetalle;
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

        protected void ShowBtnEditCancelClasificador(int v_idpersona)
        {
            var vpersona = genClasificador.First(f => f.IdgenClasificador == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }




    }



}


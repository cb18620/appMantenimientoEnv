using Infraestructura.Abstract;
using Infraestructura.Models.Parametricas;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Web;
using Infraestructura.Models.Clasificador;
using Newtonsoft.Json;

namespace Server.Pages.Pages.Persona
{

    public partial class Persona
    {
        public static List<PersonaDto> persona { get; set; }

        public PersonaDto _PersonaNuevo = new PersonaDto();
        private static List<GenClasificadorDto> EspecialidadList { get; set; }

        private bool visible;
        private void OpenDialog() => visible = true;
        void Submit() => visible = false;

        private DialogOptions dialogOptions = new() { FullWidth = true };

        public string jsonColor { get; set; }

        private bool dense = true;
        private bool hover = true;
        private bool striped = true;
        private bool bordered = true;

        private string searchString = "";

        protected override async void OnInitialized()
        {
            await GetEspecialidad();
            jsonColor = System.Text.Json.JsonSerializer.Serialize(EspecialidadList);
            await onTablaAsyncPersona();
            StateHasChanged();

        }

        protected async Task onTablaAsyncPersona()
        {
            try
            {
                _Loading.Show();
                var _result = await _Rest.GetAsync<List<PersonaDto>>("Persona/GetAllPersona");
                _Loading.Hide();
                if (_result.State != State.Success)
                {
                    _DialogShow(_result.Message, _result.State);
                }
                persona = _result.Data;
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }

        protected async Task GetEspecialidad()
        {
            try
            {
                var _result = await _Rest.GetAsync<List<GenClasificadorDto>>("Persona/especialidad");
                _Loading.Hide();
                //_MessageShow(_result.Message, _result.State);
                if (_result.State != State.Success)
                    return;
                EspecialidadList = _result.Data;

                //MOSTRAR DATOS DEL DTO
                //string clienteJson = JsonConvert.SerializeObject(EspecialidadList);
                //_MessageShow(clienteJson, State.Warning);
                
            }
            catch (Exception e)
            {
                _MessageShow(e.Message, State.Error);
            }
        }


        private async Task OnValidPersonaNuevo(EditContext context)
        {
            await SavePersona();
            Console.WriteLine("OnValidAMedidaNuevo");
        }

        protected void ShowBtnEdit(int v_idpersona)
        {
            var vpersona = persona.First(f => f.Idpersonal == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }
        public async Task ShowBtnEliminaPersona(int idPersona)
        {


            await _MessageConfirm("Esta seguro de eliminar el registro...?", async () =>
            {
                var vrespost = await _Rest.DeleteAsync<int>("Persona", idPersona);
                if (!vrespost.Succeeded)
                {
                    _MessageShow(vrespost.Message, State.Error);
                }
                else
                {
                    _MessageShow(vrespost.Message, vrespost.State);
                    //_RowIdsubPlanificaciondetalle = 0;
                    await onTablaAsyncPersona();
                    StateHasChanged();
                }
            });
        }


        protected async Task SavePersona()
        {
            try
            {  
                _Loading.Show();
                var vrespost = await _Rest.PostAsync<int>("Persona", _PersonaNuevo);
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
                await onTablaAsyncPersona();
                _MessageShow("<b>Registro exitoso</b>", State.Success);

                // Reiniciar los campos después de un registro exitoso
                _PersonaNuevo = new PersonaDto();
            }
            catch (Exception e)
            {
                _Loading.Hide();
                _MessageShow(e.Message, State.Error);
            }
        }


        protected async Task EditPersona(PersonaDto dtoPersona)
        {
            try
            {
                _Loading.Show();
                var _update = await _Rest.PutAsync<int>("Persona", dtoPersona, dtoPersona.Idpersonal);
                if (_update.State == State.Success)
                {
                    _MessageShow(_update.Message, _update.State);
                    dtoPersona.Idpersonal = _update.Data;
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
        protected void ShowBtnEditCancelPersona(int v_idpersona)
        {
            var vpersona = persona.First(f => f.Idpersonal == v_idpersona);
            vpersona.VerDetalle = !vpersona.VerDetalle;
        }

        // ---------------------- SECCIÓN DE FILE UPLOAD ----------------------------
        public async Task OnFileChange(PersonaDto aa, InputFileChangeEventArgs e)
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
                                    aa.Foto = Convert.ToBase64String(memoryStream.ToArray());
                                    _PersonaNuevo.Foto = aa.Foto;
                                    string base64Image = "data:image;base64," + aa.Foto;
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

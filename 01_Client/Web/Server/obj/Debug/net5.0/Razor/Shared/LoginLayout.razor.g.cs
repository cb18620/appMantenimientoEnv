#pragma checksum "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91e29b50805edc76d40ae35f370c9d00cb6bf82a"
// <auto-generated/>
#pragma warning disable 1591
namespace Server.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using MudBlazor.ThemeManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Server;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Server.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Infraestructura.Abstract;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Infraestructura.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Microsoft.Extensions.Localization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Infraestructura.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Server.Shared.Component;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Syncfusion.Blazor.Calendars;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
    public partial class LoginLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<MudBlazor.MudThemeProvider>(0);
            __builder.AddAttribute(1, "Theme", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.MudTheme>(
#nullable restore
#line 4 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                         _currentTheme

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(2, "\r\n");
            __builder.OpenComponent<MudBlazor.MudSnackbarProvider>(3);
            __builder.CloseComponent();
            __builder.AddMarkupContent(4, "\r\n");
            __builder.OpenComponent<MudBlazor.MudDialogProvider>(5);
            __builder.AddAttribute(6, "FullWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean?>(
#nullable restore
#line 6 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                              true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "MaxWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.MaxWidth?>(
#nullable restore
#line 7 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                             MaxWidth.ExtraSmall

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "CloseButton", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean?>(
#nullable restore
#line 8 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                                false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "DisableBackdropClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean?>(
#nullable restore
#line 9 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "NoHeader", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean?>(
#nullable restore
#line 10 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                             false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "Position", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.DialogPosition?>(
#nullable restore
#line 11 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                             DialogPosition.TopCenter

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n");
            __builder.OpenComponent<MudBlazor.MudSnackbarProvider>(13);
            __builder.CloseComponent();
            __builder.AddMarkupContent(14, "\r\n\r\n");
            __builder.AddMarkupContent(15, "<div style=\"position: fixed;top: 81px;text-align: center;align-items: center;width: 100%; \" class=\"d-none d-sm-flex\"><img src=\"svg/logosedemministerio.svg\" height=\"80\" alt=\"Logo Institucional\" style=\"margin: auto;\"></div>\r\n\r\n");
            __builder.OpenComponent<MudBlazor.MudContainer>(16);
            __builder.AddAttribute(17, "MaxWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.MaxWidth>(
#nullable restore
#line 18 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                        MaxWidth.Medium

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(18, "Class", "d-flex align-center");
            __builder.AddAttribute(19, "Style", "height: 100vh; align-items:center");
            __builder.AddAttribute(20, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudPaper>(21);
                __builder2.AddAttribute(22, "Elevation", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 19 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
                         25

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(23, "Class", "pa-0");
                __builder2.AddAttribute(24, "Style", "width: 700px; height: 350px; margin:auto");
                __builder2.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.AddContent(26, 
#nullable restore
#line 20 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
         Body

#line default
#line hidden
#nullable disable
                    );
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(27, "\r\n\r\n");
            __builder.AddMarkupContent(28, "<div style=\"position: fixed;text-align: center;align-items: center;width: 100%;bottom:0\" class=\"d-none d-sm-flex\"><img src=\"svg/empresas.svg\" height=\"80\" alt=\"Logo Institucional\" style=\"margin: auto;\"></div>\r\n\r\n\r\n");
            __builder.OpenComponent<Server.Shared.Component.SiabysLoading>(29);
            __builder.CloseComponent();
            __builder.AddMarkupContent(30, "\r\n");
            __builder.OpenComponent<Server.Shared.Component.SiabysDialog>(31);
            __builder.CloseComponent();
            __builder.AddMarkupContent(32, "\r\n");
            __builder.OpenComponent<Server.Shared.Component.SiabysDialogConfirm>(33);
            __builder.CloseComponent();
            __builder.AddMarkupContent(34, "\r\n\r\n");
            __builder.AddMarkupContent(35, @"<style>
	.mud-breadcrumb-separator {
		padding: 0 6px;
	}

	.mud-breadcrumb-item.mud-disabled > a {
		color: #2261a1;
	}

	.mud-appbar.mud-appbar-dense .mud-toolbar-appbar {
		height: calc(var(--mud-appbar-height) - var(--mud-appbar-height)/3);
	}

	.mud-button-text-transform {
		text-transform: none !important;
	}

	.mud-input>input.mud-input-root, div.mud-input-slot.mud-input-root {
		font-size: 0.75rem !important;
	}

</style>");
        }
        #pragma warning restore 1998
#nullable restore
#line 56 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\LoginLayout.razor"
        private MudTheme _currentTheme = new MudBlazorAdminDashboard();

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender)
			await _auth.LogoutnAsync();
	}

	protected override void OnInitialized()
	{
		StateHasChanged();
	}

	public void _MessageShow(string Message, State state)
	{
		switch (state)
		{
			case State.Success:
				_snackbar.Add(Message, Severity.Success);
				break;
			case State.Warning:
				_snackbar.Add(Message, Severity.Warning);
				break;
			case State.Error:
				_snackbar.Add(Message, Severity.Error);
				break;
			case State.NoData:
				_snackbar.Add(Message, Severity.Info);
				break;
			default:
				_snackbar.Add(Message, Severity.Normal);
				break;
		}
	}

	public void _DialogShow(string Message, State state)
	{
		var parameters = new DialogParameters();
		parameters.Add("message", Message);
		parameters.Add("state", state);
		DialogService.Show<SiabysDialog>("", parameters);
	}

	public async Task _MessageConfirm(string Message, System.Action aceptable)
	{
		var parameters = new DialogParameters();
		parameters.Add("message", Message);
		var dialog = DialogService.Show<SiabysDialogConfirm>("", parameters);
		var result = await dialog.Result;

		if (!result.Cancelled)
		{
			aceptable();
		}
	} 

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IManagerAuthorize _auth { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService DialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackbar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ManagerRest _Rest { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Loading _Loading { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navMgr { get; set; }
    }
}
#pragma warning restore 1591

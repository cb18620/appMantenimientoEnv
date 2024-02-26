// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

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
#nullable restore
#line 3 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\MainLayout.razor"
using Infraestructura.Abstract;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\MainLayout.razor"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\MainLayout.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    public partial class MainLayout : LayoutComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 124 "D:\source\SourceCodeCleanArchi\01_Client\Web\Server\Shared\MainLayout.razor"
       

	MudBreadcrumbs _breadCrumb;

	[Parameter]
	public List<BreadcrumbItem> _items { get; set; }
	protected override void OnAfterRender(bool firstRender)
	{
		_items = new List<BreadcrumbItem>();
		_items.Add(new BreadcrumbItem(text: "", href: "/Home", icon: Icons.Material.Filled.Home));
		var uri = _navMgr.Uri.ToString().Replace(_navMgr.BaseUri, "");
		foreach (var item in uri.Split("/"))
		{
			_items.Add(new BreadcrumbItem(text: CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToLower()), href: "#", disabled: true));
		}
		StateHasChanged();
	}

	[CascadingParameter]
	public Task<AuthenticationState> authenticationState { get; set; }
	private ThemeManagerTheme _themeManager = new ThemeManagerTheme
		{
			Theme = new MudBlazorAdminDashboard(),
			DrawerClipMode = DrawerClipMode.Always,
			FontFamily = "Montserrat",
			DefaultBorderRadius = 6,
			AppBarElevation = 1,
			DrawerElevation = 1
		};

	public bool _drawerOpen = true;
	public bool _themeManagerOpen = false;

	void DrawerToggle()
	{
		_drawerOpen = !_drawerOpen;
	}

	void OpenThemeManager(bool value)
	{
		_themeManagerOpen = value;
	}

	void UpdateTheme(ThemeManagerTheme value)
	{
		_themeManager = value;
		StateHasChanged();
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
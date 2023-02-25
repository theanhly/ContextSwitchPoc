using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class InspectorView
    {
        [Parameter]
        public RenderFragment MainView { get; set; }

        [Parameter]
        public RenderFragment Widgets { get; set; }

        [Parameter]
        public RenderFragment Details { get; set; }
    }
}

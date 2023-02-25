using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public class ViewComponent : IViewContext, IAsyncDisposable
    {
        [Parameter]
        public RenderFragment Widgets { get; set; }

        public override RenderFragment AlternativeView => null;

        public override RenderFragment MainView => null;
    }
}

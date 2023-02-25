using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public abstract class IViewContext : ComponentBase
    {
        [CascadingParameter]
        public ViewContextSwitcher ViewContext { get; set; }

        public event Action<IViewContext> OnViewClickedEventHandler;

        public abstract RenderFragment AlternativeView { get; }

        public abstract RenderFragment MainView { get; }

        public async ValueTask DisposeAsync()
        {
            await this.ViewContext.RemoveView(this);
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await this.ViewContext.RegisterView(this);
        }

        protected void OnViewClicked()
        {
            this.OnViewClickedEventHandler?.Invoke(this);
        }
    }
}

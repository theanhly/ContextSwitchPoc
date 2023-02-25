using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class ViewContextSwitcher : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<List<IViewContext>> OnViewContextChangedCallback { get; set; }

        private List<IViewContext> views = new();

        public async Task RegisterView(IViewContext view)
        {
            this.views.Add(view);
            view.OnViewClickedEventHandler += OnViewChange;
            await this.OnViewContextChanged();
        }

        public async Task RemoveView(IViewContext view)
        {
            if (this.views.Contains(view))
            {
                this.views.Remove(view);
                await this.OnViewContextChanged();
            }
        }

        private async Task OnViewContextChanged()
        {
            await this.OnViewContextChangedCallback.InvokeAsync(this.views);
        }

        private async void OnViewChange(IViewContext sender)
        {
            if (this.views.Contains(sender))
            {
                int indexOfNewContext = this.views.IndexOf(sender);
                this.views[indexOfNewContext] = this.views[0];
                this.views[0] = sender;
                await OnViewContextChanged();
            }
        }
    }
}

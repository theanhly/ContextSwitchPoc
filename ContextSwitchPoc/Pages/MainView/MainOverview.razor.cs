using Microsoft.AspNetCore.Components;
using System.Net.Mail;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class MainOverview
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private List<IViewContext> views = new();

        private string collapse;

        private IViewContext newContext;
        private async void OnViewContextContextChanged(List<IViewContext> views)
        {
            newContext = this.views.Count > 0 ? views[0] : null;
            if (this.views.Count == views.Count)
            {
                this.collapse = "hide";
                this.StateHasChanged();
                await Task.Delay(500);
                this.collapse = string.Empty;
            }

            this.views = new(views);
            this.StateHasChanged();
        }

        private ViewComponent GetMainView()
        {
            if (this.views.Count > 0)
            {
                return this.views[0] as ViewComponent;
            }

            return null;
        }

        private List<IViewContext> GetAlternativeViews()
        {
            return this.views.Skip(1).ToList();
        }

        private string IsNewContext(IViewContext context)
        {
            var test = context.Equals(newContext) ? collapse : string.Empty;
            return test + " alternativeView";
        }
    }
}

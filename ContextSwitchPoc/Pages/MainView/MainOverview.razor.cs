using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class MainOverview
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        private List<IViewContext> views = new();

        private void OnViewContextContextChanged(List<IViewContext> views)
        {
            this.views = views;
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
    }
}

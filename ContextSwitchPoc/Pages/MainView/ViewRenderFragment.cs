using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public class ViewRenderFragment : ViewComponent
    {
        [Parameter]
        public RenderFragment MainContent { get; set; }

        public override RenderFragment AlternativeView => Container(this.MainContent);

        public override RenderFragment MainView => Container(this.MainContent);

        private RenderFragment Container(RenderFragment child) => builder =>
        {
            builder.OpenComponent<ViewContainer>(0);
            builder.AddAttribute(1, nameof(ViewContainer.ChildContent), child);
            builder.AddAttribute(1, nameof(ViewContainer.OnContextSwitchClick), EventCallback.Factory.Create(this, OnViewClicked));
            builder.SetKey(this.MainContent);
            builder.CloseComponent();
        };
    }
}

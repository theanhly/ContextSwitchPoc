using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public class ViewRenderFragment : ViewComponent
    {
        [Parameter, EditorRequired]
        public RenderFragment MainContent { get; set; }

        public override RenderFragment AlternativeView => builder =>
        {
            builder.OpenComponent<AlternativeView>(0);
            builder.AddAttribute(1, nameof(Pages.MainView.AlternativeView.ChildContent), this.MainContent);
            builder.AddAttribute(1, nameof(Pages.MainView.AlternativeView.OnContextSwitchClick), EventCallback.Factory.Create(this, OnViewClicked));
            builder.CloseComponent();
        };

        public override RenderFragment MainView => this.MainContent;
    }
}

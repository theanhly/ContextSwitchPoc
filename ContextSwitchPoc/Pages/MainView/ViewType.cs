using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace ContextSwitchPoc.Pages.MainView
{
    public class ViewType : ViewComponent
    {
        [Parameter, EditorRequired]
        public Type MainContentType { get; set; }

        [Parameter]
        public Dictionary<string, object> MainContentTypeParameters { get; set; }

        [Parameter]
        public Dictionary<string, object> AlternativeContentTypeParameters { get; set; }

        public override RenderFragment AlternativeView => builder =>
        {
            builder.OpenComponent<AlternativeView>(0);
            builder.AddAttribute(1, nameof(Pages.MainView.AlternativeView.OnContextSwitchClick), EventCallback.Factory.Create(this, OnViewClicked));
            builder.AddAttribute(1, nameof(Pages.MainView.AlternativeView.ChildContent), GetMainView(AlternativeContentTypeParameters));
            builder.CloseComponent();
        };

        public override RenderFragment MainView => GetMainView(this.MainContentTypeParameters);

        private RenderFragment GetMainView(Dictionary<string, object> parameters) => builder =>
        {
            builder.OpenRegion(0);
            builder.OpenComponent(1, MainContentType);
            foreach (KeyValuePair<string, object> keyPair in parameters)
            {
                builder.AddAttribute(2, keyPair.Key, keyPair.Value);
            }
            builder.CloseComponent();
            builder.CloseRegion();
        };
    }
}

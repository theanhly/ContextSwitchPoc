using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class AlternativeView : ComponentBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback OnContextSwitchClick { get; set; }

        private async void OnClick()
        {
            await this.OnContextSwitchClick.InvokeAsync();
        }
    }
}

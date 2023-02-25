using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class ViewContainer : ComponentBase
    {
        [CascadingParameter(Name = "ContainerClasses")]
        public string ContainerClasses { get; set; }

        [CascadingParameter(Name = "Key")]
        public IViewContext Key { get; set; }

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

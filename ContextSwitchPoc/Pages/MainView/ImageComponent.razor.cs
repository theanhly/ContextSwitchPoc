using Microsoft.AspNetCore.Components;

namespace ContextSwitchPoc.Pages.MainView
{
    public partial class ImageComponent
    {
        [Parameter]
        public string Width { get; set; }
        
        [Parameter]
        public string Height { get; set; }

    }
}

using PetShop.DataContext.Entities;

namespace PetShop.Models
{
    /// <summary>
    /// Home view model
    /// </summary>
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; } = new List<Slider>();
    }
}

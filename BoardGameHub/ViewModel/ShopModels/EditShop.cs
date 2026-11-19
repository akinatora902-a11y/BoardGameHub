namespace BoardGameHub.ViewModel.ShopModels
{
    public class EditShop
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Owner { get; set; } = null!;
    }
}

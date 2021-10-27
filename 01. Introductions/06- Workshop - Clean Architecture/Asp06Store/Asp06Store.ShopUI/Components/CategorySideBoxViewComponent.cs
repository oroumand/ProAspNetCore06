namespace Asp06Store.ShopUI.Components;
public class CategorySideBoxViewComponent : ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;

    public CategorySideBoxViewComponent(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public IViewComponentResult Invoke()
    {
        var currentCategory = RouteData?.Values["category"];
        ViewBag.Category = currentCategory;
        return View(_categoryRepository.GetAllCategories());
    }
}


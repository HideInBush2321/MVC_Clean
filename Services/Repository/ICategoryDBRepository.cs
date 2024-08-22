namespace Services.BusinessLogic
{
    public interface ICategoryDBRepository
    {
        List<DBcategoryEntity> SelectAllCategories();
    }
}
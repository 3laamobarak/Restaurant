namespace Restaurant.Interfaces
{
    public interface IRestaurantService
    {
        int CreateRestaurant(Models.Restaurant restaurant);
        int DeleteRestaurant(string ID);
        List<Models.Restaurant> GetAllRestaurants();
        Models.Restaurant GetRestaurantById(string ID);
        int UpdateRestaurant(string ID, Models.Restaurant NewRestaurant);
    }
}
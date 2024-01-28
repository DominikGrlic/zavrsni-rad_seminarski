namespace xyz_API.Models;

public static class UserConstants
{
    // - made class 'static' and users list 'readonly'
    public static readonly List<UserModel> Users = new()
    {
        new UserModel()
        {
            UserName = "luka_admin", EmailAddress = "luka.admin@email.com", Password = "My_short_password_is_this_one_keep_it_safe_plz", Role = "Administrator", GivenName = "Luka"
        },
        new UserModel()
        {
            UserName = "ivan_seller", EmailAddress = "ivan.seller@email.com", Password = "My_short_password_is_this_one_keep_it_safe_plz", Role = "Seller", GivenName = "Ivan"
        },
        new UserModel()
        {
            UserName = "marko_buyer", EmailAddress = "marko.buyer@email.com", Password = "My_short_password_is_this_one_keep_it_safe_plz", Role = "Buyer", GivenName = "Marko"
        }
    };  
}
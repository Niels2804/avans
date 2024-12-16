namespace BlazorMqttDatabase.Services;

public interface IUserRepository
{
    public void SaveUser(User user);
    public List<User> GetAllUsers();
}
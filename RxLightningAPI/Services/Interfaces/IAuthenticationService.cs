using RxLightningAPI.Models.DTOs;

namespace RxLightningAPI.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string Login(UserLogin userLogin);
    }
}

using System.Threading.Tasks;

namespace Example.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}

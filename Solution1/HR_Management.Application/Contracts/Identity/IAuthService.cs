using HR_Management.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> login(AuthRequest request);
        Task<RegistrationRequest> register(RegistrationRequest request);
    }
}

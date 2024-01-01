using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localTypeSerivice;
        private readonly IClient _httpClient;
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient httpClient, ILocalStorageService localTypeSerivice, IMapper mapper) : base(httpClient, localTypeSerivice)
        {
            _httpClient = httpClient;
            _localTypeSerivice = localTypeSerivice;
            _mapper = mapper;
        }
        public async Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType)
        {
            try
            {
                var respons = new Response<int>();
                CreateLeaveTypeDTO createLeaveTypeDTO = _mapper.Map<CreateLeaveTypeDTO>(leaveType);
                //TODO Auth
                var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDTO);
                if (apiResponse.Success)
                {
                    respons.Data = apiResponse.Id;
                    respons.Success = true;
                }
                else
                {
                    foreach (var item in apiResponse.Errors) 
                    {
                        respons.ValidationErrors += item + Environment.NewLine;
                    }
                }
            }
            catch (ApiException ex)
            {

                return ConvertApiExcepion<int>(ex);
            }
        }

        public Task DeleteLeaveType(LeaveTypeVM leaveeType)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateLeaveType(LeaveTypeVM leaveeType)
        {
            throw new NotImplementedException();
        }
    }
}

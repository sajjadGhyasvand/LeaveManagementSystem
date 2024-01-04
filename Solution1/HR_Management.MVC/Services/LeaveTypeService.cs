using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using HR_Management.MVC.Services.Base;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System.Diagnostics;

namespace HR_Management.MVC.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        private readonly ILocalStorageService _localTypeSerivice;
        private readonly IClient _httpClient;
        private readonly IMapper _mapper;
        public LeaveTypeService(IClient httpClient, ILocalStorageService localTypeSerivice, IMapper mapper) : base(localTypeSerivice , httpClient)
        {
            _httpClient = httpClient;
            _localTypeSerivice = localTypeSerivice;
            _mapper = mapper;
        }
        public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeVM leaveType)
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
                    return new Response<int> { Success = respons.Success };

                }
                else
                {
                    foreach (var item in apiResponse.Errors) 
                    {
                        respons.ValidationErrors += item + Environment.NewLine;
                    }
                    return new Response<int> { Success = false };
                }
            }
            catch (ApiException ex)
            {

                return ConvertApiExcepion<int>(ex);
            }
        }

        public async Task<Response<int>> DeleteLeaveType(int id)
        {
            try
            {
                await _client.LeaveTypesDELETEAsync(id);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            { 
                return ConvertApiExcepion<int>(ex);
            }
        }

        public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
        {
            var leaveType = await _client.LeaveTypesGETAsync(id);
            return  _mapper.Map<LeaveTypeVM>(leaveType);
        }

        public async Task<List<LeaveTypeVM>> GetLeaveTypes()
        {
            var leaveTypes = await _client.LeaveTypesAllAsync();
            return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
        }

        public async Task<Response<int>> UpdateLeaveType(int id,LeaveTypeVM leaveType)
        {
            try
            {
                LeaveTypeDTO leaveTypeDTO = _mapper.Map<LeaveTypeDTO>(leaveType);
                await _client.LeaveTypesPUTAsync(id, leaveTypeDTO);
                return new Response<int> { Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExcepion<int>(ex);
            }
        }
    }
}

using AutoMapper;
using Bussiness.AutoMapper;
using Common.Enums;
using Common.Shared.Interfaces;
using Common.Shared.Response;
using Data.Models.Security;
using System.Globalization;
using UnitOfWork.UnitOfWork;

namespace Bussiness.Services.Shared
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        protected IMapper _mapper;
        protected IConfigurationProvider _mapConfig;

        protected readonly string _ar;
        protected readonly string _en;
        protected readonly string Culture;
        protected readonly Response _response;

        protected IUnitOfWork _unitOfWork;

        public BaseService()
        {
            _response = new Response();
            _ar = CultureCode.ar.ToString();
            _en = CultureCode.en.ToString();
            Culture = CultureInfo.CurrentUICulture.Name;

            InitializeMapper();
        }

        public BaseService(IUnitOfWork unitOfWork)
        {
            _response = new Response();
            _unitOfWork = unitOfWork;
            _ar = CultureCode.ar.ToString();
            _en = CultureCode.en.ToString();
            Culture = CultureInfo.CurrentUICulture.Name;
            InitializeMapper();
        }

        public void InitializeMapper()
        {
            if (_mapper == null)
            {
                AutoMapperConfiguration.Configure();
                _mapper = AutoMapperConfiguration.Mapper;
                _mapConfig = AutoMapperConfiguration.Mapper.ConfigurationProvider;
            }
        }

        #region Get Current User
        public User GetCurrentUser()
        {
            return _unitOfWork.CurrentUser;
        }

        #endregion

        #region Service Response
        public IResponse ServiceResponse(bool isSuccess, object data)
        {
            _response.IsSuccess = isSuccess;
            _response.Data = data;
            return _response;
        }

        public IResponse ServiceResponse(bool isSuccess, string message)
        {
            _response.IsSuccess = isSuccess;
            _response.Data = null;
            _response.Message = message;
            return _response;
        }

        public IResponse ServiceResponse(object data)
        {
            _response.IsSuccess = false;
            _response.Data = data;
            return _response;
        }

        public IResponse ServiceResponse(bool isSuccess, object data, string message)
        {
            _response.IsSuccess = isSuccess;
            _response.Data = data;
            _response.Message = message;
            return _response;
        }

        public IResponse ServiceResponse(bool isSuccess, object data, string additionalInfo, string message)
        {
            _response.IsSuccess = isSuccess;
            _response.Data = data;
            _response.Message = message;
            _response.AdditionalInfo = additionalInfo;
            return _response;
        }

        #endregion
    }
}

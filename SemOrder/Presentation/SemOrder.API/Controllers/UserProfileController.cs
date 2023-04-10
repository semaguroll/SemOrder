using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SemOrder.API.Controllers.Base;

namespace SemOrder.API.Controllers
{
     [Route("userprofile")]
    public class UserProfileController : BaseApiController<UserProfileController>
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMapper _mapper;

        public UserProfileController(
            IUserProfileRepository userProfileRepository,
            IMapper mapper)
        {
            _userProfileRepository = userProfileRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<WebApiResponse<List<UserProfileResponse>>>> GetUserProfiles()
        {
            var userProfileResult = _mapper.Map<List<UserProfileResponse>>
                (await _userProfileRepository.TableNoTracking.ToListAsync());
            if (userProfileResult.Count > 0)
            {
                return new WebApiResponse<List<UserProfileResponse>>(true, "Success", userProfileResult);
            }
            return new WebApiResponse<List<UserProfileResponse>>(false, "Error");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebApiResponse<UserProfileResponse>>> GetUserProfile(Guid id)
        {
            var userProfileResult = _mapper.Map<UserProfileResponse>(await _userProfileRepository.GetById(id));
            if (userProfileResult != null)
            {
                return new WebApiResponse<UserProfileResponse>(true, "Success", userProfileResult);
            }
            return new WebApiResponse<UserProfileResponse>(false, "Error");
        }

        [HttpPost]
        public async Task<ActionResult<WebApiResponse<UserProfileResponse>>> PostUserProfile(UserProfileRequest request)
        {
            UserProfile entity = _mapper.Map<UserProfile>(request);
            var insertResult = await _userProfileRepository.Add(entity);
            if (insertResult != null)
            {
                UserProfileResponse rm = _mapper.Map<UserProfileResponse>(insertResult);
                return new WebApiResponse<UserProfileResponse>(true, "Success", rm);
            }
            return new WebApiResponse<UserProfileResponse>(false, "Error");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WebApiResponse<UserProfileResponse>>> PutUserProfile(Guid id, UserProfileRequest request)
        {
            if (id != request.Id)
                return BadRequest();

            try
            {
                UserProfile entity = await _userProfileRepository.GetById(id);
                if (entity == null)
                    return NotFound();

                _mapper.Map(request, entity);

                var updateResult = await _userProfileRepository.Update(entity);
                if (updateResult != null)
                {
                    UserProfileResponse rm = _mapper.Map<UserProfileResponse>(updateResult);
                    return new WebApiResponse<UserProfileResponse>(true, "Success", rm);
                }
                return new WebApiResponse<UserProfileResponse>(false, "Error");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<WebApiResponse<UserProfileResponse>>> DeleteUserProfile(Guid id)
        {
            UserProfile entity = await _userProfileRepository.GetById(id);
            if (entity != null)
            {
                if (await _userProfileRepository.Remove(entity))
                    return new WebApiResponse<UserProfileResponse>
                        (true, "Success", _mapper.Map<UserProfileResponse>(entity));
                else
                    return new WebApiResponse<UserProfileResponse>(false, "Error");
            }
            return new WebApiResponse<UserProfileResponse>(false, "Error");
        }

        [HttpGet("activate/{id}")]
        public async Task<ActionResult<WebApiResponse<bool>>> Activate(Guid id)
        {
            bool result = await _userProfileRepository.Activate(id);
            if (result)
                return new WebApiResponse<bool>(true, "Success", true);
            else
                return new WebApiResponse<bool>(false, "Error");
        }

        [HttpGet("getactive")]
        public async Task<ActionResult<WebApiResponse<List<UserProfileResponse>>>> GetActive()
        {
            var userProfileResult = _mapper.Map<List<UserProfileResponse>>
                (await _userProfileRepository.GetActive().ToListAsync());
            if (userProfileResult.Count > 0)
            {
                return new WebApiResponse<List<UserProfileResponse>>(true, "Success", userProfileResult);
            }
            return new WebApiResponse<List<UserProfileResponse>>(false, "Error");
        }
    }
}

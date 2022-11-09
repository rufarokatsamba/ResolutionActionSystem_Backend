using AutoMapper;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region ItemStatus
            CreateMap<ItemStatus, ItemStatusDto>().ReverseMap();
            #endregion

        }

    }
}

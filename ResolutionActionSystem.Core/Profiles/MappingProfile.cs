using AutoMapper;
using ResolutionActionSystem.Application.DTOs.ItemStatus;
using ResolutionActionSystem.Application.DTOs.Meeting;
using ResolutionActionSystem.Application.DTOs.MeetingItem;
using ResolutionActionSystem.Application.DTOs.MeetingType;
using ResolutionActionSystem.Domain.Entities;

namespace ResolutionActionSystem.Application.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region ItemStatus
            CreateMap<ItemStatus, ItemStatusDto>().ReverseMap();
            CreateMap<ItemStatus, CreateItemStatusDto>().ReverseMap();
            CreateMap<ItemStatus, ItemStatusListDto>().ReverseMap();
            #endregion
            #region Meeting
            CreateMap<Meeting, MeetingDto>().ReverseMap();
            CreateMap<Meeting, CreateMeetingDto>().ReverseMap(); 
            #endregion
            #region MeetingType
            CreateMap<MeetingType, MeetingTypeDto>().ReverseMap();
            CreateMap<MeetingType, CreateMeetingTypeDto>().ReverseMap();
            #endregion
            #region MeetingItem
            CreateMap<MeetingItem, MeetingItemDto>().ReverseMap();
            CreateMap<MeetingItem, CreateMeetingItemDto>().ReverseMap();
            CreateMap<MeetingItem, UpdateMeetingItemDto>().ReverseMap();
            #endregion
        }

    }
}

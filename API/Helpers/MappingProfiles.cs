namespace API.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AppUser, MemberDto>()
            .ForMember(d => d.Age,
                o =>
                    o.MapFrom(s => s.DateOfBirth.CalculateAge()))
            .ForMember(d => d.PhotoUrl,
                o =>
                    o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain)!.Url));

        CreateMap<MemberUpdateDto, AppUser>();
        CreateMap<Photo, PhotoDto>();
    }
}
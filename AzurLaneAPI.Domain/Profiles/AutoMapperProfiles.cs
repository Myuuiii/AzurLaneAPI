using AutoMapper;
using AzurLaneAPI.Domain.Dtos.Auth;
using AzurLaneAPI.Domain.Dtos.Faction;
using AzurLaneAPI.Domain.Dtos.Identity;
using AzurLaneAPI.Domain.Dtos.Ship;
using AzurLaneAPI.Domain.Dtos.ShipStats;
using AzurLaneAPI.Domain.Dtos.ShipType;
using AzurLaneAPI.Domain.Dtos.ShipTypeSubclass;
using AzurLaneAPI.Domain.Entities;
using AzurLaneAPI.Domain.Identity;

namespace AzurLaneAPI.Domain.Profiles;

// ReSharper disable once UnusedType.Global
public class AutoMapperProfiles : Profile
{
	public AutoMapperProfiles()
	{
		// Factions
		CreateMap<Faction, FactionDto>();
		CreateMap<FactionCreateDto, Faction>();
		CreateMap<FactionUpdateDto, Faction>();

		// Ship
		CreateMap<Ship, ShipDto>()
			.ForMember(dest => dest.Type,
				opt => opt.MapFrom(src => src.Type.Name))
			.ForMember(dest => dest.Faction,
				opt => opt.MapFrom(src => src.Faction.Name))
			.ForMember(dest => dest.Subclass,
				opt => opt.MapFrom(src => src.Subclass.Name));

		CreateMap<ShipCreateDto, Ship>();
		CreateMap<ShipUpdateDto, Ship>();

		// Ship Stats 
		CreateMap<ShipStats, ShipStatsDto>();
		CreateMap<ShipStatsCreateDto, ShipStats>();
		CreateMap<ShipStatsUpdateDto, ShipStats>();

		// Ship Type
		CreateMap<ShipType, ShipTypeDto>();
		CreateMap<ShipTypeCreateDto, ShipType>();
		CreateMap<ShipTypeUpdateDto, ShipType>();

		// Ship Type Subclass
		CreateMap<ShipTypeSubclass, ShipTypeSubclassDto>();
		CreateMap<ShipTypeSubclassCreateDto, ShipTypeSubclass>();
		CreateMap<ShipTypeSubclassUpdateDto, ShipTypeSubclass>();

		// Auth
		CreateMap<RegisterDto, APIUser>();
		CreateMap<LoginDto, APIUser>();
		CreateMap<APIUser, APIUserDto>();
	}
}
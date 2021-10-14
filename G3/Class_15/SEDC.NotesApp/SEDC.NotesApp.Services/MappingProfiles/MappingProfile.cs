using AutoMapper;
using SEDC.NotesApp.DtoModels;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Models.DtoModels;
using SEDC.NotesApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Note, NoteDto>()
                .ForMember(dest=> dest.NoteText,
                opt => opt.MapFrom(src => src.Text))
                .ForMember(dest => dest.NoteColor,
                opt => opt.MapFrom(src => src.Color))
                .ForMember(dest => dest.Tag,
                opt => opt.MapFrom(src => GetTag((int)src.Tag))
                )
                .ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }

        private string GetTag(int tag)
        {
            if (tag == 3)
            {
                return "Home";
            }
            return "Other";
        }
    }
}

using AutoMapper;
using SEDC.NotesApp.DataModels;
using SEDC.NotesApp.Models;
using System;

namespace SEDC.NotesApp.Services.Helpers.Mappers
{
    public class NoteProfiles : Profile
    {
        public NoteProfiles()
        {
            CreateMap<Note, NoteModel>()
                .ForMember(dest => dest.Id,
                option => option.MapFrom(source => source.Id))
                .ForMember(dest => dest.Text,
                option => option.MapFrom(source => source.Text))
                .ForMember(dest => dest.Color,
                option => option.MapFrom(source => source.Color))
                .ForMember(dest => dest.TagType,
                option => option.MapFrom(source => Enum.ToObject(typeof(TagType), source.Tag)))
                .ForMember(dest => dest.UserId,
                option => option.MapFrom(source => source.UserId))
                .ForMember(dest => dest.DateCreated,
                option => option.MapFrom(source => source.DateCreated))
                .ReverseMap();
        }
    }
}

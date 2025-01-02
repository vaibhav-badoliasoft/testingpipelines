using AutoMapper;
using DataModels;
using BusinessLogic.DTO;

namespace BusinessLogic.AutoMapper
{
    public class MyAutoMapper : Profile
    {
        public MyAutoMapper()
        {
            CreateMap<Model, ModelDTO>().ReverseMap();
        }
    }
}

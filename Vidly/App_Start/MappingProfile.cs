using AutoMapper;
using Vidly.Dtos;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto

            // Basically when your API goes outbound to send stuff to people
            // you'll always pass your Objects through their specific Dto.
            // So it has to map Customer -> CustomerDto.
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MemberShipType, MemberShipTypeDto>();


            // Dto to Domain
            // Turning this around, when your API gets stuff sent by people,
            // all the data passes through the Dto first, and then to the Customer Object.
            // Now if you would copy paste the .ForMember line below the outbound mapping
            // "route" you'd say to your AutoMapper "Hey, don't worry about the id, don't map that."

            // Now if you would perform a GET request with postman at / api / customers,
            // you'd still get all the data. Just that every id is 0,
            // because you told AutoMapper to not care about that.
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}
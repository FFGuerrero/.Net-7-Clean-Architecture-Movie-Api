using AutoMapper;
using MovieApi.Application.Movies.Queries.GetMoviesWithPagination;
using MovieApi.Domain.Entities;

namespace MovieApi.Application.Common.Mappings;
public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<Movie, MovieDto>()
            .ForMember(d => d.Likes, opt => opt.MapFrom(o => o.UserMovieLikes.Count(x => x.MovieId == o.Id)));
    }
}
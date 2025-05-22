using AutoMapper;

namespace SFC.Data.Application.Common.Mappings.Interfaces;
public interface IMapTo<T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
}

public interface IMapToReverse<T>
{
    void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
}
using System.Reflection;

using SFC.Data.Application.Common.Mappings.Base;
using SFC.Data.Application.Features.Data.Queries.GetAll;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;

namespace SFC.Data.Api.Infrastructure.Mappings;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    protected void ApplyCustomMappings()
    {
        #region Complex types        

        // contracts
        CreateMapDataContracts();

        #endregion Complex types
    }

    private void CreateMapDataContracts()
    {
        CreateMap<DataValueDto, SFC.Data.Contracts.Models.Data.DataValue>();
        CreateMap<StatTypeDataValueDto, SFC.Data.Contracts.Models.Data.StatTypeDataValue>()
            .ForMember(p => p.Skill, d => d.MapFrom(z => z.SkillId))
            .ForMember(p => p.Category, d => d.MapFrom(z => z.CategoryId));
        CreateMap<GetAllDataViewModel, SFC.Data.Contracts.Messages.Data.GetAll.GetAllDataResponse>();
    }
}
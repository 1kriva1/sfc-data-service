using System.Reflection;

using SFC.Data.Application.Common.Mappings.Base;
using SFC.Data.Application.Features.Data.Queries.GetAll.Dto;
using SFC.Data.Domain.Common;

namespace SFC.Data.Application.Common.Mappings;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Generic types

        CreateMap(typeof(EnumDataEntity<>), typeof(DataValueDto));

        #endregion Generic types
    }
}
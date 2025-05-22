using System.Reflection;

using SFC.Data.Application.Common.Mappings.Base;
using SFC.Data.Domain.Entities.Data;
using SFC.Data.Messages.Models.Data;

namespace SFC.Data.Infrastructure.Mappings;
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

        // data messages
        CreateMapDataMessages();

        // player messages
        CreateMapPlayerMessages();

        // team messages
        CreateMapTeamMessages();

        // invite messages
        CreateMapInviteMessages();

        // request messages
        CreateMapRequestMessages();

        // scheme messages
        CreateMapSchemeMessages();

        #endregion Complex types
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<FootballPosition, DataValue>();
        CreateMap<GameStyle, DataValue>();
        CreateMap<StatCategory, DataValue>();
        CreateMap<StatSkill, DataValue>();
        CreateMap<StatType, StatTypeDataValue>();
        CreateMap<WorkingFoot, DataValue>();
        CreateMap<Shirt, DataValue>();
    }

    #endregion Data

    #region Player

    private void CreateMapPlayerMessages()
    {
        CreateMap<FootballPosition, SFC.Player.Messages.Models.Data.DataValue>();
        CreateMap<GameStyle, SFC.Player.Messages.Models.Data.DataValue>();
        CreateMap<StatCategory, SFC.Player.Messages.Models.Data.DataValue>();
        CreateMap<StatSkill, SFC.Player.Messages.Models.Data.DataValue>();
        CreateMap<StatType, SFC.Player.Messages.Models.Data.StatTypeDataValue>();
        CreateMap<WorkingFoot, SFC.Player.Messages.Models.Data.DataValue>();
    }

    #endregion Player

    #region Team

    private void CreateMapTeamMessages()
    {
        CreateMap<Shirt, SFC.Team.Messages.Models.Data.DataValue>();
        CreateMap<FootballPosition, SFC.Team.Messages.Models.Data.DataValue>();
        CreateMap<GameStyle, SFC.Team.Messages.Models.Data.DataValue>();
        CreateMap<StatCategory, SFC.Team.Messages.Models.Data.DataValue>();
        CreateMap<StatSkill, SFC.Team.Messages.Models.Data.DataValue>();
        CreateMap<StatType, SFC.Team.Messages.Models.Data.StatTypeDataValue>();
        CreateMap<WorkingFoot, SFC.Team.Messages.Models.Data.DataValue>();
    }

    #endregion Team

    #region Invite

    private void CreateMapInviteMessages()
    {
        CreateMap<Shirt, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<FootballPosition, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<GameStyle, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<StatCategory, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<StatSkill, SFC.Invite.Messages.Models.Data.DataValue>();
        CreateMap<StatType, SFC.Invite.Messages.Models.Data.StatTypeDataValue>();
        CreateMap<WorkingFoot, SFC.Invite.Messages.Models.Data.DataValue>();
    }

    #endregion Invite

    #region Request

    private void CreateMapRequestMessages()
    {
        CreateMap<Shirt, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<FootballPosition, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<GameStyle, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<StatCategory, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<StatSkill, SFC.Request.Messages.Models.Data.DataValue>();
        CreateMap<StatType, SFC.Request.Messages.Models.Data.StatTypeDataValue>();
        CreateMap<WorkingFoot, SFC.Request.Messages.Models.Data.DataValue>();
    }

    #endregion Request

    #region Scheme

    private void CreateMapSchemeMessages()
    {
        CreateMap<Shirt, SFC.Scheme.Messages.Models.Data.DataValue>();
        CreateMap<FootballPosition, SFC.Scheme.Messages.Models.Data.DataValue>();
        CreateMap<GameStyle, SFC.Scheme.Messages.Models.Data.DataValue>();
        CreateMap<StatCategory, SFC.Scheme.Messages.Models.Data.DataValue>();
        CreateMap<StatSkill, SFC.Scheme.Messages.Models.Data.DataValue>();
        CreateMap<StatType, SFC.Scheme.Messages.Models.Data.StatTypeDataValue>();
        CreateMap<WorkingFoot, SFC.Scheme.Messages.Models.Data.DataValue>();
    }

    #endregion Scheme
}
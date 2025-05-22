using AutoMapper;

using SFC.Data.Application.Interfaces.Data.Models;
using SFC.Data.Messages.Events.Data;
using SFC.Data.Messages.Models.Data;

using InviteDataValue = SFC.Invite.Messages.Models.Data.DataValue;
using InviteInitializeData = SFC.Invite.Messages.Commands.Data.InitializeData;
using InviteStatTypeDataValue = SFC.Invite.Messages.Models.Data.StatTypeDataValue;
using PlayerDataValue = SFC.Player.Messages.Models.Data.DataValue;
using PlayerInitializeData = SFC.Player.Messages.Commands.Data.InitializeData;
using PlayerStatTypeDataValue = SFC.Player.Messages.Models.Data.StatTypeDataValue;
using RequestDataValue = SFC.Request.Messages.Models.Data.DataValue;
using RequestInitializeData = SFC.Request.Messages.Commands.Data.InitializeData;
using RequestStatTypeDataValue = SFC.Request.Messages.Models.Data.StatTypeDataValue;
using SchemeDataValue = SFC.Scheme.Messages.Models.Data.DataValue;
using SchemeInitializeData = SFC.Scheme.Messages.Commands.Data.InitializeData;
using SchemeStatTypeDataValue = SFC.Scheme.Messages.Models.Data.StatTypeDataValue;
using TeamDataValue = SFC.Team.Messages.Models.Data.DataValue;
using TeamInitializeData = SFC.Team.Messages.Commands.Data.InitializeData;
using TeamStatTypeDataValue = SFC.Team.Messages.Models.Data.StatTypeDataValue;

namespace SFC.Data.Infrastructure.Extensions;
public static class MessagesExtensions
{
    public static DataInitialized BuildDataInitializedEvent(this IMapper mapper, GetAllDataModel model)
    {
        DataInitialized message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<DataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<DataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<DataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<DataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<StatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<DataValue>>(model.WorkingFoots),
            Shirts = mapper.Map<IEnumerable<DataValue>>(model.Shirts)
        };

        return message;
    }

    public static PlayerInitializeData BuildPlayerInitializeDataCommand(this IMapper mapper, GetPlayerDataModel model)
    {
        PlayerInitializeData message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<PlayerDataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<PlayerDataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<PlayerDataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<PlayerDataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<PlayerStatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<PlayerDataValue>>(model.WorkingFoots)
        };

        return message;
    }

    public static TeamInitializeData BuildTeamInitializeDataCommand(this IMapper mapper, GetTeamDataModel model)
    {
        TeamInitializeData message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<TeamDataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<TeamDataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<TeamDataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<TeamDataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<TeamStatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<TeamDataValue>>(model.WorkingFoots),
            Shirts = mapper.Map<IEnumerable<TeamDataValue>>(model.Shirts)
        };

        return message;
    }

    public static InviteInitializeData BuildInviteInitializeDataCommand(this IMapper mapper, GetInviteDataModel model)
    {
        InviteInitializeData message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<InviteDataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<InviteDataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<InviteDataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<InviteDataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<InviteStatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<InviteDataValue>>(model.WorkingFoots),
            Shirts = mapper.Map<IEnumerable<InviteDataValue>>(model.Shirts),
        };

        return message;
    }

    public static RequestInitializeData BuildRequestInitializeDataCommand(this IMapper mapper, GetRequestDataModel model)
    {
        RequestInitializeData message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<RequestDataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<RequestDataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<RequestDataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<RequestDataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<RequestStatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<RequestDataValue>>(model.WorkingFoots),
            Shirts = mapper.Map<IEnumerable<RequestDataValue>>(model.Shirts)
        };

        return message;
    }

    public static SchemeInitializeData BuildSchemeInitializeDataCommand(this IMapper mapper, GetSchemeDataModel model)
    {
        SchemeInitializeData message = new()
        {
            FootballPositions = mapper.Map<IEnumerable<SchemeDataValue>>(model.FootballPositions),
            GameStyles = mapper.Map<IEnumerable<SchemeDataValue>>(model.GameStyles),
            StatCategories = mapper.Map<IEnumerable<SchemeDataValue>>(model.StatCategories),
            StatSkills = mapper.Map<IEnumerable<SchemeDataValue>>(model.StatSkills),
            StatTypes = mapper.Map<IEnumerable<SchemeStatTypeDataValue>>(model.StatTypes),
            WorkingFoots = mapper.Map<IEnumerable<SchemeDataValue>>(model.WorkingFoots),
            Shirts = mapper.Map<IEnumerable<SchemeDataValue>>(model.Shirts)
        };

        return message;
    }
}
using SFC.Data.Application.Interfaces.Persistence.Context;
using SFC.Data.Application.Interfaces.Persistence.Repository.Common;
using SFC.Data.Domain.Entities.Data;

namespace SFC.Data.Application.Interfaces.Persistence.Repository.Data;
public interface IGameStyleRepository : IRepository<GameStyle, IDataDbContext, GameStyleEnum> { }
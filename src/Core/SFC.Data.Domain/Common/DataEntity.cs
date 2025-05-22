using SFC.Data.Domain.Common.Interfaces;

namespace SFC.Data.Domain.Common;
public class DataEntity<TId> : BaseEntity<TId>, IDataEntity
{
    public DateTime CreatedDate { get; set; }
}
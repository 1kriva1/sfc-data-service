namespace SFC.Data.Domain.Entities;
public class StatCategory : BaseDataEntity
{
    public ICollection<StatType> Types { get; set; } = new List<StatType>();
}

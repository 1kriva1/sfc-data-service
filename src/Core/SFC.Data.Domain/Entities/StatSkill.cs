namespace SFC.Data.Domain.Entities;
public class StatSkill : BaseDataEntity 
{
    public ICollection<StatType> Types { get; set; } = new List<StatType>();
}

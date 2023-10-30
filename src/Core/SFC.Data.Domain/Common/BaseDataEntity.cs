namespace SFC.Data.Domain.Common;
public class BaseDataEntity : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}

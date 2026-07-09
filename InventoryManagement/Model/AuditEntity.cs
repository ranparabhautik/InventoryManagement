namespace InventoryManagement.Model;

public class AuditEntity:BaseEntity
{
    public string TableName { get; set; }
    public string Action { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public DateTime ChangedAt { get; set; }
}

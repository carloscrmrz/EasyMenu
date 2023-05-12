namespace EasyMenu.Core.Model.Domains;

public class BaseEntity
{
    public DateTime DateOfInsert { get; set; }
    public DateTime? DateOfLastChange { get; set; }
    public int EnteredByUserId { get; set; }
}
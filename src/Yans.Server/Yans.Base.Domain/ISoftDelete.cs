namespace Yans.Base.Domain;

public interface ISoftDelete
{
    bool IsDeleted { get; }
    void SoftDelete();
}

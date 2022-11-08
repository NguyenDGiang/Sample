namespace Sample.Shared.Common.Interfaces
{
    public interface IUserTracking
    {
        string CreateBy { get; set; }
        string LastModifiedBy { get; set; }
    }
}

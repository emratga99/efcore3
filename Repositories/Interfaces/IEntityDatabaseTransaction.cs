namespace efcore3.Repositories
{
    public interface IEntityDatabaseTransaction : IDisposable
    {
        void Commit();
        void RollBack();
    }
}
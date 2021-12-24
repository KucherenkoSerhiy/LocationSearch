namespace Core.Patterns
{
    public interface ISpecification<TV, TP>
    {
        bool IsSatisfiedBy(TV value, TP parameters);
    }
}
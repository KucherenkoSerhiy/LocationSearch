namespace Core.Patterns
{
    public interface IRequestValidator<T>
    {
        void Validate(T valueToValidate);
    }
}
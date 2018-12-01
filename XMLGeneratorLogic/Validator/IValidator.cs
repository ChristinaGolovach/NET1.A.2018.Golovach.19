namespace XMLGeneratorLogic.Validator
{
    public interface IValidator<in TInput>
    {
        string Message { get; }
        bool IsValid(TInput value);
    }
}

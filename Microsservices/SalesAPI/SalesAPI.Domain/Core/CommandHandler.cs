using FluentValidation.Results;

namespace SalesAPI.Domain.Core
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(string message)
        {
             AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit()
        {
            return await Commit("There was an error saving data").ConfigureAwait(false);
        }
    }
}

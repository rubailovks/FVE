using FluentValidation;

namespace FVE.Domain.Validators.Extensions
{
    public static class MustContainsInListValidator
    {
        public static IRuleBuilderOptions<T, TElement> MustContainsInList<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, IEnumerable<TElement> allowedList)
        {
            return ruleBuilder.Must(item => allowedList.Contains(item)).WithMessage((item) => $"Value {item} is invalid");
        }
    }
}

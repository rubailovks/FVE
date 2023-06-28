using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FVE.Domain.Validators.CustomValidators
{
    public static class InListPropertyValidator
    {
        public static IRuleBuilderOptions<T, IList<TElement>> ListMustContain<T, TElement>(this IRuleBuilder<T, IList<TElement>> ruleBuilder, int num)
        {
            return ruleBuilder.Must(list => list.Count < num).WithMessage("The list contains too many items");
        }
    }
}

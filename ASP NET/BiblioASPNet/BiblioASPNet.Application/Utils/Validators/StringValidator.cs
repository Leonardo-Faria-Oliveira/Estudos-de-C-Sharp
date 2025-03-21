using BiblioASPNet.Application.Requests;
using BiblioASPNet.Application.Utils.Attributes;
using FluentValidation;
using Microsoft.Extensions.Options;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;

namespace BiblioASPNet.Application.Utils.Validators
{
    public class StringValidator<J> : AbstractValidator<J> where J : BaseRequest
    {


        public StringValidator()
        {
            foreach (PropertyInfo property in typeof(J).GetProperties())
            {
                Type propertyType = property.PropertyType;

                if (propertyType == typeof(string))
                {
                    bool isOptional = property.GetCustomAttribute<NullableFieldAttribute>() != null;

                    if (!isOptional) 
                    {
                        RuleFor(obj => property.GetValue(obj))
                            .Cascade(CascadeMode.Stop)
                            .NotEmpty()
                            .WithMessage($"O campo {property.Name} não pode ser nulo ou vazio.");
                        RuleFor(obj => property.GetValue(obj))
                            .Must(BeBiggerThan3Caracthers!)
                            .WithMessage($"O campo {property.Name} não pode possuir menos de 3 caracteres.");
                    }
                }
            }
        }


        private bool BeBiggerThan3Caracthers(object arg)
        {
            return arg == null ? false : arg.ToString()!.Length >= 3;
        }



    }


}

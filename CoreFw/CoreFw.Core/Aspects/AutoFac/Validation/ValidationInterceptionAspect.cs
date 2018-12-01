using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using CoreFw.Core.CrossCuttingConcerns.Validation.FluentValidaiton;
using CoreFw.Core.Utilities.Intercepters;
using FluentValidation;

namespace CoreFw.Core.Aspects.AutoFac.Validation
{
  public class ValidationInterceptionAspect : MethodInterception
  {
    private readonly Type _validationType;

    public ValidationInterceptionAspect(Type validatortype)
    {
      if (!typeof(IValidator).IsAssignableFrom(validatortype))
      {
        throw new Exception("Wrong Validation Type");
      }

      _validationType = validatortype;
    }

    protected override void OnBefore(IInvocation invocation)
    {

      //var validator =(IValidator) ServiceTool.ServiceProvider.GetService(_validationType);
      var validator = (IValidator)Activator.CreateInstance(_validationType);
      var entityType = _validationType.BaseType.GetGenericArguments()[0];
      var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

      foreach (var entity in entities)
      {
        ValidationTool.Validate(validator, entity);
      }
    }
  }
}

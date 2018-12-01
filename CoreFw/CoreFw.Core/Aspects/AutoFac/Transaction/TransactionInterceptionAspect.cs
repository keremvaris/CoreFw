using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using Castle.DynamicProxy;
using CoreFw.Core.Utilities.Intercepters;

namespace CoreFw.Core.Aspects.AutoFac.Transaction
{
  public class TransactionInterceptionAspect : MethodInterception
  {
    public override void Intercept(IInvocation invocation)
    {
      using (var transactionScope = new TransactionScope())
      {
        try
        {
          invocation.Proceed();
          transactionScope.Complete();

        }
        catch (Exception)
        {
          transactionScope.Dispose();
          throw;
        }
      }
    }
  }
}

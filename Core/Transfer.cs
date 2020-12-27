using MonyTansfer.Data;
using MonyTansfer.Exeptions;
using MonyTansfer.Models;
using System;
using System.Linq;
using System.Threading;

namespace MonyTansfer.Core
{
    public class Transfer
    {
        private static object _obj = new object();
        private bool isSuccess = false;
        public bool TrasferMoney(string from, string to, decimal amount)
        {
            Thread thread = new Thread(t =>
              {
                  try
                  {
                      lock (_obj)
                      {
                          using (TrasferDbContext context = new TrasferDbContext())
                          {

                              var resultFrom = context.Accounts.Where(x => x.AccoundNumber == from)
                                  .FirstOrDefault();
                              if (resultFrom == null)
                              {
                                  context.Dispose();
                                  throw new TransferExpetion("From not exists");
                              }
                              var resultTo = context.Accounts.Where(x => x.AccoundNumber == to)
                                  .FirstOrDefault();
                              if (resultTo == null)
                              {
                                  context.Dispose();
                                  throw new TransferExpetion("From not exists");
                              }
                              if (resultFrom.Balance < amount)
                              {
                                  context.Dispose();
                                  throw new TransferExpetion("Amount is too match");
                              }
                              resultFrom.Balance -= amount;
                              resultFrom.Balance += amount;
                              var result = context.SaveChanges();

                              if (result < 0)
                              {
                                  isSuccess = false;
                                  context.Dispose();
                                  throw new TransferExpetion("Amount is too match");
                              }
                              isSuccess = true;



                          }
                      }
                  }
                  catch (TransferExpetion ex)
                  {
                      using (TrasferDbContext trasferDb = new TrasferDbContext())
                      {
                          Log log = new Log
                          {
                              isSuccessFul = false,
                              FailedReason = ex.TransferField,
                              FromAcound = from,
                              ToAcound = to,
                              TransferAmount = amount,
                              TransferDate = DateTime.Now.ToUniversalTime()

                          };
                          trasferDb.Logs.Add(log);
                          trasferDb.SaveChanges();

                      }


                  }
              })
                  ;
            thread.Start();
            thread.Join();
            return isSuccess;
        }

    }
}

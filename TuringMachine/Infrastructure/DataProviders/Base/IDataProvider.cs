using TuringMachine.Models;
using System.Data;

namespace TuringMachine.Infrastructure.DataProviders
{
    internal interface IDataProvider
    {
        Rules GetRules();
        Rules GetRules(string alphabet);
        Rules SetRules(DataTable dataTable);
    }
}

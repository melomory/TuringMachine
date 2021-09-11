using System.Data;
using TuringMachine.Models.Base;

namespace TuringMachine.Models
{
    internal class Rules : BaseDataModel
    {
        private DataTable _dataTable;
        public DataTable DataTable
        {
            get => _dataTable;
            set
            {
                if (_dataTable != value)
                {
                    _dataTable = value;
                    OnPropertyChanged();
                }
            }
        }

        public Rules(DataTable dataTable = null)
        {
            DataTable = dataTable;
        }

    }
}

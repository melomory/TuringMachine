using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TuringMachine.Infrastructure.Commands;
using TuringMachine.Infrastructure.DataProviders;
using TuringMachine.Models;
using TuringMachine.ViewModels.Base;


namespace TuringMachine.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Title : string – Window  Title
        /// <summary>
        /// Main Window Title
        /// </summary>
        private string _Title = "Машина Тьюринга";
        public string Title
        {
            get => _Title;
            //set => Set(ref _Title, value);
            set
            {
                if (_Title != value)
                {
                    _Title = value;
                    OnPropertyChanged();
                }

            }
        }
        #endregion

        #region Status : string – App status
        /// <summary>
        /// App status
        /// </summary>
        private string _Status = "Готов";
        public string Status
        {
            get => _Status;
            //set => Set(ref _Status, value);
            set
            {
                if (_Status != value)
                {
                    _Status = value;
                    OnPropertyChanged();
                }

            }
        }
        #endregion

        #region Alphabet : string – Turing machine alphabet
        /// <summary>
        /// Turing machine alphabet
        /// </summary>
        private string _Alphabet = "\u03BBab";
        public string Alphabet
        {
            get => _Alphabet;
            //set => Set(ref _Status, value);
            set
            {
                if (_Alphabet != value)
                {
                    SortedSet<char> sortedSetTmp = new(value);
                    char emptyValue = '\u03BB';
                    StringBuilder sb = new();
                    if (sortedSetTmp.Contains('_') || sortedSetTmp.Contains(emptyValue))
                    {
                        sortedSetTmp.Remove('_');
                        sortedSetTmp.Remove(emptyValue);
                        sb.Append(emptyValue);
                        sb.Append(String.Join("", sortedSetTmp));
                        _Alphabet = sb.ToString();

                    } else
                    {
                        sb.Append(String.Join("", sortedSetTmp));
                    }
                    _Alphabet = sb.ToString();
                    OnPropertyChanged();
                    OnAddRowCommandExecuted(Alphabet);
                }

            }
        }


        #endregion

        #region Word : string – Given word
        /// <summary>
        /// Given word
        /// </summary>
        private string _Word = "abb";
        public string Word
        {
            get => _Word;
            //set => Set(ref _Status, value);
            set
            {
                if (_Word != value)
                {
                    _Word = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion

        #region Rule table : Rules table for Turing machine
        /// <summary>
        /// Rules table for Turing machine
        /// </summary>
        private DataTable _RulesTb;
        public DataTable RulesTb
        {
            get
            {
                return _RulesTb;
            }
            set
            {
                if (_RulesTb != value)
                {
                    _RulesTb = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Report : List<string> – Turing machine report
        /// <summary>
        /// Turing machine report
        /// </summary>
        private List<string> _Report;
        public List<string> Report
        {
            get => _Report;
            //set => Set(ref _Status, value);
            set
            {
                if (_Report != value)
                {
                    var emptyValue = '\u03BB';
                    List<string> tmpList = new();

                    StringBuilder sb = new();
                    foreach (string item in value)
                    {
                        tmpList.Add(item.Replace('_', emptyValue));
                    }
                    _Report = tmpList;
                    OnPropertyChanged();
                }

            }
        }


        #endregion

        #region Commands

        #region CloseAppCommand : ICommand – Command to close the app
        /// <summary>
        /// Commmand to close the app
        /// </summary>
        public ICommand CloseAppCommand { get; }
         
        private void OnCloseAppCommandExecuted(object p) => Application.Current.Shutdown();

        private bool CanCloseAppCommandExecute(object p) => true;
        #endregion

        #region AddColumnCommand : ICommand – Command to add a column to the data table
        /// <summary>
        /// Command to add a column to the data table
        /// </summary>
        public ICommand AddColumnCommand { get; }

        private void OnAddColumnCommandExecuted(object p) {
            RulesTb.Columns.Add(new DataColumn($"Q{RulesTb.Columns.Count}"));
            var tmp = RulesTb;
            RulesTb = null;
            OnPropertyChanged("RulesTb");
            RulesTb = tmp;
            OnPropertyChanged("RulesTb");

        }

        private bool CanAddColumnCommandExecute(object p) => true;
        #endregion

        #region DeleteColumnCommand : ICommand – Command to delete a column from the data table
        /// <summary>
        /// Command to delete a column from the data table
        /// </summary>
        public ICommand DeleteColumnCommand { get; }

        private void OnDeleteColumnCommandExecuted(object p)
        {
            RulesTb.Columns.RemoveAt(RulesTb.Columns.Count - 1);
            var tmp = RulesTb;
            RulesTb = null;
            OnPropertyChanged(nameof(RulesTb));
            RulesTb = tmp;
            OnPropertyChanged(nameof(RulesTb));

        }

        private bool CanDeleteColumnCommandExecute(object p) => true;
        #endregion

        #region AddRowCommand : ICommand – Command to add a row to the data table
        /// <summary>
        /// Command to add a column to a data table
        /// </summary>
        public ICommand AddRowCommand { get; }

        private void OnAddRowCommandExecuted(object p)
        {
            //Rules.Columns.Add(new DataColumn($"Q{Rules.Columns.Count}"));

            RulesTb.Rows.Clear();
            foreach (var letter in Alphabet)
            {
                RulesTb.Rows.Add(RulesTb.NewRow().ItemArray = new object[] { letter });
            }
            var tmp = RulesTb;
            RulesTb = null;
            OnPropertyChanged("Rules");
            RulesTb = tmp;
            OnPropertyChanged("Rules");

        }

        private bool CanAddRowCommandExecute(object p) => true;
        #endregion

        #region RunMachine : ICommand – Command to run Turing machine
        /// <summary>
        /// Command to run Turing machine
        /// </summary>
        public ICommand RunMachineCommand { get; }

        private void OnRunMachineCommandExecuted(object p)
        {
            DataProvider dp = new();
            TMachine tm = new(dp.TranslateForTuringMachine(RulesTb), Word);
            tm.Run();

            Report = tm.Report;
        }

        private bool CanRunMachineCommandExecute(object p) => true;
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands

            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
            AddColumnCommand = new RelayCommand(OnAddColumnCommandExecuted, CanAddColumnCommandExecute);
            AddRowCommand = new RelayCommand(OnAddRowCommandExecuted, CanAddRowCommandExecute);
            DeleteColumnCommand = new RelayCommand(OnDeleteColumnCommandExecuted, CanDeleteColumnCommandExecute);
            RunMachineCommand = new RelayCommand(OnRunMachineCommandExecuted, CanRunMachineCommandExecute);

            #endregion

            DataProvider dp = new();
            RulesTb = dp.GetRules().DataTable;
        }
    } 
}

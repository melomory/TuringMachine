using System.Windows;
using System.Windows.Input;
using TuringMachine.Infrastructure.Commands;
using TuringMachine.ViewModels.Base;
using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TuringMachine.Models;

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
        private string _Alphabet = "ab\u03BB";
        public string Alphabet
        {
            get => _Alphabet;
            //set => Set(ref _Status, value);
            set
            {
                if (_Alphabet != value)
                {
                    var sortedSetTmp = new SortedSet<char>(value);
                    var emptyValue = "\u03BB";
                    _Alphabet = String.Join("", sortedSetTmp).Replace("_", emptyValue);
                    OnPropertyChanged();
                }

            }
        }


        #endregion

        #region Rule table : 
        private List<Rules> _rules;
        public List<Rules> Rules
        {
            get
            {
                return _rules;
            }
            set
            {
                _rules = value;
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

        #endregion





        public MainWindowViewModel()
        {
            #region Commands

            CloseAppCommand = new RelayCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);

            #endregion
            List<Rules> tmp = new();
            tmp.Add(new Models.Rules() { AS = "_", Q1 = "-", Q2 = "a>Q1" });
            tmp.Add(new Models.Rules() { AS = "a", Q1 = "-", Q2 = "a>Q1" });
            tmp.Add(new Models.Rules() { AS = "b", Q1 = "-", Q2 = "a>Q1" });
            Rules = tmp;
        }
    }
}

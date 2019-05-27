using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using videotek.Classes;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class filmViewModel : UtilsBinding
    {
        private bool unBool;

        public bool UnBool { get => unBool; set => SetProperty(ref unBool, value); }

        private ObservableCollection<Media> maListFilm = new ObservableCollection<Media>();

        public ObservableCollection<Media> MaListFilm { get => maListFilm; set => SetProperty(ref maListFilm, value); }

        private string texte = "bouton de test";

        public string Texte { get => texte; set => SetProperty(ref texte, value); }

        public filmViewModel()
        {
            _canExecute = true;
            InitialisationValeursConsultationAsync();
        }
       
        private async void InitialisationValeursConsultationAsync()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> films = context.Medias.ToList();

            foreach (Media film in films)
                MaListFilm.Add(film);
            
        }

        CommandHandler command;
        public CommandHandler Command
       
        {
            get
            {
               return command ?? (command = new CommandHandler(() => MyAction(), _canExecute));
            }
        }

        private bool _canExecute;
        public void MyAction()
        {
            Texte += "PATATEUH";
        }
    }
      
    public class CommandHandler : ICommand
    {
        private Action _action;
        private bool _canExecute;
        public CommandHandler(Action action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _action();
        }
    }

   
}

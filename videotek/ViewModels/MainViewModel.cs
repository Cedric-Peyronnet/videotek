using System;
using System.Windows.Controls;
using videotek.Classes;
using videotek.Frames.Common;
using videotek.Frames.Films;
using videotek.Frames.Series;
using videotek.Utils;

namespace videotek.ViewModels
{
    public class MainViewModel : UtilsBinding
    {
        public Media m = new Media();

        private static MainViewModel MVM;
        
        public MainViewModel()
        {
            MVM = this;
        }

        private bool _canExecute = true;

        private Page pageCourrante;

        public Page PageCourrante { get => pageCourrante; set => SetProperty(ref pageCourrante, value); }

        #region Accueil

        Accueil AC = new Accueil()
         {
            DataContext = new Accueil()
         };

        UtilsCommand commandClicAccueil;
        public UtilsCommand CommandClicAccueil

        {
            
            get
            {
                return commandClicAccueil ?? (commandClicAccueil = new UtilsCommand(() => ClicAccueil(), _canExecute));
            }
        }

        public void ClicAccueil()
        {
          
            PageCourrante = AC;
        }
        #endregion

        #region Serie

        SerieMain SM = new SerieMain()
        {
            DataContext = new SerieMain()
        };

        UtilsCommand commandClicSerie;
        public UtilsCommand CommandClicSerie

        {
            get
            {
                return commandClicSerie ?? (commandClicSerie = new UtilsCommand(() => ClicSerie(), _canExecute));
            }
        }

        public void ClicSerie()
        {
            PageCourrante = SM;
        }
        #endregion
  
        #region Film
        FilmMain FM = new FilmMain()
        {
            DataContext = new filmViewModel(MVM)
            
        };
        
        UtilsCommand commandClicFilm;
        public UtilsCommand CommandClicFilm

        {
            get
            {
                return commandClicFilm ?? (commandClicFilm = new UtilsCommand(() => ClicFilm(), _canExecute));
            }
        }

        public void ClicFilm()
        {
            PageCourrante = FM;
            
           
        }
        #endregion

        #region Saisie 
      
        UtilsCommand commandClicSaisie;
        public UtilsCommand CommandClicSaisie

        {
            get
            {
                return commandClicSaisie ?? (commandClicSaisie = new UtilsCommand(() => ClicSaisie(), _canExecute));
            }
        }

        public void ClicSaisie()
        {
            if (PageCourrante.Equals(FM))
            {
                
                Ajout popup = new Ajout();
                popup.SaisieViewWindow.CloseAction = new Action(popup.Close);
                popup.SaisieViewWindow.FilmViewModel = (filmViewModel)FM.DataContext;
                popup.ShowDialog();
                
            }
        }
        #endregion

    }
}

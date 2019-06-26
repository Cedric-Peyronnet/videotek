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
        private FilmViewModel ContextFilmView;
        public MainViewModel()
        {
            
            AC = new Accueil()
            {
                DataContext = new Accueil()
            };

            ContextFilmView = new FilmViewModel(this);
            FM = new FilmMain()
            {
                DataContext = ContextFilmView

            };

            SM = new SerieMain()
            {
               // DataContext = new SerieMain()
            };
            PageCourrante = AC;
        }

        private bool _canExecute = true;

        #region Element Courrant
        private Media mediaCourrant; 

        public Media MediaCourrant
        {
            get
            {
                return mediaCourrant;
            }

            set
            {
                if (SetProperty(ref mediaCourrant, value))
                {
                    mediaCourrant = value;
                    OnPropertyChanged("UnMediaSelectionne");
                };
            }
        }

        private bool unMediaSelectionne = false;

        public bool UnMediaSelectionne
        {
            get
            {
                return mediaCourrant != null;
            }
            set
            {

                SetProperty(ref unMediaSelectionne, value);
            }
        }


        private Page pageCourrante;

        public Page PageCourrante { get => pageCourrante; set => SetProperty(ref pageCourrante, value); }

        #endregion

        #region Accueil

        Accueil AC; 

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

        SerieMain SM; 

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
        FilmMain FM; 

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

        #region Ajout 

        Saisie Ajout;
        UtilsCommand commandClicAjout;
        public UtilsCommand CommandClicAjout

        {
            get
            {
                return commandClicAjout ?? (commandClicAjout = new UtilsCommand(() => ClicAjout(), _canExecute));
            }
        }

        public void ClicAjout()
        {
            Action close = new Action(() => Ajout.Close());
            
            Ajout = new Saisie()
            {
                
                DataContext = new SaisieMediaViewModel(close, ContextFilmView)
                
            };

            if (PageCourrante.Equals(FM))
            {                
                Ajout.ShowDialog();          
            }
        }
        #endregion

        #region Modification 

        Saisie Modification;
        UtilsCommand commandClicModification;
        public UtilsCommand CommandClicModification

        {
            get
            {
                return commandClicModification ?? (commandClicModification = new UtilsCommand(() => ClicModification(), _canExecute));
            }
        }

        public void ClicModification()
        {
            Action close = new Action(() => Modification.Close());
            Modification = new Saisie()
            {

                DataContext = new SaisieMediaViewModel(close, ContextFilmView, MediaCourrant)
            };

            if (PageCourrante.Equals(FM))
            {
                Modification.ShowDialog();
            }
        }
        #endregion

        #region Consultation 

        Consultation Consult;


        UtilsCommand commandClicConsultation;
        public UtilsCommand CommandClicConsultation

        {
            get
            {
                return commandClicConsultation ?? (commandClicConsultation = new UtilsCommand(() => ClicConsultation(), _canExecute));
            }
        }

        public void ClicConsultation()
        {
            Consult = new Consultation()
            {
                DataContext = new ConsultationViewModel(MediaCourrant)
            };
            PageCourrante = Consult;
        }
        #endregion

        #region Suppression 

        
        UtilsCommand commandClicSupprimer;
        public UtilsCommand CommandClicSupprimer

        {
            get
            {
                return commandClicSupprimer ?? (commandClicSupprimer = new UtilsCommand(() => ClicSupprimer(), _canExecute));
            }
        }

        public async void ClicSupprimer()
        {
            var context = await db.VideoTDbContext.GetCurrent();
            context.Medias.Remove(MediaCourrant);
            context.SaveChanges();
            ContextFilmView.MaListFilm.Remove(MediaCourrant);
        }
        #endregion


    }
}

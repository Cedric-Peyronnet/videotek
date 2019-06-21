﻿using System;
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

        private MainViewModel mainViewModel;

        private bool unBool;

        public bool UnBool { get => unBool; set => SetProperty(ref unBool, value); }

        private bool consulter = false;

        public bool Consulter
        {
            get
            {
                return selectedItem != null;
            }
            set
            {
                
                SetProperty(ref consulter, value);
            }
        }
           

        private ObservableCollection<Media> maListFilm = new ObservableCollection<Media>();

        public ObservableCollection<Media> MaListFilm { get => maListFilm; set => SetProperty(ref maListFilm, value); }

        private string texte = "bouton de test";

        public string Texte { get => texte; set => SetProperty(ref texte, value); }

        private Media selectedItem;
        public Media SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                if (SetProperty(ref selectedItem, value))
                {    
                    selectedItem = value;
                    mainViewModel.m = value;
                    OnPropertyChanged("Consulter");
                };
            }
        }

        public filmViewModel(MainViewModel mvm)
        {
            mainViewModel = mvm;
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


        UtilsCommand command;
        public UtilsCommand Command
       
        {
            get
            {
               return command ?? (command = new UtilsCommand(() => MyAction(), _canExecute));
            }
        }
        

        private bool _canExecute;
        public void MyAction()
        {
            Texte += "PATATEUH";
        }
    } 
}

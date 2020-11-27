using DTO;
using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using TopicWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.ComponentModel;
using Unity;
using Unity.Resolution;
using System.Collections.ObjectModel;

namespace TopicWPF.ViewModels
{
    public class TopicListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private UserManager _manager;
        private ObservableCollection<TopicDTO> _topicList;
        public ObservableCollection<TopicDTO> TopicList
        {
            get { return _topicList; }
            set
            {
                _topicList = value;
                OnPropertyChanged(nameof(TopicList));
            }
        }

        public TopicListViewModel(UserManager manager)
        {
            _manager = manager;
            Update();
        }

        public void Update()
        {
            var topics = _manager.GetAll();
            //TopicList = new ObservableCollection<TopicDTO>(topics);
        }
    }
}

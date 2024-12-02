using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Archivo: ViewModels/MeetingDetailsViewModel.cs
using System.ComponentModel;

namespace Nextmeet
{
    public class MeetingDetailsViewModel : INotifyPropertyChanged
    {
        private DateTime? _selectedDate;
        private string _selectedStartTime;
        private string _selectedEndTime;
        private string _selectedRoomType;
        private string _selectedExtras;
        private string _totalPrice;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime? SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                if (_selectedDate != value)
                {
                    _selectedDate = value;
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public string SelectedStartTime
        {
            get { return _selectedStartTime; }
            set
            {
                if (_selectedStartTime != value)
                {
                    _selectedStartTime = value;
                    OnPropertyChanged(nameof(SelectedStartTime));
                }
            }
        }

        public string SelectedEndTime
        {
            get { return _selectedEndTime; }
            set
            {
                if (_selectedEndTime != value)
                {
                    _selectedEndTime = value;
                    OnPropertyChanged(nameof(SelectedEndTime));
                }
            }
        }

        public string SelectedRoomType
        {
            get { return _selectedRoomType; }
            set
            {
                if (_selectedRoomType != value)
                {
                    _selectedRoomType = value;
                    OnPropertyChanged(nameof(SelectedRoomType));
                }
            }
        }

        public string SelectedExtras
        {
            get { return _selectedExtras; }
            set
            {
                if (_selectedExtras != value)
                {
                    _selectedExtras = value;
                    OnPropertyChanged(nameof(SelectedExtras));
                }
            }
        }

        public string TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                if (_totalPrice != value)
                {
                    _totalPrice = value;
                    OnPropertyChanged(nameof(TotalPrice));
                }
            }
        }

        // Método para notificar que una propiedad ha cambiado
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

using NWJProject1.Models;
using System.ComponentModel;

namespace NWJProject1.DTOs
{
    public class UserDTO : INotifyPropertyChanged
    {
        private int userId;
        private string fullName;
        private string gender;
        private string address;
        private string phoneNumber;
        private string status;
        private int groupId;
        private string groupName;

        public int UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }

        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string Gender
        {
            get => gender;
            set
            {
                gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public int GroupId
        {
            get => groupId;
            set
            {
                groupId = value;
                OnPropertyChanged(nameof(GroupId));
            }
        }

        public string GroupName
        {
            get => groupName;
            set
            {
                groupName = value;
                OnPropertyChanged(nameof(GroupName));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

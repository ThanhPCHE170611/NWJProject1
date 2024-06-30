using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace NWJProject1.Models
{
    public partial class UserGroup : INotifyPropertyChanged
    {
        public UserGroup()
        {
            Users = new HashSet<User>();
        }

        private int _groupId;
        private string _groupName = null!;
        private string _groupDescription = null!;
        private string? _status;

        public event PropertyChangedEventHandler? PropertyChanged;

        public int GroupId
        {
            get => _groupId;
            set
            {
                if (_groupId != value)
                {
                    _groupId = value;
                    OnPropertyChanged(nameof(GroupId));
                }
            }
        }

        public string GroupName
        {
            get => _groupName;
            set
            {
                if (_groupName != value)
                {
                    _groupName = value;
                    OnPropertyChanged(nameof(GroupName));
                }
            }
        }

        public string GroupDescription
        {
            get => _groupDescription;
            set
            {
                if (_groupDescription != value)
                {
                    _groupDescription = value;
                    OnPropertyChanged(nameof(GroupDescription));
                }
            }
        }

        public string? Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual ICollection<User> Users { get; set; }
    }
}

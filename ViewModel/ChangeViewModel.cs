using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GymMembers.Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
namespace GymMembers.ViewModel
{
    /// <summary>
    /// The VM for modifying or removing users.
    /// </summary>
    public class ChangeViewModel : ViewModelBase
    {
        /// <summary>
        /// The currently entered first name in the change window.
        /// </summary>
        private string enteredFName;
        /// <summary>
        /// The currently entered last name in the change window.
        /// </summary>
        private string enteredLName;
        /// <summary>
        /// The currently entered email in the change window.
        /// </summary>
        private string enteredEmail;
        private Member selectedMember;
        /// <summary>
        /// Initializes a new instance of the ChangeViewModel class.
        /// </summary>
        public ChangeViewModel()
        {
            UpdateCommand = new RelayCommand<IClosable>(UpdateMethod);
            DeleteCommand = new RelayCommand<IClosable>(DeleteMethod);
            Messenger.Default.Register<Member>(this, GetSelected);
        }
        /// <summary>
        /// The command that triggers saving the filled out member data.
        /// </summary>
        public ICommand UpdateCommand { get; private set; }
        /// <summary>
        /// The command that triggers removing the previously selected user.
        /// </summary>
        public ICommand DeleteCommand { get; private set; }
        /// <summary>
        /// Sends a valid member to the main VM to replace at the selected index with, then closes the change window.
         /// </summary>
         /// <param name="window">The window to close.</param>
         public void UpdateMethod(IClosable window)
                {
                    try
                    {
                        Messenger.Default.Send(new Member(enteredFName, enteredLName, enteredEmail));
                        window.Close();
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("Fields must be under 25 characters.", "Entry Error");
                    }
                    catch (NullReferenceException)
                    {
                        MessageBox.Show("Fields cannot be empty.", "Entry Error");
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Must be a valid e-mail address.", "Entry Error");
                    }
                }
        /// <summary>
        /// Sends out a message to initiate closing the change window.
        /// </summary>
        /// <param name="window">The window to close.</param>
        public void DeleteMethod(IClosable window)
        {
            if (window != null)
            {
                Messenger.Default.Send("Delete");
                window.Close();
            }
        }
        /// <summary>
        ///Receives a member from the main VM to auto-fill the change box with the currently selected member.
         /// </summary>
         /// <param name="m">The member data to fill in.</param>
         public void GetSelected(Member m)
                {
                selectedMember = m;
                }
        /// <summary>
        /// The currently entered first name in the change window.
        /// </summary>
        public string EnteredFName
        {
            get
            {
                return enteredFName;
            }
            set
            {
                enteredFName = value;
                RaisePropertyChanged("EnteredFName");
            }
        }

    }
}
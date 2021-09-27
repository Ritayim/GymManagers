using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GymMembers.Model
{
    /// <summary>
    /// A class that represents a member of a gym.
    /// </summary>
    public class Member : ObservableObject
    {
        /// <summary>
        /// The member's first name.
        /// </summary>
        private string firstName;
        /// <summary>
        /// The member's last name.
        /// </summary>
        private string lastName;
        private string email;
        private readonly int TEXT_LIMIT = 100;

        public Member() { }
        /// <summary>
        /// Creates a new member.
        /// </summary>
        /// <param name="fName">The member's first name.</param>
        /// <param name="lName">The member's last name.</param>
        /// <param name="mail">The member's e-mail.</param>
        public Member(string fName, string lName, string mail)
        {
            firstName = fName;
            lastName = lName;
            email = mail;
        }

        /// <summary>
        /// A property that gets or sets the member's first name, and makes sure it's not too long.
        /// </summary>
        /// <returns>The member's last name.</returns>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value.Length > TEXT_LIMIT)
                {
                    throw new ArgumentException("Too long");
                }
                if (value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                firstName = value;
            }
        }

        /// <summary>
        /// A property that gets or sets the member's last name, and makes sure it's not too long.
        /// </summary>
        /// <returns>The member's last name.</returns>
        public string LastName
        {
            get
                {
                    return lastName;
                }
                set
                {
                    if (value.Length > TEXT_LIMIT)
                    {
                        throw new ArgumentException("Too long");
                    }
                    if (value.Length == 0)
                    {
                        throw new NullReferenceException();
                    }
                    lastName = value;
                }
            }
        /// <summary>
        /// A property that gets or sets the member's e-mail, and makes sure it's not too long.
         /// </summary>
         /// <returns>The member's e-mail.</returns>
         public string Email
                {
                    get
                    {
                        return email;
                    }
                    set
                    {
                        if (value.Length > TEXT_LIMIT)
                        {
                            throw new ArgumentException("Too long");
                        }
                        if (value.Length == 0)
                        {
                            throw new NullReferenceException();
                        }
                        if (value.IndexOf("@") == -1 || value.IndexOf(".") == -1)
                        {
                            throw new FormatException();
                        }
                        email = value;
                    }
                }
        /// <summary>
        /// Text to be displayed in the list box.
        /// </summary>
        /// <returns>A concatenation of the member's first name, last name, and email.</returns>

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raceup_Autocare
{
    
    class Employee
    {
        private string username;
        private string password;
        private string id;
        private Boolean active;
        private string fname;
        private string lname;
        private string email;
        private string role;
        private DateTime updated;
        private string updateBy;
        private string createdBy;
        private bool signIn;

        private DateTime created;
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Id { get => id; set => id = value; }
        public bool Active { get => active; set => active = value; }
        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Email { get => email; set => email = value; }
        public string Role { get => role; set => role = value; }
        public DateTime Updated { get => updated; set => updated = value; }
        public string UpdateBy { get => updateBy; set => updateBy = value; }
        public DateTime Created { get => created; set => created = value; }
        public string CreatedBy { get => createdBy; set => createdBy = value; }
        public bool SignIn { get => signIn; set => signIn = value; }

        public Employee(string username, string password, string id, bool active, string fname, string lname, 
            string email, string role, DateTime updated, string updateBy, DateTime created, string createdBy)
        {
            this.Username = username;
            this.Password = password;
            this.Id = id;
            this.Active = active;
            this.Fname = fname;
            this.Lname = lname;
            this.Email = email;
            this.Role = role;
            this.Updated = updated;
            this.UpdateBy = updateBy;
            this.Created = created;
            this.CreatedBy = createdBy;
        }

        public Employee() { }

    }
}

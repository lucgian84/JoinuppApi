using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JoinUpp.Utils;


namespace JoinUpp.Models.DataModels
{
    public abstract class UserBase
    {
        [Key]
        public int id_usr { get; set; }

        public string name_usr { get; set; }
        public string surname_usr { get; set; }
        [EmailAddress]
        public string email_usr { get; set; }
        public int fk_prf_usr { get; set; }
        [ForeignKey("fk_prf_usr")]
        public ProfileModel profile { get; set; }
    }

    public class DbUser : UserBase
    {
        private string _password;
        public string password_usr
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value.StrongHash();
            }
        }
    }
}

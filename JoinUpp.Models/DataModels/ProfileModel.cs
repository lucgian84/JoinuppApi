using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JoinUpp.Utils;

namespace JoinUpp.Models.DataModels
{
    public class ProfileModel
    {
        [Key]
        public int id_prf { get; set; }
        public string city_prf { get; set; }
        public string address_prf { get; set; }
        public float lat_prf { get; set; }
        public float long_prf { get; set; }
        public DateTime birthdate_prf { get; set; }
        public string phone_prf { get; set; }
    }
}

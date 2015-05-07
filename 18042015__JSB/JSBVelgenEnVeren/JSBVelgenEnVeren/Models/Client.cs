using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.Models
{
    public class Client
    {
        [ScaffoldColumn(false)]
        public int ClientId { get; set; }
        /*
        [StringLength(50)]
        [Required(ErrorMessage = "Gebruikersnaam is een verplicht veld!")]
        public string Username { get; set; }*/

        [StringLength(100)]
        [Required(ErrorMessage = "Voornaam is een verplicht veld!")]
        public string Voornaam { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Naam is een verplicht veld!")]
        public string Naam { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Adres is een verplicht veld!")]
        public string Adres { get; set; }

        
        [StringLength(4)]
        [Required(ErrorMessage = "Huisnummer is een verplicht veld!")]
        public String Huisnummer { get; set; }

        [StringLength(2)]
        public String Postbus { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Stad is een verplicht veld!")]
        public string Stad { get; set; }

        [StringLength(10)]
        [Required(ErrorMessage = "Postcode is een verplicht veld!")]
        public string PostCode { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Land is een verplicht veld!")]
        public string Land { get; set; }

        [StringLength(30)]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "Email Adres is een verplicht veld!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(20)]        
        public string BTW { get; set; }

        [StringLength(1000)]
        public string Commentaar { get; set; }

        public bool Particulier { get; set; }


    }
}
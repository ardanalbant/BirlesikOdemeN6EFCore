using System;

namespace BirlesikOdemeN6EFCore.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        public string IDENTITYNO { get; set; }
        public string IDENTITYNOVERIFIED { get; set; }
        public string MAIL { get; set; }
        public Nullable<System.DateTime> EKLZMN { get; set; }
        public string EKLKLN { get; set; }
        public Nullable<System.DateTime> GNCZMN { get; set; }
        public string GNCKLN { get; set; }
    }
}

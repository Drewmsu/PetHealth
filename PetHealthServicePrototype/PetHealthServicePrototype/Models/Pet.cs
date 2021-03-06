//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PetHealthServicePrototype.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pet
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public string Status { get; set; }
        public System.DateTime Birthdate { get; set; }
        public string Breed { get; set; }
        public string Photo { get; set; }
        public int AnimalTypeId { get; set; }
    
        public virtual AnimalType AnimalType { get; set; }
        public virtual User User { get; set; }
    }
}

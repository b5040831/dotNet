//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NAA.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class NAA_University
    {
        public int UniversityID { get; set; }

        [DisplayName("University")]
        [Required(ErrorMessage = "Cannot be empty")]
        public string UniversityName { get; set; }
    }
}

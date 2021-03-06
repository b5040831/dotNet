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

    public partial class NAA_Application
    {
        [Required]
        public int ApplicationID { get; set; }

        [Required]
        public int ApplicantID { get; set; }

        [Required]
        [DisplayName("Course")]
        public string CourseName { get; set; }

        [Required]
        public int UniversityID { get; set; }

        [DisplayName("Personal Statement")]
        [MaxLength(500, ErrorMessage = "This is too long")]
        [Required(ErrorMessage = "Cannot be empty")]
        public string PersonalStatement { get; set; }

        [DisplayName("Teacher Reference")]
        [MaxLength(100, ErrorMessage = "This is too long")]
        [Required(ErrorMessage = "Cannot be empty")]
        public string TeacherReference { get; set; }

        [DisplayName("Teacher's Contact Details")]
        [MaxLength(100, ErrorMessage = "This is too long")]
        [Required(ErrorMessage = "Cannot be empty")]
        public string TeacherContactDetails { get; set; }

        [DisplayName("University Offer")]
        public string UniversityOffer { get; set; }
        public Nullable<bool> Firm { get; set; }
    }
}

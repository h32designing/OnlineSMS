using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace onlinesms.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class personaldetail
    {
        public int persdetail_id { get; set; }
        public string per_name { get; set; }
        public string per_gender { get; set; }
        [DataType(DataType.Date)]
        public System.DateTime per_dob { get; set; }
        public string per_address { get; set; }
        public string per_martialstatus { get; set; }
        [DataType(DataType.EmailAddress)]
        public string per_email { get; set; }
        public string per_hobbies { get; set; }
        public int per_likes { get; set; }
        public int per_dislikes { get; set; }
        public string per_sport { get; set; }
        [DataType(DataType.ImageUrl)]
        public string per_image { get; set; }
        public int user_id { get; set; }
    
        public virtual user user { get; set; }
    }
}

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
    
    public partial class Message
    {
        public int message_id { get; set; }
        public string message_subject { get; set; }
        public string message_description { get; set; }
        public int sender_id { get; set; }
        public string sender_name { get; set; }
    
        public virtual user user { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiaryApplication.Models
{
    public class NotesDTO
    {
        public int note_id { get; set; }
        public int user_id { get; set; }
        public int school_id { get; set; }
        public string notehealine { get; set; }
        public System.DateTime date_created { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.ViewModels
{
    public class MailSidebarViewModel
    {
        public int ContactCount { get; set; }
        public int InboxCount { get; set; }
        public int SendboxCount { get; set; }
        public int DraftMailCount { get; set; }
        public int SpamCount { get; set; } = 65; // Varsayılan bir değer

    }
}
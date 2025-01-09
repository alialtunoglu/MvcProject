using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcProjeKampi.ViewModels
{
    public class MessageNavigationViewModel
    {
        public int? PreviousMessageId { get; set; }
        public int? NextMessageId { get; set; }
    }
}
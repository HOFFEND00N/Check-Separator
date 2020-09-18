using System;

namespace CheckSeparatorMVC.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //public ErrorViewModel(string error)
        //{
        //    RequestId = error;
        //}
    }
}

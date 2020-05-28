using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Driver.Models
{
    public class DropOffPoint
    {
        public int Id { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverCountry { get; set; }
        public string ReceiverZipCode { get; set; }

        //KuryeId: Teslimati Gerceklestirenin Id
        public string UserId { get; set; }
    }
}
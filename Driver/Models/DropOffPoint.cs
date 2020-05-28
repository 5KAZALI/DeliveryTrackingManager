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
        public string Street { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        //KuryeId: Teslimati Gerceklestirenin Id
        public string UserId { get; set; }
    }
}
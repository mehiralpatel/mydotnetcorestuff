using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Request
{
    public class FilterRequestModel
    {
        public string Key { get; set; }

        public object Value { get; set; }

        public object From { get; set; }

        public object To { get; set; }
    }
}

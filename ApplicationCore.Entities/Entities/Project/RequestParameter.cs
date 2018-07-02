using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities.Entities.Project
{
    public class RequestParameter
    {
        public string Search_Text { get; set; }

        public string Secondary_Search_Text { get; set; }

        public string Page_Start { get; set; }

        public string Page_Size { get; set; }

        public string Sort_Column { get; set; }

        public string Sort_Order { get; set; }

        public string Filters { get; set; }

        public string Secondary_Filters { get; set; }


        //public List<FilterRequestModel> FiltersList
        //{
        //    get
        //    {
        //        return !string.IsNullOrEmpty(Filters) ?
        //         JsonConvert.DeserializeObject<List<FilterRequestModel>>(Filters) :
        //        new List<FilterRequestModel>();
        //    }
        //}

        //public List<FilterRequestModel> SecondaryFiltersList
        //{
        //    get
        //    {
        //        return !string.IsNullOrEmpty(Secondary_Filters) ?
        //         JsonConvert.DeserializeObject<List<FilterRequestModel>>(Secondary_Filters) :
        //        new List<FilterRequestModel>();
        //    }
        //}
    }
}

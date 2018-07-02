using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extension
{
    public class Constants
    {
        public class Keys
        {
            public const string UriParameter = "{parameter}";

            public class SearchParameters
            {
                public const string PageSize = "PageSize";
                public const string PageStart = "PageStart";
                public const string SearchText = "SearchText";
                public const string SecondarySearchText = "SecondarySearchText";
                public const string SearchableFields = "SearchableFields";
                public const string FilterableFields = "FilterableFields";
                public const string SortableFields = "SortableFields";
                public const string SortColumn = "SortColumn";
                public const string SortOrder = "SortOrder";
                public const string Filters = "Filters";
                public const string RequiredFields = "RequiredFields";
                public const string ModifiedAfter = "ModifiedAfter";
                public const string ShowAll = "ShowAll";
                public const string ShowMy = "ShowMy";
                public const string ShowShared = "ShowShared";
                public const string ShowOnlyActive = "ShowOnlyActive";
                public const string ScrollId = "ScrollId";
                public const string IsFromDevice = "IsFromDevice";
                public const string UserId = "user_id";
            }

            public class Cache
            {
                public const string UserDetails = "ud_{0}";
                public const string AuthToken = "at_{0}";
                public const string SessionObject = "so_{0}";
            }
         
        }

        public const int SizeToFetchAllRecords = -1;
    }
}

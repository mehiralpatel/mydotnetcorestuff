using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BaseApiController : Controller
    {

        //protected Dictionary<string, object> FillParamesFromModel(RequestParameter model)
        //{
        //    Dictionary<string, object> parameters = new Dictionary<string, object>();

        //    long pageStart = 1, pageSize = 10;

        //    if (model != null)
        //    {
        //        if (!string.IsNullOrWhiteSpace(model.Page_Start))
        //        {
        //            if (!long.TryParse(model.Page_Start.ToString(), out pageStart) || pageStart < 0)
        //            {
        //                throw new Exception(ObjectExtentions.GetValidationMessage("INVALIDPAGESTART"));
        //            }
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.Page_Size))
        //        {
        //            if (!long.TryParse(model.Page_Size.ToString(), out pageSize) || (pageSize < 0 && pageSize != Constants.SizeToFetchAllRecords))
        //            {
        //                throw new Exception(ObjectExtentions.GetValidationMessage("INVALIDPAGESIZE"));
        //            }
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.Sort_Column))
        //        {
        //            parameters.Add(Constants.Keys.SearchParameters.SortColumn, model.Sort_Column.Trim());
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.Sort_Order))
        //        {
        //            parameters.Add(Constants.Keys.SearchParameters.SortOrder, model.Sort_Order.Trim());
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.Search_Text))
        //        {
        //            parameters.Add(Constants.Keys.SearchParameters.SearchText, model.Search_Text.Trim());
        //        }

        //        if (!string.IsNullOrWhiteSpace(model.Secondary_Search_Text))
        //        {
        //            parameters.Add(Constants.Keys.SearchParameters.SecondarySearchText, model.Secondary_Search_Text.Trim());
        //        }

        //        //if (model.FiltersList != null && model.FiltersList.Count > 0)
        //        //{
        //        //    parameters.Add(Constants.Keys.SearchParameters.Filters, model.FiltersList);
        //        //}

        //    }

        //    parameters.Add(Constants.Keys.SearchParameters.PageStart, pageStart);
        //    parameters.Add(Constants.Keys.SearchParameters.PageSize, pageSize);

        //    return parameters;
        //}
    }
}
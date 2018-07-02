using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Specifications
{
    public class CustomTaskWithResourceData : BaseSpecification<CustomTask>
    {
        public CustomTaskWithResourceData(int statusId )
            : base(b => b.Status == statusId)
        {
            //AddInclude(b => b.LastModifiedByUserId);
            //AddInclude(b => b.CreatedByUserId);
            AddInclude(b => b.Resource);
        }

    }

}

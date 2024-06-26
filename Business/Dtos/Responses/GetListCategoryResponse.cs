﻿using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class GetListCategoryResponse: BasePageableModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}

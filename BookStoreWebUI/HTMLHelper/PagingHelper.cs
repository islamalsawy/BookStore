﻿using BookStoreWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BookStoreWebUI.HTMLHelper
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            PagingInfo pageInfo,
            Func<int,string> pageURL)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pageInfo.TotalPage; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageURL(i));
                tag.InnerHtml = i.ToString();  
                if (i==pageInfo.CurrentPage)
                {
                    tag.AddCssClass("Selected");
                    tag.AddCssClass("btn-Primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
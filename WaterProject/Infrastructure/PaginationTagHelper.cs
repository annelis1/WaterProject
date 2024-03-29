﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WaterProject.Models.ViewModels;

namespace WaterProject.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;//help build url
        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]//don't want users to be able to type in and get it
        public ViewContext? ViewContext { get; set; }
        public string? PageAction { get; set; }
            //C# helps by knowing that this and page-action/page-model in html are the same
        public PaginationInfo PageModel {  get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null) 
            { 
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder result = new TagBuilder("div");
                
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"]= urlHelper.Action(PageAction, new {pageNum = i});
                    tag.InnerHtml.Append(i.ToString());

                    result.InnerHtml.AppendHtml(tag);
                }

                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}

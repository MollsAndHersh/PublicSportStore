using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Infrastructure
{    
    [HtmlTargetElement("div", Attributes = "category-model")]
    public class CategoryLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        public CategoryLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            urlHelperFactory = helperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public CategoringInfo CategoryModel { get; set; }

        public string CategoryAction { get; set; }
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool CategoryClassesEnabled { get; set; } = false;
        public string CategoryClass { get; set; }
        public string CategoryClassNormal { get; set; }
        public string CategoryClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 0; i < CategoryModel.TotalCategories; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["category"] = CategoryModel.Categories[i].Name;
                tag.Attributes["href"] = urlHelper.Action(CategoryAction, PageUrlValues);
                tag.AddCssClass(CategoryClass);
                tag.AddCssClass(CategoryClassNormal);
                if (CategoryClassesEnabled)
                {
                    tag.AddCssClass(CategoryModel.Categories[i].Name == CategoryModel.CurrentCategory ? CategoryClassSelected : CategoryClassNormal);
                }
                tag.InnerHtml.Append(CategoryModel.Categories[i].Name);
                result.InnerHtml.AppendHtml(tag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }

    }
}

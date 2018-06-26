using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Welo.WebApplication.Helper
{
    public static class HtmlHelper
    {
        public static MvcHtmlString ActionLinkFor<TModel, TValue>(this HtmlHelper<IPagedList<TModel>> html, Expression<Func<TModel, TValue>> expression, string action)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());
            string displayName = metadata.DisplayName ?? metadata.PropertyName ?? ExpressionHelper.GetExpressionText(expression).Split('.').Last();

            var tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = displayName;
            tagBuilder.MergeAttribute("href", $"./{action}");

            return new MvcHtmlString(tagBuilder.ToString());
        }

        public static MvcHtmlString ActionLinkFor<TModel, TValue>(this HtmlHelper<IPagedList<TModel>> html, Expression<Func<TModel, TValue>> expression, string action, object routeValues)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());
            string displayName = metadata.DisplayName ?? metadata.PropertyName ?? ExpressionHelper.GetExpressionText(expression).Split('.').Last();

            var tagBuilder = new TagBuilder("a");
            tagBuilder.InnerHtml = displayName;
            tagBuilder.MergeAttribute("href", $"./{action}");

            //todo: Gerar o link com os routeValues

            return new MvcHtmlString(tagBuilder.ToString());
        }
    }
}
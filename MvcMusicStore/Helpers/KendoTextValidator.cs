using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Kendo.Mvc.UI.Fluent;

namespace MvcMusicStore.Helpers
{
    /// <summary>
    /// At this time, Kendo does not include any HtmlHelpers for validation.
    /// This class contains a custom HtmlHelper to make validatable text boxes.
    /// This is not a full implementation, and only contains the things needed for this demo.
    /// </summary>
    public static class KendoTextValidatorHelper
    {
        public static MvcHtmlString TextValidatorFor<TModel, TResult>(this WidgetFactory<TModel> widgetFactory, Expression<Func<TModel, TResult>> expr)
        {
            return TextValidatorFor(widgetFactory, expr, new Dictionary<string, object>(0));
        }

        public static MvcHtmlString TextValidatorFor<TModel, TResult>(this WidgetFactory<TModel> widgetFactory, Expression<Func<TModel, TResult>> expr, object htmlAttributes)
        {
            var htmlAttributesDictionary = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            return TextValidatorFor(widgetFactory, expr, htmlAttributesDictionary);
        }

        public static MvcHtmlString TextValidatorFor<TModel, TResult>(this WidgetFactory<TModel> widgetFactory, Expression<Func<TModel, TResult>> expr, IDictionary<string, object> htmlAttributes)
        {
            var modelMetadata = ModelMetadata.FromLambdaExpression(expr, widgetFactory.HtmlHelper.ViewData);
            var inputElement = createInputElement(widgetFactory, modelMetadata.Model, null, InputType.Text, expr, htmlAttributes);
            return new MvcHtmlString(inputElement.ToString());
        }

        private static TagBuilder createInputElement<TModel, TResult>(WidgetFactory<TModel> widgetFactory, object value, string format, InputType inputType, Expression<Func<TModel, TResult>> expr, IDictionary<string, object> htmlAttributes)
        {
            var htmlHelper = widgetFactory.HtmlHelper;
            var inputElement = new TagBuilder("input");
            inputElement.MergeAttributes(htmlAttributes);
            inputElement.MergeAttribute("type", HtmlHelper.GetInputTypeString(inputType));
            inputElement.MergeAttribute("name", htmlHelper.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText((LambdaExpression)expr)), true);
            inputElement.MergeAttribute("validationMessage", " ", false);
            inputElement.MergeAttribute("value", htmlHelper.FormatValue(value, format), false);
            inputElement.MergeAttributes(ValidationAttributesFor(widgetFactory, expr));
            return inputElement;
        }

        public static IDictionary<string, object> ValidationAttributesFor<TModel, TResult>(this WidgetFactory<TModel> widgetFactory, Expression<Func<TModel, TResult>> expr)
        {
            var result = new Dictionary<string, object>();
            var memberExpr = (MemberExpression)expr.Body;
            var attributes = memberExpr.Member.GetCustomAttributes(true);
            foreach (var attribute in attributes)
            {
                if (attribute is RequiredAttribute)
                {
                    result["required"] = "";
                }
                else if (attribute is StringLengthAttribute)
                {
                    if (result.ContainsKey("pattern"))
                        continue;
                    var a = (StringLengthAttribute)attribute;
                    result.Add("pattern", string.Format(".{{{0},{1}}}", a.MinimumLength, a.MaximumLength));
                }
                else if (attribute is RegularExpressionAttribute)
                {
                    var a = (RegularExpressionAttribute)attribute;
                    result["pattern"] = a.Pattern;
                }
            }
            return result;
        }
    }
}
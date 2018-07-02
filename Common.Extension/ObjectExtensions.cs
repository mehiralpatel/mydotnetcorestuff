using System;
using System.Collections.Generic;

namespace Common.Extension
{
    public static class ObjectExtentions
    {
        /// <summary>
        /// Gets the validation message.
        /// </summary>
        /// <param name="errorMessageKey">The error message key.</param>
        /// <returns></returns>
        public static string GetValidationMessage(string errorMessageKey)
        {
            string errorMsg = string.Empty;
            var hasValue = false;
            hasValue = ValidationMessages.ValidationMsgs.TryGetValue(errorMessageKey, out errorMsg);
            return hasValue ? errorMsg : errorMessageKey;
        }

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="resultsOutput">The results output.</param>
        /// <returns></returns>
        public static string IsValid(this object obj, out Dictionary<string, string> resultsOutput)
        {
            //TODO : manage validation 
            string errMsgsResponse = null;
            resultsOutput = null;
            string errMsgList = null;
            //var instance = obj.GetType().Assembly.CreateInstance((obj.GetType().FullName + "Validator"));
            
            //var validator = (IValidator)instance;
            //if (validator != null)
            //{
            //    var results = validator.Validate(obj);
            //    if (!results.IsValid)
            //    {
            //        resultsOutput = new Dictionary<string, string>();
            //        foreach (var item in results.Errors)
            //        {
            //            var i = 0;
            //            var popName = item.PropertyName;
            //            while (resultsOutput.Keys.Contains(popName))
            //            {
            //                popName = popName + i;
            //                i++;
            //            }
            //            resultsOutput.Add(popName, item.ErrorMessage);
            //            errMsgList += GetValidationMessage(item.ErrorMessage) + ";";
            //        }
            //    }
            //}
            //if (errMsgList != null)
            //{
            //    errMsgList = errMsgList.TrimEnd(';');
            //    errMsgsResponse = errMsgList;
            //}
            return errMsgsResponse;
        }

        public static string GetCustomMessage(string customMessageKey)
        {
            string errorMsg;
            // var hasValue = CustomMessages.CustomMsgs.TryGetValue(customMessageKey, out errorMsg);
            //return hasValue ? errorMsg : customMessageKey;
            return "TODO implement";
        }
    }
}

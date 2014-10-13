namespace Sitecore.WFFM.Customization.Forms.Pipelines
{
    using System;
    using System.Text;

    using Sitecore.Form.Core.Configuration;
    using Sitecore.Form.Core.Controls.Data;
    using Sitecore.Form.Core.Pipelines.ProcessMessage;
    using Sitecore.Forms.Core.Data;

    /// <summary>
    /// Class for message processings
    /// </summary>
    public class ProcessMessage
    {
        /// <summary>
        /// This method would replace all fields token by form fields tokens for further processing
        /// </summary>
        /// <param name="args"></param>
        public void ExpandAllFieldsToken(ProcessMessageArgs args)
        {
            if (args.MessageType != MessageType.Email)
            {
                //if this is not email - we could not process tokens
                return;
            }
            if (!args.Mail.ToString().Contains(Shared.Constants.AllFieldsToken))
            {
                //if there is no all fields token - nothing should be done here
                return;
            }

            var replacerString = new StringBuilder();

            foreach (AdaptedControlResult result in args.Fields)
            {
                if (result.Parameters != null && result.Parameters.StartsWith("secure", StringComparison.OrdinalIgnoreCase))
                {
                    //we should not add secure types (Captcha, Passwords, Credit cards) to email
                    continue;
                }

                var field = new FieldItem(StaticSettings.ContextDatabase.GetItem(result.FieldID));

                //here we are forming string to replace allFields token
                if (!string.IsNullOrEmpty(field.Title))
                {
                    replacerString.Append(FieldreplacerCreator(Shared.Constants.FieldNameFormat, field.ID.ToString(), field.Title, args.IsBodyHtml));
                }
                else if (!string.IsNullOrEmpty(field.Name))
                {
                    replacerString.Append(FieldreplacerCreator(Shared.Constants.FieldNameFormat, field.ID.ToString(), field.Name, args.IsBodyHtml));
                }
            }
            //and, actual replacement is done here
            args.Mail.Replace(Shared.Constants.AllFieldsEmailToken, replacerString.ToString());

            if (args.IsBodyHtml)
            {
                //if body is html, New line token should be replaced by line break
                args.Mail.Replace(Environment.NewLine, "<br />");
            }
        }

        private string FieldreplacerCreator(string format, string id, string name, bool isHtml)
        {
            var returnValue = new StringBuilder();
            if (isHtml)
            {
                returnValue.Append("<strong>" + name + "</strong>: ");
            }
            else
            {
                returnValue.Append(name + ": ");
            }
            
            returnValue.AppendFormat(format, id, name);
            returnValue.Append(Environment.NewLine);
            return returnValue.ToString();
        }
    }
}

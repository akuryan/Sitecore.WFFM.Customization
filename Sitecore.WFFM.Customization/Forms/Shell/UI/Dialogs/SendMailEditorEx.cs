namespace Sitecore.WFFM.Customization.Forms.Shell.UI.Dialogs
{
    using Sitecore.Forms.Shell.UI.Dialogs;
    using Sitecore.Web.UI.HtmlControls;

    /// <summary>
    /// Overrides default SendMailEditor to insert all fields token
    /// </summary>
    public class SendMailEditorEx : SendMailEditor
    {
        /// <summary>
        /// Initialized Email editor in order to add all fields token
        /// </summary>
        protected override void InitializeEditor()
        {
            base.InitializeEditor();
            if (!this.HtmlEditorPane.HasControls())
            {
                //just to be sure that it has controls when it should have them
                return;
            }

            foreach (var control in this.HtmlEditorPane.Controls)
            {
                if (control.GetType() != new Literal().GetType())
                {
                    continue;
                }
                var text = ((Literal)control).Text;
                if (!text.StartsWith("<input ID=\"__Field\" Type=\"hidden\" value=\""))
                {
                    continue;
                }
                text = text.Replace("\" />", string.Format("&{0}={0}\" />", Shared.Constants.AllFieldsToken));
                ((Literal)control).Text = text;
            }
        }
    }
}

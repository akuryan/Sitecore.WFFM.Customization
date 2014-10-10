namespace Sitecore.WFFM.Customization.Forms.Shell.UI.Dialogs
{
    using Sitecore.Forms.Shell.UI.Dialogs;
    using Sitecore.Web.UI.HtmlControls;

    public class SendMailEditorEx : SendMailEditor
    {
        protected override void InitializeEditor()
        {
            base.InitializeEditor();
            if (!this.HtmlEditorPane.HasControls())
            {
                //just to be sure that it has controls when it should have them
                return;
            }

            foreach (Control control in this.HtmlEditorPane.Controls)
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
                text = text.Replace("\" />", string.Format("&{0} = {0}\" />", Shared.Constants.AllFieldsToken));
                ((Literal)control).Text = text;
            }
        }
    }
}

namespace Sitecore.WFFM.Customization.Buttons.InsertButton.Command
{
    using Sitecore.Forms.Core.Commands;
    using Sitecore.Shell.Framework.Commands;

    public class InsertFormButton : InsertForm
    {
        public override CommandState QueryState(CommandContext context)
        {
            if (context.Items.Length > 0 && !context.Items[0].Security.CanWrite(Context.User))
            {
                return CommandState.Disabled;
            }

            //here we received a form id
            var formId = Shared.FormId.GetFormId(context.Items[0]);
            return !string.IsNullOrEmpty(formId) ? CommandState.Hidden : base.QueryState(context);
        }
    }
}

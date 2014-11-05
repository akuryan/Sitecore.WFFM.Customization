namespace Sitecore.WFFM.Customization.Buttons.InsertButton.Command
{
    using Sitecore.Diagnostics;
    using Sitecore.Forms.Core.Commands;
    using Sitecore.Shell.Framework.Commands;
    using Sitecore.WFFM.Customization.Shared;

    /// <summary>
    /// Overrides default InsertForm button behavior
    /// </summary>
    public class InsertFormButton : InsertForm
    {
        private static FormId FormId
        {
            get
            {
                return new FormId();
            }
        }

        /// <summary>
        /// Disables InsertForm button if context user could not write to current item. Hides InsertForm button if current item have form in it
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override CommandState QueryState(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            Error.AssertObject(context, "context");
            if (context.Items.Length > 0 && !context.Items[0].Security.CanWrite(Context.User))
            {
                return CommandState.Disabled;
            }

            //here we received a form id
            var formId = FormId.GetFormId(context.Items[0]);
            return !string.IsNullOrEmpty(formId) ? CommandState.Hidden : base.QueryState(context);
        }
    }
}

namespace Sitecore.WFFM.Customization.Buttons.EditButton.Command
{
    using Sitecore.Data;
    using Sitecore.Diagnostics;
    using Sitecore.Forms.Core.Commands;
    using Sitecore.Shell.Framework.Commands;
    using Sitecore.WFFM.Customization.Shared;

    /// <summary>
    /// Describes EditForm button behavior
    /// </summary>
    public class EditFormButton : OpenFormDesigner
    {
        private static FormId FormId
        {
            get
            {
                return new FormId();
            }
        }

        /// <summary>
        /// Controls, what to do in case user pressed EditForm button
        /// </summary>
        /// <param name="context"></param>
        public override void Execute(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            Error.AssertObject(context, "context");

            if (context.Items.Length <= 0)
            {
                return;
            }
            if (Context.Database == null)
            {
                return;
            }
            //here we received a form id
            var formId = FormId.GetFormId(context.Items[0]);
            //then, we are casting id to an item. We would care about rights in CommandState
            var form = context.Items[0].Database.GetItem(new ID(formId));
            if (form != null)
            {
                this.RunDesigner(form);
            }
        }

        /// <summary>
        /// Disables EditForm button if context user could not write to current item. Hides EditForm button is current item have no form in it or current user could not read or write to form
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override CommandState QueryState(CommandContext context)
        {
            Assert.ArgumentNotNull(context, "context");
            if (context.Items.Length > 0 && !context.Items[0].Security.CanWrite(Context.User))
            {
                //we could not write to current context item, so, edit button should be deactivated
                return CommandState.Disabled;
            }

            //here we received a form id
            var formId = FormId.GetFormId(context.Items[0]);
            if (string.IsNullOrEmpty(formId))
            {
                //we do not have form in current item, so we do not need edit button
                return CommandState.Hidden;
            }

            //then, we are casting id to an item. We would care about rights in CommandState
            var form = context.Items[0].Database.GetItem(new ID(formId));
            if (form == null)
            {
                //something is wrong, and we could not get a form
                return CommandState.Hidden;
            }

            if (!form.Security.CanRead(Context.User) || !form.Security.CanWrite(Context.User))
            {
                //current user could not read or write the form
                return CommandState.Hidden;
            }
            return base.QueryState(context);
        }
    }
}

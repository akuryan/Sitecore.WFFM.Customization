namespace Sitecore.WFFM.Customization.Shared
{
    using System.Linq;

    using Sitecore.Data.Fields;
    using Sitecore.Data.Items;
    using Sitecore.Layouts;
    using Sitecore.Web;

    public class FormId
    {
        private static string DeviceGuid
        {
            get
            {
                return Configuration.Settings.GetSetting("WFFM.Customization.SitecoreDeviceGUID", "{FE5D7FDF-89C0-4D99-9AA3-B5FBD009C9F3}");
            }
        }

        private static string FormRenderingGuid
        {
            get
            {
                return Configuration.Settings.GetSetting("WFFM.Customization.FormRendererGUID", "{6D3B4E7D-FEF8-4110-804A-B56605688830}");
            }
        }

        public static string GetFormId(Item item)
        {
            var formId = string.Empty;
            if (item.Fields["__renderings"] == null || item.Fields["__renderings"].Value == string.Empty)
            {
                return formId;
            }
            var layout = LayoutField.GetFieldValue(item.Fields[FieldIDs.LayoutField]);

            var definition = LayoutDefinition.Parse(layout);
            // Get default device
            var device = definition.GetDevice(DeviceGuid);
            // Get the form interpreter
            var formInterpreter = device.GetRendering(FormRenderingGuid);
            if (formInterpreter == null)
            {
                return formId;
            }
            var qs = WebUtil.ParseUrlParameters(formInterpreter.Parameters.ToLower());
            foreach (var key in qs.Keys.Cast<string>().Where(key => key == "formid"))
            {
                formId = qs[key];
            }
            return formId;
        }
    }
}

namespace Sitecore.WFFM.Customization.Shared
{
    public class Constants
    {
        public const string AllFieldsToken = "{All-Fields}";
        public const string FieldNameFormat = "[<label id=\"{0}\">{1}</label>]";
        public static readonly string AllFieldsEmailToken = string.Format(FieldNameFormat, AllFieldsToken, AllFieldsToken);
    }
}

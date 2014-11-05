namespace Sitecore.WFFM.Customization.Shared
{
    /// <summary>
    /// Constant values used
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Constant value for AllFields Token
        /// </summary>
        public const string AllFieldsToken = "{All-Fields}";
        /// <summary>
        /// Constant value for Field Name format
        /// </summary>
        public const string FieldNameFormat = "[<label id=\"{0}\">{1}</label>]";
        /// <summary>
        /// Token to be used for AllFields Email Token insertion
        /// </summary>
        public static readonly string AllFieldsEmailToken = string.Format(FieldNameFormat, AllFieldsToken, AllFieldsToken);
    }
}

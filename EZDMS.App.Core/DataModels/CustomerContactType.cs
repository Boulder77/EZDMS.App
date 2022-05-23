namespace EZDMS.App.Core
{
    /// <summary>
    /// The types of ways to contact a customer
    /// </summary>
    public enum CustomerContactType
    {
        /// <summary>
        /// No contact
        /// </summary>
        None = 0,

        /// <summary>
        /// Text message
        /// </summary>
        Text = 1,

        /// <summary>
        /// email
        /// </summary>
        Email = 2,

        /// <summary>
        /// phone call
        /// </summary>
        PhoneCall = 3,

        /// <summary>
        /// mailing address
        /// </summary>
        Address = 4,

    }
}

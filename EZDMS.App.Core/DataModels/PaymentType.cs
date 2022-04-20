namespace EZDMS.App.Core
{
    /// <summary>
    /// The types of payments to use within the application
    /// </summary>
    public enum PaymentType
    {
        /// <summary>
        /// Monthly payment schedule
        /// </summary>
        Monthly = 0,

        /// <summary>
        /// Weekly payment schedule
        /// </summary>
        Weekly = 1,

        /// <summary>
        /// Bi-Weekly payment schedule
        /// </summary>
        BiWeekly = 2,

        /// <summary>
        /// Annual payment schedule
        /// </summary>
        Annual = 3,
    }
}

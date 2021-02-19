namespace SeamlessChex.Models
{
    using RestSharp;

    /// <summary>
    /// Sort by specified field.
    /// </summary>
    public enum SortField
    {
        /// <summary>
        /// Check date.
        /// </summary>
        Date,

        /// <summary>
        /// Check number.
        /// </summary>
        Number,

        /// <summary>
        /// Check sender's name.
        /// </summary>
        Name,
    }

    /// <summary>
    /// Sort direction.
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// Descending.
        /// </summary>
        Desc,

        /// <summary>
        /// Ascending.
        /// </summary>
        Asc,
    }

    /// <summary>
    /// Query parameters for GetChecks call.
    /// </summary>
    public class GetChecksParameters
    {
        /// <summary>
        /// Gets or sets a limit on the number of objects to be returned.
        /// Limit can range between 1 and 100 items, and the default is 15 items.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets a cursor to use for pagination.
        /// The result is divided into pages, the size of which is determined by the limit parameter.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the parameter is intended for sorting the results by a specific field.
        /// For example, you can sort by 'date', 'number' or 'name'.
        /// </summary>
        public SortField? Sort { get; set; }

        /// <summary>
        /// Gets or sets the parameter allows you to change the sorting direction 'ASC' or 'DESC'.
        /// </summary>
        public SortDirection? Direction { get; set; }

        /// <summary>
        /// Gets or sets the parameter to filter results by the eCheck label field.
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the parameter to filter results by the eCheck link field.
        /// </summary>
        public string LinkId { get; set; }

        /// <summary>
        /// Apply parameters to HTTP request.
        /// </summary>
        /// <param name="request">HTTP request.</param>
        /// <returns>HTTP request with the parameters applied.</returns>
        public RestRequest Apply(RestRequest request)
        {
            if (this.Limit.HasValue)
            {
                _ = request.AddParameter("limit", this.Limit);
            }

            if (this.Page.HasValue)
            {
                _ = request.AddParameter("page", this.Page);
            }

            if (this.Sort.HasValue)
            {
                _ = request.AddParameter("sort", this.Sort.ToString().ToLowerInvariant());
            }

            if (this.Direction.HasValue)
            {
                _ = request.AddParameter("direction", this.Direction.ToString().ToUpperInvariant());
            }

            if (!string.IsNullOrEmpty(this.Label))
            {
                _ = request.AddParameter("label", this.Label);
            }

            if (!string.IsNullOrEmpty(this.LinkId))
            {
                _ = request.AddParameter("link_id", this.LinkId);
            }

            return request;
        }
    }
}

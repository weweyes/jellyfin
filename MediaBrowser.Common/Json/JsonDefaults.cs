using System.Text.Json;
using System.Text.Json.Serialization;
using MediaBrowser.Common.Json.Converters;

namespace MediaBrowser.Common.Json
{
    /// <summary>
    /// Helper class for having compatible JSON throughout the codebase.
    /// </summary>
    public static class JsonDefaults
    {
        /// <summary>
        /// Gets the default <see cref="JsonSerializerOptions" /> options.
        /// </summary>
        /// <remarks>
        /// When changing these options, update
        ///     Jellyfin.Server/Extensions/ApiServiceCollectionExtensions.cs
        ///         -> AddJellyfinApi
        ///             -> AddJsonOptions.
        /// </remarks>
        /// <returns>The default <see cref="JsonSerializerOptions" /> options.</returns>
        public static JsonSerializerOptions GetOptions()
        {
            var options = new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Disallow,
                WriteIndented = false
            };

            options.Converters.Add(new JsonGuidConverter());
            options.Converters.Add(new JsonInt32Converter());
            options.Converters.Add(new JsonNullableInt32Converter());
            options.Converters.Add(new JsonStringEnumConverter());
            options.Converters.Add(new JsonNonStringKeyDictionaryConverterFactory());
            options.Converters.Add(new JsonInt64Converter());
            options.Converters.Add(new JsonNullableInt64Converter());
            options.Converters.Add(new JsonDoubleConverter());

            return options;
        }

        /// <summary>
        /// Gets camelCase json options.
        /// </summary>
        /// <returns>The camelCase <see cref="JsonSerializerOptions" /> options.</returns>
        public static JsonSerializerOptions GetCamelCaseOptions()
        {
            var options = GetOptions();
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            return options;
        }

        /// <summary>
        /// Gets PascalCase json options.
        /// </summary>
        /// <returns>The PascalCase <see cref="JsonSerializerOptions" /> options.</returns>
        public static JsonSerializerOptions GetPascalCaseOptions()
        {
            var options = GetOptions();
            options.PropertyNamingPolicy = null;
            return options;
        }
    }
}

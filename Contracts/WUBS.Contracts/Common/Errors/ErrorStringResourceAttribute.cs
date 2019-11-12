using System;
using System.Diagnostics.CodeAnalysis;

namespace WUBS.Contracts.Common.Errors
{
    /// <summary>
    /// Decoration used to override default resource file used for string lookup.
    /// </summary>
    /// <remarks>
    /// The default resource file to use for any enumeration is ErrorStrings.resx contained in the same namespace as the enumeration definition.
    /// [The namespace of a .resx file will be the project default namespace specified on its property pages plus the folder
    /// hierarchy containing the .resx file with folders spearated by periods and spaces replaced with underscores.] Applying this
    /// attribute to an enumeration will specify the resource file to use for string lookups. Applying this attribute to the assembly
    /// will change the default resource file for all enumerations that don't have this attribute applied to them.
    /// </remarks>
    [SuppressMessage("Microsoft.Design", "CA1019:DefineAccessorsForAttributeArguments", Justification = "We want none of these settings to be externally visible.")]
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Assembly, AllowMultiple = false)]
    public sealed class ErrorStringResourceAttribute : Attribute
    {
        internal Type Redirect { get; private set; }

        /// <summary>
        /// User resource file assigned to another type.
        /// </summary>
        /// <param name="redirect">The type to query for string resource file information.</param>
        public ErrorStringResourceAttribute(Type redirect)
        {
            Redirect = redirect;
        }

        internal string Path { get; private set; }

        /// <summary>
        /// User resource file contained in the specified path.
        /// </summary>
        /// <param name="path">The full path to the resource (do not include .resx extension in path name).</param>
        public ErrorStringResourceAttribute(String path)
        {
            Path = path;
        }

        /// <summary>
        /// Use resource file name in the namespace of the referenced type.
        /// </summary>
        /// <param name="name">The name of the resource file (do not include .resx extension in name).</param>
        /// <param name="namespaceReference">The type to use as a namespace reference.</param>
        public ErrorStringResourceAttribute(String name, Type namespaceReference)
        {
            Path = string.Concat(namespaceReference.Namespace, ".", name);
        }

        internal bool IsRedirect { get { return Redirect != null; } }
    }
}

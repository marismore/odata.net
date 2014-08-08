//   OData .NET Libraries ver. 5.6.2
//   Copyright (c) Microsoft Corporation. All rights reserved.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.

namespace Microsoft.Data.OData
{
    /// <summary>
    /// Class to provide additional serialization information to the <see cref="ODataMessageWriter"/> for an <see cref="ODataEntityReferenceLinks"/>.
    /// </summary>
    public sealed class ODataEntityReferenceLinksSerializationInfo
    {
        /// <summary>
        /// The source entity set name of the navigation property. Should be fully qualified if the entity set is not in the default container.
        /// </summary>
        private string sourceEntitySetName;

        /// <summary>
        /// The fully qualified type name of the declaring entity type of the navigation property if the declaring entity type is not the base type of the source entity set.
        /// Should be null if the declaring entity type is the base type of the source entity set.
        /// </summary>
        private string typecast;

        /// <summary>
        /// The name of the navigation property to write the entity reference links for.
        /// </summary>
        private string navigationPropertyName;

        /// <summary>
        /// The source entity set name of the navigation property. Should be fully qualified if the entity set is not in the default container.
        /// </summary>
        public string SourceEntitySetName
        {
            get
            {
                return this.sourceEntitySetName;
            }

            set
            {
                ExceptionUtils.CheckArgumentStringNotNullOrEmpty(value, "SourceEntitySetName");
                this.sourceEntitySetName = value;
            }
        }

        /// <summary>
        /// The fully qualified type name of the declaring entity type of the navigation property if the declaring entity type is not the base type of the source entity set.
        /// Should be null if the declaring entity type is the base type of the source entity set.
        /// </summary>
        public string Typecast
        {
            get
            {
                return this.typecast;
            }

            set
            {
                ExceptionUtils.CheckArgumentStringNotEmpty(value, "Typecast");
                this.typecast = value;
            }
        }

        /// <summary>
        /// The name of the navigation property to write the entity reference links for.
        /// </summary>
        public string NavigationPropertyName
        {
            get
            {
                return this.navigationPropertyName;
            }

            set
            {
                ExceptionUtils.CheckArgumentStringNotNullOrEmpty(value, "NavigationPropertyName");
                this.navigationPropertyName = value;
            }
        }

        /// <summary>
        /// Validates the <paramref name="serializationInfo"/> instance.
        /// </summary>
        /// <param name="serializationInfo">The serialization info instance to validate.</param>
        /// <returns>The <paramref name="serializationInfo"/> instance.</returns>
        internal static ODataEntityReferenceLinksSerializationInfo Validate(ODataEntityReferenceLinksSerializationInfo serializationInfo)
        {
            DebugUtils.CheckNoExternalCallers();
            if (serializationInfo != null)
            {
                ExceptionUtils.CheckArgumentNotNull(serializationInfo.SourceEntitySetName, "serializationInfo.SourceEntitySetName");
                ExceptionUtils.CheckArgumentNotNull(serializationInfo.NavigationPropertyName, "serializationInfo.NavigationPropertyName");
            }

            return serializationInfo;
        }
    }
}
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

namespace System.Data.Services.Client
{
    #region Namespaces

    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq.Expressions;
    using System.Text;

    #endregion Namespaces

    /// <summary>Use this class to represent an annotated list of path segments.</summary>
    [DebuggerDisplay("{ToString()}")]
    internal class ProjectionPath : List<ProjectionPathSegment>
    {
        #region Constructors

        /// <summary>Initializes a new <see cref="ProjectionPath"/> instance.</summary>
        internal ProjectionPath() : base()
        {
        }

        /// <summary>Initializes a new <see cref="ProjectionPath"/> instance.</summary>
        /// <param name="root">Root parameter for this path.</param>
        /// <param name="expectedRootType">Expression to get the expected root type in the target tree.</param>
        /// <param name="rootEntry">Expression for the root entry.</param>
        internal ProjectionPath(ParameterExpression root, Expression expectedRootType, Expression rootEntry)
            : base()
        {
            this.Root = root;
            this.RootEntry = rootEntry;
            this.ExpectedRootType = expectedRootType;
        }

        /// <summary>Initializes a new <see cref="ProjectionPath"/> instance.</summary>
        /// <param name="root">Root parameter for this path.</param>
        /// <param name="expectedRootType">Expression to get the expected root type in the target tree.</param>
        /// <param name="rootEntry">Expression for the root entry.</param>
        /// <param name="members">Member to initialize the path with.</param>
        internal ProjectionPath(ParameterExpression root, Expression expectedRootType, Expression rootEntry, IEnumerable<Expression> members)
            : this(root, expectedRootType, rootEntry)
        {
            Debug.Assert(members != null, "members != null");

            foreach (Expression member in members)
            {
                this.Add(new ProjectionPathSegment(this, (MemberExpression)member));
            }
        }

        #endregion Constructors

        #region Internal properties

        /// <summary>Parameter expression in the source tree.</summary>
        internal ParameterExpression Root 
        { 
            get; 
            private set; 
        }

        /// <summary>Expression to get the entry for <see cref="Root"/> in the target tree.</summary>
        internal Expression RootEntry 
        { 
            get; 
            private set; 
        }

        /// <summary>Expression to get the expected root type in the target tree.</summary>
        internal Expression ExpectedRootType 
        { 
            get; 
            private set; 
        }

        #endregion Internal properties

        #region Methods

        /// <summary>Provides a string representation of this object.</summary>
        /// <returns>A string representation of this object, suitable for debugging.</returns>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(this.Root.ToString());
            builder.Append("->");
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].SourceTypeAs != null)
                {
                    builder.Insert(0, "(");
                    builder.Append(" as " + this[i].SourceTypeAs.Name + ")");
                }

                if (i > 0)
                {
                    builder.Append('.');
                }

                builder.Append(this[i].Member == null ? "*" : this[i].Member);
            }

            return builder.ToString();
        }

        #endregion Methods
    }
}
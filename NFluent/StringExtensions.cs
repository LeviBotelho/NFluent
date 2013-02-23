﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="">
//   Copyright 2013 Thomas PIERRAIN
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//       http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace NFluent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extension methods for exploiting strings in a fluent manner (i.e. with auto completion support and in an english readable way).
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Verifies that the specified string contains the given expected values, in any order.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="values">The expected values.</param>
        /// <returns>
        ///   <c>true</c> if the string contains the specified actual value in any order;  throw a <see cref="FluentException"/> otherwise.
        /// </returns>
        /// <exception cref="FluentAssertionException">The string does not contains all the given strings.</exception>
        public static bool Contains(this string actualValue, params string[] values)
        {
            var notFound = new List<string>();
            foreach (string value in values)
            {
                if (!actualValue.Contains(value))
                {
                    notFound.Add(value);
                }
            }

            if (notFound.Count > 0)
            {
                throw new FluentAssertionException(string.Format(@"The string [""{0}""] does not contain the expected value(s): [{1}].", actualValue, notFound.ToEnumeratedString()));
            }

            return true;
        }

        // TODO: find a better name to prevent from confusion with System.String.StartsWith(...)

        /// <summary>
        /// Verifies that the string starts with the given prefix, and throws a <see cref="FluentAssertException"/> if not.
        /// </summary>
        /// <param name="actualValue">The actual value.</param>
        /// <param name="expectedPrefix">The expected prefix.</param>
        /// <returns>
        ///     <c>true</c> if the string starts with the given prefix; throws a <see cref="FluentAssertException"/> otherwise.
        /// </returns>
        /// <exception cref="FluentAssertionException">The string does not start with the expected prefix.</exception>
        public static bool StartWith(this string actualValue, string expectedPrefix)
        {
            if (actualValue.StartsWith(expectedPrefix))
            {
                return true;
            }

            throw new FluentAssertionException(string.Format(@"The string [""{0}""] does not start with [""{1}""].", actualValue, expectedPrefix));
        }
    }
}
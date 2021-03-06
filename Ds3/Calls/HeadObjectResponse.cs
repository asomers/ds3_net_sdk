﻿/*
 * ******************************************************************************
 *   Copyright 2014 Spectra Logic Corporation. All Rights Reserved.
 *   Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *   this file except in compliance with the License. A copy of the License is located at
 *
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 *   or in the "license" file accompanying this file.
 *   This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *   CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *   specific language governing permissions and limitations under the License.
 * ****************************************************************************
 */

using System.Collections.Generic;

namespace Ds3.Calls
{
    public class HeadObjectResponse
    {
        public long Length { get; private set; }
        public string ETag { get; private set; }
        public IDictionary<string, string> Metadata { get; private set; }

        public HeadObjectResponse(long length, string eTag, IDictionary<string, string> metadata)
        {
            this.Length = length;
            this.ETag = eTag;
            this.Metadata = metadata;
        }
    }
}

﻿////////////////////////////////////////////////////////////////////////////////
//
//   Copyright 2023 Eppie(https://eppie.io)
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
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using Tuvi.Proton.Primitive.Messages.Payloads;

namespace Tuvi.Proton.Primitive.Exceptions
{
    public class RequestErrorInfo
    {
        public int Code { get; internal set; }
        public string Error { get; internal set; }
        public JsonObject Details { get; internal set; }

        public RequestErrorInfo(CommonResponse response)
        {
            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            Code = response.Code;
            Error = response.Error;
            Details = response.Details;
        }

        public T ReadDetails<T>(JsonSerializerOptions options = null)
        {
            return JsonSerializer.Deserialize<T>(Details, options);
        }
    }
}
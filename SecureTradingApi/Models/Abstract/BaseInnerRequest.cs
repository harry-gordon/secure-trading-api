﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SecureTradingApi.Enums;

namespace SecureTradingApi.Models.Abstract
{
    public abstract class BaseInnerRequest
    {
        [JsonProperty("requesttypedescriptions", ItemConverterType = typeof(StringEnumConverter))]
        protected RequestTypeDescriptionEnum[] _requestTypeDescriptions { get; }

        protected BaseInnerRequest(RequestTypeDescriptionEnum requestTypeDescription)
        {
            _requestTypeDescriptions = new [] { requestTypeDescription };
        }
    }
}

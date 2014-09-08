﻿
using Ds3.Calls;
using Ds3.Runtime;
using System;
using System.Linq;
using System.Net;

namespace Ds3.ResponseParsers
{
    class GetAvailableJobChunksResponseParser : IResponseParser<GetAvailableJobChunksRequest, GetAvailableJobChunksResponse>
    {
        public GetAvailableJobChunksResponse Parse(GetAvailableJobChunksRequest request, IWebResponse response)
        {
            using (response)
            {
                ResponseParseUtilities.HandleStatusCode(response, HttpStatusCode.OK, HttpStatusCode.NotFound);
                using (var responseStream = response.GetResponseStream())
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.OK:
                            var jobResponse = JobResponseParser<GetAvailableJobChunksRequest>.ParseResponseContent(responseStream);
                            if (jobResponse.ObjectLists.Any())
                            {
                                return GetAvailableJobChunksResponse.Success(jobResponse);
                            }
                            return GetAvailableJobChunksResponse.RetryAfter(TimeSpan.FromSeconds(int.Parse(response.Headers["retry-after"])));

                        case HttpStatusCode.NotFound:
                            return GetAvailableJobChunksResponse.JobGone;

                        default:
                            throw new NotSupportedException("This line of code should be impossible to hit.");
                    }
                }
            }
        }
    }
}

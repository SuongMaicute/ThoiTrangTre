﻿using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;

namespace API.Utility
{
    public class BackendApiAuthenthicationHttpClientHandler : DelegatingHandler
    {
            private readonly IHttpContextAccessor _accessor;

            public BackendApiAuthenthicationHttpClientHandler(IHttpContextAccessor accessor)
            {
                _accessor = accessor;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var token = await _accessor.HttpContext.GetTokenAsync("access_token");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await base.SendAsync(request, cancellationToken);
            }
        }
}

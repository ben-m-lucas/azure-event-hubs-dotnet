﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Collections.ObjectModel;
    using System.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;

    /// <summary>
    /// Extends SecurityToken for JWT specific properties
    /// </summary>
    public class JsonSecurityToken : SecurityToken
    {
        /// <summary>
        /// Creates a new instance of the <see cref="JsonSecurityToken"/> class.
        /// </summary>
        /// <param name="rawToken">Raw JSON Web Token string</param>
        /// <param name="audience">The audience</param>
        public JsonSecurityToken(string rawToken, string audience)
            : base(rawToken, DateTime.MinValue, audience, Constants.JsonWebTokenType)
        {
            var jwtSecurityToken = new JwtSecurityToken(rawToken);
            this.tokenType = ClientConstants.JsonWebTokenType;
            this.token = rawToken;
            this.expiresAtUtc = jwtSecurityToken.ValidTo;
            this.audience = audience;
        }
    }
}

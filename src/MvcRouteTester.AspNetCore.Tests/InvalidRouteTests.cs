﻿#region License
// Copyright (c) Niklas Wendel 2018
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
#endregion
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Xunit;
using TestWebApplication.Controllers;

namespace MvcRouteTester.AspNetCore.Tests
{

    /// <summary>
    /// 
    /// </summary>
    public class InvalidRouteTests : IClassFixture<TestServerFixture>
    {

        /// <summary>
        /// 
        /// </summary>
        private readonly TestServer _server;

        /// <summary>
        /// 
        /// </summary>
        public InvalidRouteTests(TestServerFixture testServerFixture)
        {
            _server = testServerFixture.Server;
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task ThrowsOnMapsToStaticMethod()
        {
            await Assert.ThrowsAsync<ArgumentException>("actionCallExpression", () =>
                RouteAssert.ForAsync(
                    _server,
                    request => request.WithPathAndQuery("/invalid/static"),
                    routeAssert => routeAssert.MapsTo<InvalidController>(a => InvalidController.Static())));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task ThrowsOnMapsToNonMethod()
        {
            await Assert.ThrowsAsync<ArgumentException>("actionCallExpression", () =>
                RouteAssert.ForAsync(
                    _server,
                    request => request.WithPathAndQuery("/invalid/static"),
                    routeAssert => routeAssert.MapsTo<InvalidController>(a => (IActionResult)null)));
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task ThrowsOnMapsToNonActionMethod()
        {
            await Assert.ThrowsAsync<ArgumentException>("actionCallExpression", () =>
                RouteAssert.ForAsync(
                    _server,
                    request => request.WithPathAndQuery("/invalid/non-action"),
                    routeAssert => routeAssert.MapsTo<InvalidController>(a => a.NonAction())));
        }

    }

}

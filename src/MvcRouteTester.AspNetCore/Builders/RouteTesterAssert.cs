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
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MvcRouteTester.AspNetCore.Internal;

namespace MvcRouteTester.AspNetCore.Builders
{

    /// <summary>
    /// 
    /// </summary>
    public class RouteTesterAssert : 
        IRouteAssertBuilder,
        IRouteAssert
    {

        #region Maps To

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TController"></typeparam>
        /// <param name="actionCallExpression"></param>
        /// <returns></returns>
        public IRouteAssertBuilder MapsTo<TController>(Expression<Func<TController, IActionResult>> actionCallExpression) 
            where TController : Controller
        {
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TController"></typeparam>
        /// <param name="actionCallExpression"></param>
        /// <returns></returns>
        public IRouteAssertBuilder MapsTo<TController>(Expression<Func<TController, Task<IActionResult>>> actionCallExpression) 
            where TController : Controller
        {
            return this;
        }

        #endregion

        #region Ensure

        /// <summary>
        /// 
        /// </summary>
        /// <param name="responseMessage"></param>
        public void Ensure(HttpResponseMessage responseMessage)
        {
            responseMessage.EnsureSuccessStatusCode();

            var json = responseMessage.Content.ReadAsStringAsync().Result;
            var actionInvokeInfo = JsonConvert.DeserializeObject<ActionInvokeInfo>(json);

        }

        #endregion

    }

}

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
using Xunit;
using MvcRouteTester.AspNetCore.Internal;
using TestWebApplication.Controllers;

namespace MvcRouteTester.AspNetCore.Tests.Internal
{

    /// <summary>
    /// 
    /// </summary>
    public class MethodInfoExtensionsTests
    {

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void ThrowsOnGetTextNullGetTypeName()
        {
            var tested = typeof(ParameterController)
                .GetMethod(nameof(ParameterController.QueryStringParameter));

            Assert.Throws<ArgumentNullException>("getTypeName", () => tested.GetActionText(null));
        }
        
    }

}

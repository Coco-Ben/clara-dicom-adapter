/*
 * Apache License, Version 2.0
 * Copyright 2019-2020 NVIDIA Corporation
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

public class HostedServiceController<T> : IHostedService where T : IHostedService
{
    readonly T _hostedService;

    public HostedServiceController(T backgroundService)
    {
        this._hostedService = backgroundService;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return _hostedService.StartAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _hostedService.StopAsync(cancellationToken);
    }
}
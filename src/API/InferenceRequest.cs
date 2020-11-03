﻿/*
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

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Text;
using Ardalis.GuardClauses;
using Newtonsoft.Json;

namespace Nvidia.Clara.DicomAdapter.API
{
    public class InferenceRequest : Job
    {
        public string JobPayloadsStoragePath { get; set; }
        public int TryCount { get; set; } = 0;

        [JsonIgnore]
        public IList<InstanceStorageInfo> Instances { get; set; }

        public InferenceRequest(string jobPayloadsStoragePath, Job job)
        {
            Guard.Against.NullOrWhiteSpace(jobPayloadsStoragePath, nameof(jobPayloadsStoragePath));
            Guard.Against.Null(job, nameof(job));

            JobPayloadsStoragePath = jobPayloadsStoragePath;
            JobId = job.JobId;
            PayloadId = job.PayloadId;
        }

        [JsonConstructor]
        private InferenceRequest()
        {
        }
    }
}

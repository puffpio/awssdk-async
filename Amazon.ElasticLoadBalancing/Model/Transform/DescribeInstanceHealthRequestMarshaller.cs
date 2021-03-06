/*
 * Copyright 2010 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * 
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 * 
 *  http://aws.amazon.com/apache2.0
 * 
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.ElasticLoadBalancing.Model.Transform
{
    /// <summary>
    /// Describe Instance Health Request Marshaller
    /// </summary>       
    public class DescribeInstanceHealthRequestMarshaller : IMarshaller<IRequest<DescribeInstanceHealthRequest>, DescribeInstanceHealthRequest> 
    {

        public IRequest<DescribeInstanceHealthRequest> Marshall(DescribeInstanceHealthRequest describeInstanceHealthRequest) 
        {
            IRequest<DescribeInstanceHealthRequest> request = new DefaultRequest<DescribeInstanceHealthRequest>(describeInstanceHealthRequest, "AmazonElasticLoadBalancing");
            request.Parameters.Add("Action", "DescribeInstanceHealth");
            request.Parameters.Add("Version", "2010-07-01");
            if (describeInstanceHealthRequest != null && describeInstanceHealthRequest.IsSetLoadBalancerName()) 
            {
                request.Parameters.Add("LoadBalancerName", StringUtils.FromString(describeInstanceHealthRequest.LoadBalancerName));
            }

            if (describeInstanceHealthRequest != null) 
            {
                List<Instance> instancesList = describeInstanceHealthRequest.Instances;
                int instancesListIndex = 1;
                foreach (Instance instancesListValue in instancesList) 
                { 
                    if (instancesListValue != null && instancesListValue.IsSetInstanceId()) 
                    {
                        request.Parameters.Add("Instances.member." + instancesListIndex + ".InstanceId", StringUtils.FromString(instancesListValue.InstanceId));
                    }

                    instancesListIndex++;
                }
            }


            return request;
        }
    }
}

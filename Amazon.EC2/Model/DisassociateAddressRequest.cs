/*******************************************************************************
 * Copyright 2008-2010 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 * this file except in compliance with the License. A copy of the License is located at
 *
 * http://aws.amazon.com/apache2.0
 *
 * or in the "license" file accompanying this file. This file is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
 * or implied. See the License for the specific language governing permissions and
 * limitations under the License.
 * *****************************************************************************
 *    __  _    _  ___
 *   (  )( \/\/ )/ __)
 *   /__\ \    / \__ \
 *  (_)(_) \/\/  (___/
 *
 *  AWS SDK for .NET
 *  API Version: 2010-08-31
 */

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;

namespace Amazon.EC2.Model
{
    /// <summary>
    /// Disassociates the specified elastic IP address
    /// from the instance to which it is
    /// assigned. This is an idempotent
    /// operation. If you enter it more
    /// than once, Amazon EC2 does not
    /// return an error.
    /// </summary>
    [XmlRootAttribute(Namespace = "http://ec2.amazonaws.com/doc/2010-08-31/", IsNullable = false)]
    public class DisassociateAddressRequest
    {    
        private string publicIpField;

        /// <summary>
        /// Gets and sets the PublicIp property.
        /// IP address that you are disassociating from
        /// the instance.
        /// </summary>
        [XmlElementAttribute(ElementName = "PublicIp")]
        public string PublicIp
        {
            get { return this.publicIpField; }
            set { this.publicIpField = value; }
        }

        /// <summary>
        /// Sets the PublicIp property
        /// </summary>
        /// <param name="publicIp">IP address that you are disassociating from
        /// the instance.</param>
        /// <returns>this instance</returns>
        public DisassociateAddressRequest WithPublicIp(string publicIp)
        {
            this.publicIpField = publicIp;
            return this;
        }

        /// <summary>
        /// Checks if PublicIp property is set
        /// </summary>
        /// <returns>true if PublicIp property is set</returns>
        public bool IsSetPublicIp()
        {
            return this.publicIpField != null;
        }

    }
}

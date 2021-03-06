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
    ///<summary>
    ///Snapshot Attribute
    ///</summary>
    [XmlRootAttribute(Namespace = "http://ec2.amazonaws.com/doc/2010-08-31/", IsNullable = false)]
    public class SnapshotAttribute
    {    
        private string snapshotIdField;
        private List<CreateVolumePermission> createVolumePermissionField;

        /// <summary>
        /// Gets and sets the SnapshotId property.
        /// The ID of the Amazon EBS snapshot.
        /// </summary>
        [XmlElementAttribute(ElementName = "SnapshotId")]
        public string SnapshotId
        {
            get { return this.snapshotIdField; }
            set { this.snapshotIdField = value; }
        }

        /// <summary>
        /// Sets the SnapshotId property
        /// </summary>
        /// <param name="snapshotId">The ID of the Amazon EBS snapshot.</param>
        /// <returns>this instance</returns>
        public SnapshotAttribute WithSnapshotId(string snapshotId)
        {
            this.snapshotIdField = snapshotId;
            return this;
        }

        /// <summary>
        /// Checks if SnapshotId property is set
        /// </summary>
        /// <returns>true if SnapshotId property is set</returns>
        public bool IsSetSnapshotId()
        {
            return this.snapshotIdField != null;
        }

        /// <summary>
        /// Gets and sets the CreateVolumePermission property.
        /// list of create volume permissions
        /// </summary>
        [XmlElementAttribute(ElementName = "CreateVolumePermission")]
        public List<CreateVolumePermission> CreateVolumePermission
        {
            get
            {
                if (this.createVolumePermissionField == null)
                {
                    this.createVolumePermissionField = new List<CreateVolumePermission>();
                }
                return this.createVolumePermissionField;
            }
            set { this.createVolumePermissionField = value; }
        }

        /// <summary>
        /// Sets the CreateVolumePermission property
        /// </summary>
        /// <param name="list">list of create volume permissions</param>
        /// <returns>this instance</returns>
        public SnapshotAttribute WithCreateVolumePermission(params CreateVolumePermission[] list)
        {
            foreach (CreateVolumePermission item in list)
            {
                CreateVolumePermission.Add(item);
            }
            return this;
        }

        /// <summary>
        /// Checks if CreateVolumePermission property is set
        /// </summary>
        /// <returns>true if CreateVolumePermission property is set</returns>
        public bool IsSetCreateVolumePermission()
        {
            return (CreateVolumePermission.Count > 0);
        }

    }
}

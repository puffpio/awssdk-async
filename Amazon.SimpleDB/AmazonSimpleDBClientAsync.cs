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
 *  API Version: 2009-04-15
 */

/*
    Copied most of it out of AmazonSimpleDBClient and then made the async mods - David Pio 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

using Amazon.Util;
using Amazon.SimpleDB.Model;

namespace Amazon.SimpleDB
{
    public partial class AmazonSimpleDBClient : AmazonSimpleDB
    {
        /// <summary>
        /// Create Domain async
        /// </summary>
        /// <param name="request">Create Domain  request</param>
        /// <returns>Create Domain  Response from the service</returns>
        /// <remarks>
        /// The CreateDomain operation creates a new domain. The domain name must be unique
        /// among the domains associated with the Access Key ID provided in the request. The CreateDomain
        /// operation may take 10 or more seconds to complete.
        /// </remarks>
        public async Task<CreateDomainResponse> CreateDomainAsync(CreateDomainRequest request)
        {
            return await InvokeAsync<CreateDomainResponse>(ConvertCreateDomain(request));
        }

        /// <summary>
        /// List Domains async
        /// </summary>
        /// <param name="request">List Domains  request</param>
        /// <returns>List Domains  Response from the service</returns>
        /// <remarks>
        /// The ListDomains operation lists all domains associated with the Access Key ID. It returns
        /// domain names up to the limit set by MaxNumberOfDomains. A NextToken is returned if there are more
        /// than MaxNumberOfDomains domains. Calling ListDomains successive times with the
        /// NextToken returns up to MaxNumberOfDomains more domain names each time.
        /// </remarks>
        public async Task<ListDomainsResponse> ListDomainsAsync(ListDomainsRequest request)
        {
            return await InvokeAsync<ListDomainsResponse>(ConvertListDomains(request));
        }

        /// <summary>
        /// Domain Metadata async
        /// </summary>
        /// <param name="request">Domain Metadata  request</param>
        /// <returns>Domain Metadata  Response from the service</returns>
        /// <remarks>
        /// The DomainMetadata operation returns some domain metadata values, such as the
        /// number of items, attribute names and attribute values along with their sizes.
        /// </remarks>
        public async Task<DomainMetadataResponse> DomainMetadataAsync(DomainMetadataRequest request)
        {
            return await InvokeAsync<DomainMetadataResponse>(ConvertDomainMetadata(request));
        }

        /// <summary>
        /// Delete Domain async
        /// </summary>
        /// <param name="request">Delete Domain  request</param>
        /// <returns>Delete Domain  Response from the service</returns>
        /// <remarks>
        /// The DeleteDomain operation deletes a domain. Any items (and their attributes) in the domain
        /// are deleted as well. The DeleteDomain operation may take 10 or more seconds to complete.
        /// </remarks>
        public async Task<DeleteDomainResponse> DeleteDomainAsync(DeleteDomainRequest request)
        {
            return await InvokeAsync<DeleteDomainResponse>(ConvertDeleteDomain(request));
        }

        /// <summary>
        /// Put Attributes
        /// </summary>
        /// <param name="request">Put Attributes  request</param>
        /// <returns>Put Attributes  Response from the service</returns>
        /// <remarks>
        /// The PutAttributes operation creates or replaces attributes within an item. You specify new attributes
        /// using a combination of the Attribute.X.Name and Attribute.X.Value parameters. You specify
        /// the first attribute by the parameters Attribute.0.Name and Attribute.0.Value, the second
        /// attribute by the parameters Attribute.1.Name and Attribute.1.Value, and so on.
        /// Attributes are uniquely identified within an item by their name/value combination. For example, a single
        /// item can have the attributes { "first_name", "first_value" } and { "first_name",
        /// second_value" }. However, it cannot have two attribute instances where both the Attribute.X.Name and
        /// Attribute.X.Value are the same.
        /// Optionally, the requestor can supply the Replace parameter for each individual value. Setting this value
        /// to true will cause the new attribute value to replace the existing attribute value(s). For example, if an
        /// item has the attributes { 'a', '1' }, { 'b', '2'} and { 'b', '3' } and the requestor does a
        /// PutAttributes of { 'b', '4' } with the Replace parameter set to true, the final attributes of the
        /// item will be { 'a', '1' } and { 'b', '4' }, replacing the previous values of the 'b' attribute
        /// with the new value.
        /// </remarks>
        public async Task<PutAttributesResponse> PutAttributesAsync(PutAttributesRequest request)
        {
            return await InvokeAsync<PutAttributesResponse>(ConvertPutAttributes(request));
        }

        /// <summary>
        /// Batch Put Attributes
        /// </summary>
        /// <param name="request">Batch Put Attributes  request</param>
        /// <returns>Batch Put Attributes  Response from the service</returns>
        /// <remarks>
        /// The BatchPutAttributes operation creates or replaces attributes within one or more items.
        /// You specify the item name with the Item.X.ItemName parameter.
        /// You specify new attributes using a combination of the Item.X.Attribute.Y.Name and Item.X.Attribute.Y.Value parameters.
        /// You specify the first attribute for the first item by the parameters Item.0.Attribute.0.Name and Item.0.Attribute.0.Value,
        /// the second attribute for the first item by the parameters Item.0.Attribute.1.Name and Item.0.Attribute.1.Value, and so on.
        /// Attributes are uniquely identified within an item by their name/value combination. For example, a single
        /// item can have the attributes { "first_name", "first_value" } and { "first_name",
        /// second_value" }. However, it cannot have two attribute instances where both the Item.X.Attribute.Y.Name and
        /// Item.X.Attribute.Y.Value are the same.
        /// Optionally, the requestor can supply the Replace parameter for each individual value. Setting this value
        /// to true will cause the new attribute value to replace the existing attribute value(s). For example, if an
        /// item 'I' has the attributes { 'a', '1' }, { 'b', '2'} and { 'b', '3' } and the requestor does a
        /// BacthPutAttributes of {'I', 'b', '4' } with the Replace parameter set to true, the final attributes of the
        /// item will be { 'a', '1' } and { 'b', '4' }, replacing the previous values of the 'b' attribute
        /// with the new value.
        /// </remarks>
        public async Task<BatchPutAttributesResponse> BatchPutAttributesAsync(BatchPutAttributesRequest request)
        {
            return await InvokeAsync<BatchPutAttributesResponse>(ConvertBatchPutAttributes(request));
        }

        /// <summary>
        /// Get Attributes
        /// </summary>
        /// <param name="request">Get Attributes  request</param>
        /// <returns>Get Attributes  Response from the service</returns>
        /// <remarks>
        /// Returns all of the attributes associated with the item. Optionally, the attributes returned can be limited to
        /// the specified AttributeName parameter.
        /// If the item does not exist on the replica that was accessed for this operation, an empty attribute is
        /// returned. The system does not return an error as it cannot guarantee the item does not exist on other
        /// replicas.
        /// </remarks>
        public async Task<GetAttributesResponse> GetAttributesAsync(GetAttributesRequest request)
        {
            return await InvokeAsync<GetAttributesResponse>(ConvertGetAttributes(request));
        }

        /// <summary>
        /// Delete Attributes
        /// </summary>
        /// <param name="request">Delete Attributes  request</param>
        /// <returns>Delete Attributes  Response from the service</returns>
        /// <remarks>
        /// Deletes one or more attributes associated with the item. If all attributes of an item are deleted, the item is
        /// deleted.
        /// </remarks>
        public async Task<DeleteAttributesResponse> DeleteAttributesAsync(DeleteAttributesRequest request)
        {
            return await InvokeAsync<DeleteAttributesResponse>(ConvertDeleteAttributes(request));
        }

        /// <summary>
        /// Select async
        /// </summary>
        /// <param name="request">Select  request</param>
        /// <returns>Select  Response from the service</returns>
        /// <remarks>
        /// The Select operation returns a set of item names and associate attributes that match the
        /// query expression. Select operations that run longer than 5 seconds will likely time-out
        /// and return a time-out error response.
        /// </remarks>
        public async Task<SelectResponse> SelectAsync(SelectRequest request)
        {
            return await InvokeAsync<SelectResponse>(ConvertSelect(request));
        }

        /**
         * Invoke request and return response, async version
         */
        private async Task<T> InvokeAsync<T>(IDictionary<string, string> parameters)
        {
            string actionName = parameters["Action"];
            T response = default(T);
            HttpStatusCode statusCode = default(HttpStatusCode);

#if TRACE
            DateTime start = DateTime.UtcNow;
            Trace.Write(String.Format("{0}, {1}, ", actionName, start));
#endif

            /* Add required request parameters */
            AddRequiredParameters(parameters);

            string queryString = AWSSDKUtils.GetParametersAsString(parameters);

            byte[] requestData = Encoding.UTF8.GetBytes(queryString);
            bool shouldRetry = true;
            int retries = 0;
            int maxRetries = config.IsSetMaxErrorRetry() ? config.MaxErrorRetry : AWSSDKUtils.DefaultMaxRetry;

            do
            {
                string responseBody = null;
                HttpWebRequest request = ConfigureWebRequest(requestData.Length, config);
                /* Submit the request and read response body */
                try
                {
                    using (Stream requestStream = await request.GetRequestStreamAsync())
                    {
                        await requestStream.WriteAsync(requestData, 0, requestData.Length);
                    }
#if TRACE
                    DateTime requestSent = DateTime.UtcNow;
                    Trace.Write(String.Format("{0}, ", (requestSent - start).TotalMilliseconds));
#endif

                    HttpWebResponse httpResponse = await request.GetResponseAsync() as HttpWebResponse;

#if TRACE
                    DateTime responseReceived = DateTime.UtcNow;
                    Trace.Write(String.Format("{0}, ", (responseReceived - requestSent).TotalMilliseconds));
#endif

                    using (httpResponse)
                    {
                        if (httpResponse == null)
                        {
                            throw new WebException(
                                "The Web Response for a successful request is null!",
                                WebExceptionStatus.ProtocolError
                                );
                        }
                        statusCode = httpResponse.StatusCode;
                        using (StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8))
                        {
                            responseBody = (await reader.ReadToEndAsync()).Trim();
                        }
                    }

#if TRACE
                    DateTime streamRead = DateTime.UtcNow;
#endif

                    /* Perform response transformation for GetAttributes and Select operations */
                    if (actionName.Equals("GetAttributes") ||
                        actionName.Equals("Select"))
                    {
                        if (responseBody.EndsWith(String.Concat(actionName, "Response>")))
                        {
                            responseBody = Transform(responseBody, actionName, this.GetType());
                        }
                    }

#if TRACE
                    DateTime streamParsed = DateTime.UtcNow;
#endif

                    /* Attempt to deserialize response into <Action> Response type */
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlTextReader sr = new XmlTextReader(new StringReader(responseBody)))
                    {
                        response = (T)serializer.Deserialize(sr);
#if TRACE
                        DateTime objectCreated = DateTime.UtcNow;
                        Trace.Write(
                            String.Format("{0}, {1}, ",
                            (streamParsed - streamRead).TotalMilliseconds,
                            (objectCreated - streamParsed).TotalMilliseconds
                            ));
#endif
                    }
                    shouldRetry = false;

#if TRACE
                    DateTime end = DateTime.UtcNow;
                    Trace.Write(String.Format("{0}, ", end));
                    Trace.WriteLine((end - start).TotalMilliseconds);
                    Trace.Flush();
#endif
                }
                /* Web exception is thrown on unsucessful responses */
                catch (WebException we)
                {
                    shouldRetry = false;
                    using (HttpWebResponse httpErrorResponse = we.Response as HttpWebResponse)
                    {
                        if (httpErrorResponse == null)
                        {
                            // Abort the unsuccessful request
                            request.Abort();
                            throw we;
                        }
                        statusCode = httpErrorResponse.StatusCode;
                        using (StreamReader reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8))
                        {
                            // cannot use async version in a catch block
                            responseBody = reader.ReadToEnd();
                        }

                        // Abort the unsuccessful request
                        request.Abort();
                    }

                    if (statusCode == HttpStatusCode.InternalServerError ||
                        statusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        shouldRetry = true;
                        PauseOnRetry(++retries, maxRetries, statusCode);
                    }
                    else
                    {
                        throw ReportAnyErrors(responseBody, statusCode);
                    }
                }
                /* Catch other exceptions, attempt to convert to formatted exception,
                 * else rethrow wrapped exception */
                catch (Exception)
                {
                    // Abort the unsuccessful request
                    request.Abort();
                    throw;
                }
            } while (shouldRetry);

            return response;
        }

    }
}

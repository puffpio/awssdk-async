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
 *  API Version: 2009-02-01
 */

/*
    Copied most of it out of AmazonSQSClient and then made the async mods - David Pio 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Serialization;

using Amazon.SQS.Model;
using Attribute = Amazon.SQS.Model.Attribute;

using Amazon.Util;
using System.Threading.Tasks;

namespace Amazon.SQS
{
    public partial class AmazonSQSClient : AmazonSQS
    {
        #region Public API

        /// <summary>
        /// Create Queue 
        /// </summary>
        /// <param name="request">Create Queue  request</param>
        /// <returns>Create Queue  Response from the service</returns>
        /// <remarks>
        /// The CreateQueue action creates a new queue, or returns the URL of an existing one.
        /// When you request CreateQueue, you provide a name for the queue. To successfully create
        /// a new queue, you must provide a name that is unique within the scope of your own queues.
        /// If you provide the name of an existing queue, a new queue isn't created and an error
        /// isn't returned. Instead, the request succeeds and the queue URL for the existing queue is
        /// returned. Exception: if you provide a value for DefaultVisibilityTimeout that is different
        /// from the value for the existing queue, you receive an error.
        /// </remarks>
        public Task<CreateQueueResponse> CreateQueueAsync(CreateQueueRequest request)
        {
            return InvokeAsync<CreateQueueResponse>(ConvertCreateQueue(request));
        }

        /// <summary>
        /// List Queues 
        /// </summary>
        /// <param name="request">List Queues  request</param>
        /// <returns>List Queues  Response from the service</returns>
        /// <remarks>
        /// The ListQueues action returns a list of your queues.
        /// </remarks>
        public Task<ListQueuesResponse> ListQueuesAsync(ListQueuesRequest request)
        {
            return InvokeAsync<ListQueuesResponse>(ConvertListQueues(request));
        }

        /// <summary>
        /// Add Permission 
        /// </summary>
        /// <param name="request">Add Permission  request</param>
        /// <returns>Add Permission  Response from the service</returns>
        /// <remarks>
        /// Adds the specified permission(s) to a queue for the specified principal(s). This allows for sharing access to the queue.
        /// </remarks>
        public Task<AddPermissionResponse> AddPermissionAsync(AddPermissionRequest request)
        {
            return InvokeAsync<AddPermissionResponse>(ConvertAddPermission(request));
        }

        /// <summary>
        /// Change Message Visibility 
        /// </summary>
        /// <param name="request">Change Message Visibility  request</param>
        /// <returns>Change Message Visibility  Response from the service</returns>
        /// <remarks>
        /// The ChangeMessageVisibility action extends the read lock timeout of the specified message from the specified queue to the specified value.
        /// </remarks>
        public Task<ChangeMessageVisibilityResponse> ChangeMessageVisibilityAsync(ChangeMessageVisibilityRequest request)
        {
            return InvokeAsync<ChangeMessageVisibilityResponse>(ConvertChangeMessageVisibility(request));
        }

        /// <summary>
        /// Delete Message 
        /// </summary>
        /// <param name="request">Delete Message  request</param>
        /// <returns>Delete Message  Response from the service</returns>
        /// <remarks>
        /// The DeleteMessage action unconditionally removes the specified message from the specified queue. Even if the message is locked by another reader due to the visibility timeout setting, it is still deleted from the queue.
        /// </remarks>
        public Task<DeleteMessageResponse> DeleteMessageAsync(DeleteMessageRequest request)
        {
            return InvokeAsync<DeleteMessageResponse>(ConvertDeleteMessage(request));
        }

        /// <summary>
        /// Delete Queue 
        /// </summary>
        /// <param name="request">Delete Queue  request</param>
        /// <returns>Delete Queue  Response from the service</returns>
        /// <remarks>
        /// This action unconditionally deletes the queue specified by the queue URL. Use this operation WITH CARE!  The queue is deleted even if it is NOT empty.
        /// </remarks>
        public Task<DeleteQueueResponse> DeleteQueueAsync(DeleteQueueRequest request)
        {
            return InvokeAsync<DeleteQueueResponse>(ConvertDeleteQueue(request));
        }

        /// <summary>
        /// Get Queue Attributes 
        /// </summary>
        /// <param name="request">Get Queue Attributes  request</param>
        /// <returns>Get Queue Attributes  Response from the service</returns>
        /// <remarks>
        /// Gets one or all attributes of a queue. Queues currently have two attributes you can get: ApproximateNumberOfMessages and VisibilityTimeout.
        /// </remarks>
        public Task<GetQueueAttributesResponse> GetQueueAttributesAsync(GetQueueAttributesRequest request)
        {
            return InvokeAsync<GetQueueAttributesResponse>(ConvertGetQueueAttributes(request));
        }

        /// <summary>
        /// Remove Permission 
        /// </summary>
        /// <param name="request">Remove Permission  request</param>
        /// <returns>Remove Permission  Response from the service</returns>
        /// <remarks>
        /// Removes the permission with the specified statement id from the queue.
        /// </remarks>
        public Task<RemovePermissionResponse> RemovePermissionAsync(RemovePermissionRequest request)
        {
            return InvokeAsync<RemovePermissionResponse>(ConvertRemovePermission(request));
        }

        /// <summary>
        /// Receive Message 
        /// </summary>
        /// <param name="request">Receive Message  request</param>
        /// <returns>Receive Message  Response from the service</returns>
        /// <remarks>
        /// Retrieves one or more messages from the specified queue.  For each message returned, the response includes
        /// the message body; MD5 digest of the message body; receipt handle, which is the identifier you must provide
        /// when deleting the message; and message ID of each message. Messages returned by this action stay in the queue
        /// until you delete them. However, once a message is returned to a ReceiveMessage request, it is not returned
        /// on subsequent ReceiveMessage requests for the duration of the VisibilityTimeout. If you do not specify a
        /// VisibilityTimeout in the request, the overall visibility timeout for the queue is used for the returned messages.
        /// </remarks>
        public Task<ReceiveMessageResponse> ReceiveMessageAsync(ReceiveMessageRequest request)
        {
            return InvokeAsync<ReceiveMessageResponse>(ConvertReceiveMessage(request));
        }

        /// <summary>
        /// Send Message 
        /// </summary>
        /// <param name="request">Send Message  request</param>
        /// <returns>Send Message  Response from the service</returns>
        /// <remarks>
        /// The SendMessage action delivers a message to the specified queue.
        /// </remarks>
        public Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request)
        {
            return InvokeAsync<SendMessageResponse>(ConvertSendMessage(request));
        }

        /// <summary>
        /// Set Queue Attributes 
        /// </summary>
        /// <param name="request">Set Queue Attributes  request</param>
        /// <returns>Set Queue Attributes  Response from the service</returns>
        /// <remarks>
        /// Sets an attribute of a queue. Currently, you can set only the VisibilityTimeout attribute for a queue.
        /// </remarks>
        public Task<SetQueueAttributesResponse> SetQueueAttributesAsync(SetQueueAttributesRequest request)
        {
            return InvokeAsync<SetQueueAttributesResponse>(ConvertSetQueueAttributes(request));
        }

        #endregion

        #region Private Async API

        /**
         * Invoke request and return response
         */
        private async Task<T> InvokeAsync<T>(IDictionary<string, string> parameters)
        {
            string actionName = parameters["Action"];
            T response = default(T);
            string queueUrl = parameters.ContainsKey("QueueUrl") ? parameters["QueueUrl"] : config.ServiceURL;

            if (parameters.ContainsKey("QueueUrl"))
            {
                parameters.Remove("QueueUrl");
            }
            HttpStatusCode statusCode = default(HttpStatusCode);

            /* Add required request parameters */
            AddRequiredParameters(parameters, queueUrl);

            string queryString = AWSSDKUtils.GetParametersAsString(parameters);

            byte[] requestData = Encoding.UTF8.GetBytes(queryString);
            bool shouldRetry = true;
            int retries = 0;
            int maxRetries = config.IsSetMaxErrorRetry() ? config.MaxErrorRetry : AWSSDKUtils.DefaultMaxRetry;
            do
            {
                string responseBody = null;
                HttpWebRequest request = ConfigureWebRequest(requestData.Length, queueUrl, config);
                /* Submit the request and read response body */
                try
                {
                    using (Stream requestStream = await request.GetRequestStreamAsync())
                    {
                        await requestStream.WriteAsync(requestData, 0, requestData.Length);
                    }

                    using (HttpWebResponse httpResponse = await request.GetResponseAsync() as HttpWebResponse)
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
                            // cannot use await in a catch block
                            responseBody = await reader.ReadToEndAsync();
                        }
                    }

                    /* Attempt to deserialize response into <Action> Response type */
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (XmlTextReader sr = new XmlTextReader(new StringReader(responseBody)))
                    {
                        response = (T)serializer.Deserialize(sr);
                    }
                    shouldRetry = false;
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
                            responseBody = reader.ReadToEndAsync().Result;
                        }

                        // Abort the unsuccessful request
                        request.Abort();
                    }

                    if (statusCode == HttpStatusCode.InternalServerError ||
                        statusCode == HttpStatusCode.ServiceUnavailable)
                    {
                        shouldRetry = true;
                        PauseOnRetryAsync(++retries, maxRetries, statusCode).Wait();
                    }
                    else
                    {
                        /* Attempt to deserialize response into ErrorResponse type */
                        try
                        {
                            using (XmlTextReader sr = new XmlTextReader(new StringReader(responseBody)))
                            {
                                XmlSerializer serializer = new XmlSerializer(typeof(ErrorResponse));
                                ErrorResponse errorResponse = (ErrorResponse)serializer.Deserialize(sr);
                                Error error = errorResponse.Error[0];

                                /* Throw formatted exception with information available from the error response */
                                throw new AmazonSQSException(
                                    error.Message,
                                    statusCode,
                                    error.Code,
                                    error.Type,
                                    errorResponse.RequestId,
                                    errorResponse.ToXML()
                                    );
                            }
                        }
                        /* Rethrow on deserializer error */
                        catch (Exception e)
                        {
                            if (e is AmazonSQSException)
                            {
                                throw;
                            }
                            else
                            {
                                throw ReportAnyErrors(responseBody, statusCode);
                            }
                        }
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

        /**
         * Exponential sleep on failed request
         */
        private static async Task PauseOnRetryAsync(int retries, int maxRetries, HttpStatusCode status)
        {
            if (retries <= maxRetries)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                await TaskEx.Delay(delay);
            }
            else
            {
                throw new AmazonSQSException(
                    "Maximum number of retry attempts reached : " + (retries - 1),
                    status
                    );
            }
        }

        #endregion
    }
}

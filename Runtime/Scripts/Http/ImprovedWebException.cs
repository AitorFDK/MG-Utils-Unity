using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace MendiGames.Utils.Http
{
    public class ImprovedWebException : WebException
    {
        public ImprovedWebException(WebException webException) : base (webException.Message, webException.InnerException, webException.Status, webException.Response)
        {
            
        }

        public HttpStatusCode StatusCode {
            get
            {
                var property = Response.GetType().GetProperty("StatusCode");
                return (HttpStatusCode)property?.GetValue(Response);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}\r\nHttpStatusCode: {2}\r\n{3}", this.GetType().Name, this.Message, StatusCode, this.StackTrace);
        }
    }
}
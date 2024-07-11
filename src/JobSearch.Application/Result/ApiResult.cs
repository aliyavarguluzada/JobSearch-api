using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Result
{
    public class ApiResult<T>
    {
        public T Response { get; set; }
        public int StatusCode { get; set; }
        public int ErrorCode { get; set; }
        public List<T>? Values { get; set; }
        public Dictionary<string, string> ErrorList { get; set; }

        public static ApiResult<T> Ok(T response)
        {
            return new ApiResult<T>
            {
                Response = response,
                StatusCode = (int)HttpStatusCode.OK,
                ErrorList = null,
                Values = new List<T> { response }
            };
        }

        public static ApiResult<T> Error( Dictionary<string, string> errorList = null, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new ApiResult<T>
            {
                Response = default,
                StatusCode = statusCode,
                ErrorList = errorList
            };
        }
    }
}

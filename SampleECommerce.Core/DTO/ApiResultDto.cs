using SampleECommerce.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleECommerce.Core.DTO
{
    public class ApiResultDto<T>
    {
        public ApiResultDto()
        {
            Status = ResultStatusEnum.Success;
        }

        public T Data { get; set; }
        public ResultStatusEnum Status { get; set; }
        public string Message { get; set; }
    }
}

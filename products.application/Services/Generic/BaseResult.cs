using products.application.DTO;
using products.application.Interfaces.Generic;

namespace products.application.Services.Generic
{
    public class BaseResult: IBaseResult
    {
        public ResultDTO<T> returnResult<T>(T? entity, bool prSucess, string? prMessage){
            var result = new ResultDTO<T>
            {
                Success = prSucess,
                Message = prMessage == null ? "OKAY" : prMessage,
                Result = entity
            };

            return result;
        }
    }
}
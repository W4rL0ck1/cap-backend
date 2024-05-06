using products.application.DTO;

namespace products.application.Interfaces.Generic
{
    public interface IBaseResult
    {
        public ResultDTO<T> returnResult<T>(T? entity, bool prSucess, string? prMessage);
    }
}
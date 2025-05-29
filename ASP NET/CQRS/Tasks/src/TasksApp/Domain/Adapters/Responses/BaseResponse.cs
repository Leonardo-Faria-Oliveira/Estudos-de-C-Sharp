namespace Domain.Adapters.Responses
{
    public record BaseResponse<T>(
    
        ResponseInfo? ResponseInfo,
        T? Value
        
    );
   
}

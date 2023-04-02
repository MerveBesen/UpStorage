namespace Domain.Common;

public class Response<T>
{
    public string Massage { get; set; }
    public T Data { get; set; }
    public List<string> Errors { get; set; }

    public Response()
    {
        
    }

    public Response(string massage)
    {
        Massage = massage;
    }

    public Response(string massage, T data)
    {
        Massage = massage;
        
        Data = data;
    }

    public Response(T data)
    {
        Data = data;
    }

    public Response(string massage, T data, List<string> errors)
    {
        Massage = massage;
        
        Data = data;
        
        Errors = errors;
    }

    public Response(string massage, List<string> errors)
    {
        Massage = massage;
        
        Errors = errors;
    }
 }
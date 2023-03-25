namespace Domain.Common;

public interface IModifiedByEntity      //Düzenleme geçmişini tutmak için
{
    DateTimeOffset ModifiedOn { get; set; }
    public string? ModifiedByUserId { get; set; }
}
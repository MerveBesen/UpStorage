using System.Text;
using Application.Common.Interfaces;
using Application.Common.Models.Auth;
using OtpNet;
using QRCoder;

namespace Infrastructure.Services;

public class TwoFactorManager:ITwoFactorService
{
    private const string SecretKey = "VerySecretPassword123";
    
    public TwoFactorGeneratedDto Generate(string email)
    {
        var key = Encoding.UTF8.GetBytes(SecretKey);        //Secret key kısmını byte çevirdik.

        var uri = new OtpUri(OtpType.Totp, key, email, "Upstorage");        //Uri oluşturduk.

        var qrCodeGenerator = new QRCodeGenerator();        //Uri'yi qr code a çevirdik.
        
        var qrData = qrCodeGenerator.CreateQrCode(uri.ToString(), QRCodeGenerator.ECCLevel.Q);

        BitmapByteQRCode qrCode = new BitmapByteQRCode(qrData);         //Qr codu resme çevirdik.

        var twoFactorDto = new TwoFactorGeneratedDto();

        twoFactorDto.QrCodeImage = qrCode.GetGraphic(10);

        twoFactorDto.Key = Base32Encoding.ToString(key);

        return twoFactorDto;
    }

    public bool Validate(string userCode)
    {
        var key = Encoding.UTF8.GetBytes(SecretKey);
        
        var totp = new Totp(key);
        
        return totp.VerifyTotp(userCode, out _);
    }
}
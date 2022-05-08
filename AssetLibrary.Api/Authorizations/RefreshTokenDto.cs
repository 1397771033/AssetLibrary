namespace AssetLibrary.Api.Authorizations
{
    public class RefreshTokenDto
    {
        public const int expire = 60*60*24*30;
        public string sub { get; set; }
        public long iat { get; set; }
    }
}

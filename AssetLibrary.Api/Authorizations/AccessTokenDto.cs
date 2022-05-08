namespace AssetLibrary.Api.Authorizations
{
    public class AccessTokenDto
    {
        public const int expire = 60*60*2;
        public string sub { get; set; }
        public long iat { get; set; }
    }
}

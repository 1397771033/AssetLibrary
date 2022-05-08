namespace AssetLibrary.Api.Authorizations
{
    public class TokenDto
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expire { get => AccessTokenDto.expire; }
    }
}

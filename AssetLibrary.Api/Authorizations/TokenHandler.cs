using AssetLibrary.Api.Helpers;
using AssetLibrary.Api.Models.Entities;
using System;

namespace AssetLibrary.Api.Authorizations
{
    public class TokenHandler
    {
        public static string GetAccessTokenKey(string token) => $"access_token:{token}";
        public static string GetRefreshTokenKey(string token) => $"refresh_token:{token}";
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        public static TokenDto GeneratorToken(string tenantId)
        {
            var access_token= GeneratorAccessToken(tenantId);
            var refresh_token= GeneratorRefreshToken(tenantId);
            return new TokenDto
            {
                access_token = access_token,
                refresh_token = refresh_token
            };
        }
        /// <summary>
        /// 生成刷新令牌
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        private static string GeneratorRefreshToken(string tenantId)
        {
            string refresh_token = EncryptHelper.MD5Encrypt16(Guid.NewGuid().ToString("N"));
            string refresh_token_key = GetRefreshTokenKey(refresh_token);
            RedisHelper.Set(refresh_token_key, new RefreshTokenDto
            {
                sub = tenantId,
                iat = DateTimeOffset.Now.ToUnixTimeSeconds()
            }, TimeSpan.FromSeconds(RefreshTokenDto.expire));
            return refresh_token;
        }
        /// <summary>
        /// 生成访问令牌
        /// </summary>
        /// <param name="tenantId"></param>
        /// <returns></returns>
        private static string GeneratorAccessToken(string tenantId)
        {
            string access_token = EncryptHelper.MD5Encrypt32(Guid.NewGuid().ToString("N"));
            string access_token_key = GetAccessTokenKey(access_token);
            RedisHelper.Set(access_token_key, new AccessTokenDto
            {
                sub = tenantId,
                iat = DateTimeOffset.Now.ToUnixTimeSeconds()
            }, TimeSpan.FromSeconds(AccessTokenDto.expire));
            return access_token;
        }
        /// <summary>
        /// 判断刷新令牌是否有效
        /// </summary>
        /// <returns></returns>
        public static bool ValidRefreshToken(string refresh_token)
        {
            string key =GetRefreshTokenKey(refresh_token);
            return RedisHelper.Exists(key);
        }
        /// <summary>
        /// 获取访问令牌信息
        /// </summary>
        /// <returns></returns>
        public static AccessTokenDto GetAccessTokenInfo(string access_token)
        {
            string key = GetAccessTokenKey(access_token);
            return RedisHelper.Get<AccessTokenDto>(key);
        }
        /// <summary>
        /// 刷新令牌
        /// </summary>
        /// <returns></returns>
        public static TokenDto RefreshToken(string refresh_token)
        {
            var key =GetRefreshTokenKey(refresh_token);
            var tokenInfo=RedisHelper.Get<RefreshTokenDto>(key);
            if (tokenInfo != null)
            {
                RedisHelper.Del(key);
                return new TokenDto
                {
                    access_token = GeneratorAccessToken(tokenInfo.sub),
                    refresh_token = GeneratorRefreshToken(tokenInfo.sub)
                };
            }
            return default;
        }
    }
}

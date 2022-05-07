using AssetLibrary.Api.Models.Entities;
using AssetLibrary.Api.Models.Params.scenes;
using AssetLibrary.Api.Models.VO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetLibrary.Api.Models.AutoMapperProfile
{
    public class AssetLibraryProfile:Profile
    {
        public AssetLibraryProfile()
        {
            CreateMap<SystemAsset, SystemAssetVO>();
            CreateMap<TenantAsset, TenantAssetVO>();
            CreateMap<Scene, SceneItemVO>()
                .ForMember(des => des.CreationTime, opt => opt.MapFrom(s => s.CreationInfo.CreationTime))
                .ForMember(des => des.ModificationTime, opt => opt.MapFrom(s => s.ModificationInfo.ModificationTime));

        }
    }
}

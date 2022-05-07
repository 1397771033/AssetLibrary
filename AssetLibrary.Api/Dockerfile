#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY . ./
EXPOSE 80 443 6100

ENV LANG C.UTF-8
RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
MAINTAINER Áì½³½ÌÓý
ENTRYPOINT ["dotnet", "AssetLibrary.API.dll"]
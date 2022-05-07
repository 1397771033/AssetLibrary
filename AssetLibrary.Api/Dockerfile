FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS runtime
WORKDIR /app
COPY . ./
EXPOSE 6001

ENV LANG C.UTF-8
RUN /bin/cp /usr/share/zoneinfo/Asia/Shanghai /etc/localtime && echo 'Asia/Shanghai' >/etc/timezone
MAINTAINER yuanxinyuan
ENTRYPOINT ["dotnet", "AssetLibrary.API.dll"]
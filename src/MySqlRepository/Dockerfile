FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

ENV ASPNETCORE_URLS http://*:6000
EXPOSE 6000/tcp
ENTRYPOINT ["dotnet", "run"]


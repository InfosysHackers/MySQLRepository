FROM microsoft/dotnet:latest
COPY . /app
WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

ENV ASPNETCORE_URLS http://*:8000
EXPOSE 8000/tcp
ENTRYPOINT ["dotnet", "run"]


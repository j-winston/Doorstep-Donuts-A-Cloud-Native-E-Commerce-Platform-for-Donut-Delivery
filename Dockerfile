FROM mcr.microsoft.com/dotnet/aspnet:8.0

COPY /bin/Release/net8.0/publish/ e-commerce/
COPY /wwwroot /app/wwwroot

ENV ASPNETCORE_ENVIRONMENT Production
ENV Logging_Console_FormatterName=Simple

EXPOSE 5000
WORKDIR /e-commerce
ENTRYPOINT ["dotnet", "e-commerce.dll", "--urls=http://0.0.0.0:5000"]

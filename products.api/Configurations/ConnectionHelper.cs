using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

public static class ConnectionHelper
    {
        public static string GetConnectionString(IConfiguration configuration)
        {
            //DOCKER
            var isRunningInDocker = configuration.GetSection("DockerContainer")["isRunningInDockerContainer"] == "True" ? true : false; 
            if(isRunningInDocker) return DockerContainerConnectionString(configuration);

            //LOCAL
            var connectionString = configuration.GetConnectionString("PostgressDefaultConnectionDEV");
            var databaseUrl = System.Environment.GetEnvironmentVariable("DATABASE_URL");
            return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
        }

        private static string DockerContainerConnectionString(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            return connectionString;
        }

        //build the connection string from the environment. i.e. Heroku
        private static string BuildConnectionString(string databaseUrl)
        {
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');
            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode = SslMode.Require,
                TrustServerCertificate = true
            };
            return builder.ToString();
        }       
    }
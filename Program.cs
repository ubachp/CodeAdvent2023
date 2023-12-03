using CodeAdvent2023;
using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;


var configuration = new ConfigurationBuilder()
.AddUserSecrets<Program>()
.Build();

var cookie = configuration.GetSection("Cookie").Value;
Guard.IsNotNullOrWhiteSpace(configuration.GetSection("Cookie").Value, nameof(configuration));
#pragma warning disable CS8601 // Possible null reference assignment.
CodeAdvent.Cookie = cookie;
#pragma warning restore CS8601 // Possible null reference assignment.
await CodeAdvent.Run();

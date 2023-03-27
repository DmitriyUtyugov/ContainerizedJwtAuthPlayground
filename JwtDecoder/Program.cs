using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

IConfiguration cfg = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var keyParam = cfg.GetSection("Vault").Value;

string validStringedJwtToken = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiZXhhbXBsZSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2VtYWlsYWRkcmVzcyI6ImVAeGFtcGxlLmNvbSIsImV4cCI6MTY4MjUwMDE3N30.MtfZPui9kIbou4C3p78vEulyk2zdYxaLXAcbt14Xerg";

var validStrictTypedJwtToken = new JwtSecurityToken(jwtEncodedString: validStringedJwtToken);

foreach(var claim in validStrictTypedJwtToken.Claims)
    Console.WriteLine(claim.Type.ToString() + " : " + claim.Value);


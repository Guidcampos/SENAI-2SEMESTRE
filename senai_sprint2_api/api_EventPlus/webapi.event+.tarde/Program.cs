using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//Adiciona o gerador do Swagger 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Event Plus",
        Description = "API para o projeto event plus - Backend API",
        Contact = new OpenApiContact
        {
            Name = "https://github.com/Guidcampos",
            Url = new Uri("https://github.com/Guidcampos")
        }
    });

    //Configure o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //Usando a autentica��o no swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

//Define os par�metros de valida��o do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //VALIDA��ES DO TOKEN
        //Quem est� solicitando
        ValidateIssuer = true,
        //Quem est� recebendo
        ValidateAudience = true,
        //Define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,
        //Forma de criptografia e ainda valida��o da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("eventplus-chave-autenticacao-webapi")),
        //Tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(30),
        //Nome da issuer, de onde est� vindo
        ValidIssuer = "webapi.eventplus.codefirst",
        //Nome da audience, de onde est� vindo
        ValidAudience = "webapi.eventplus.codefirst"
    };
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender � interface do usu�rio do Swagger na raiz do aplicativo (https://localhost:<port>/), define-se a propriedade RoutePrefix como uma cadeia de caracteres vazia:
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();

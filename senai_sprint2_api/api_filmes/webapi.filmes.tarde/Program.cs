using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();




//adiciona o servico de autenticacao JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";

})
//Define os parametros de validaçao do token
.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //valida quem está solicitando
        ValidateIssuer = true,

        //valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiraçao do token sera validado 
        ValidateLifetime = true,

        //forma de criptografia e ainda validaçao da chave de autenticacao
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //valida o tempo de expiracao do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //de onde está vindo
        ValidIssuer = "webapi.filmes.tarde",

        //para onde está indo
        ValidAudience = "webapi.filmes.tarde",
    };

});







//Adiciona o gerador do Swagger à coleção de serviços no Program.cs
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Tarde",
        Description = "API para Gerenciamento de filmes - Introdução a sprint 2 - BackEndAPI",
        Contact = new OpenApiContact
        {
            Name = "Guilherme",
            Url = new Uri("https://github.com/Guidcampos")
        },
    });
    //Configura o Swagger para usar o arquivo XML gerado com as instruções anteriores
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //usando a autenticacao no swagger
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
            new string [] {}
        }
     });
});




var app = builder.Build();

//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger
//adicionará o middleware do Swagger somente se o ambiente atual estiver definido como Desenvolvimento. A chamada do método UseSwaggerUI habilita o Middleware de arquivos estáticos.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Para atender à interface do usuário do Swagger na raiz do aplicativo (https://localhost:<port>/), define-se a propriedade RoutePrefix como uma cadeia de caracteres vazia:
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//usar autenticacao
app.UseAuthentication();

//usar autorizacao
app.UseAuthorization();


//Mapear os controllers
app.MapControllers();

app.Run();

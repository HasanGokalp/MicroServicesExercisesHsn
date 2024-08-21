using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit((x) =>
{
    var deneme = "amqps://ncdyyphv:Vka8Qhhlw3-IW30Djv9iG0ZvHZN4552z@cow.rmq2.cloudamqp.com/ncdyyphv";
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(deneme, host =>
        {
            host.Username("ncdyyphv");
            host.Password("Vka8Qhhlw3-IW30Djv9iG0ZvHZN4552z");
        });

    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

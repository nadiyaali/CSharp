var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.UseHttpsRedirection();


app.MapGet(pattern: "/person/{id:int}", (int id) =>
{
    return new PersonRecord(id, FirstName: "Nadia", LastName: "Ali");
});


app.MapPost(pattern: "/person", (PersonRecord person) =>
{
    return person;
});

app.Run();

record PersonRecord(int id, string FirstName, string LastName);
using RankingSystem.RankingSystem;
using RankingSystem.RankingSystem.Models;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();

var app = builder.Build();

var db = new DatabaseContext();

var rankingApi = app.MapGroup("/ranking");
rankingApi.MapGet("/", () =>
{
    var scores = db.Scores.AsEnumerable();
    scores = scores.OrderDescending();

    var topFive = scores.Take(5).ToList();
    return new TowerRankingModelWrapper(topFive);
});
rankingApi.MapPost("/post", async (HttpRequest request) =>
{
    var result = await request.ReadFromJsonAsync<TowerRankingModelWrapper>();
    db.Scores.Update(result?.Results.First());
    await db.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
using System.Security.Claims;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Server;

public static class PizzaApiExtensions
{

    public static WebApplication MapPizzaApi(this WebApplication app)
    {

        // Subscribe to notifications
        app.MapPut("/notifications/subscribe", [Authorize] async (
            HttpContext context,
            PizzaStoreContext db,
            NotificationSubscription subscription) => {

                // We're storing at most one subscription per user, so delete old ones.
                // Alternatively, you could let the user register multiple subscriptions from different browsers/devices.
                string? userId = GetUserId(context);
                if (userId is null) return Results.Unauthorized();
                var oldSubscriptions = db.NotificationSubscriptions.Where(e => e.UserId == userId);
                db.NotificationSubscriptions.RemoveRange(oldSubscriptions);

                // Store new subscription
                subscription.UserId = userId;
                db.NotificationSubscriptions.Attach(subscription);

                await db.SaveChangesAsync();
                return Results.Ok(subscription);

            });

        // Specials
        app.MapGet("/specials", async (PizzaStoreContext db) => {

            var specials = await db.Specials.ToListAsync();
            return Results.Ok(specials);

        });

        // Toppings
        app.MapGet("/toppings", async (PizzaStoreContext db) => {
            var toppings = await db.Toppings.OrderBy(t => t.Name).ToListAsync();
            return Results.Ok(toppings);
        });

        return app;

    }

    public static string? GetUserId(HttpContext context) =>
        context.User.FindFirstValue(ClaimTypes.NameIdentifier);

}
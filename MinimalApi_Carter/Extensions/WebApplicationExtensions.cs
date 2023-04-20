namespace MinimalApi_Carter.Extensions;

internal static class WebApplicationExtensions
{
    public static WebApplication Setup(this WebApplication app)
    {
        app.UsePathBase(new PathString("/api"));
        // app.UseRouting();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        
        return app;
    }
}
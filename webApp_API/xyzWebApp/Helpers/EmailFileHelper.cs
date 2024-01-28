namespace xyzWebApp.Helpers;

public static class EmailFileHelper
{
    private const string ResetFileName = "password-request.html";
    private const string ConfirmFileName = "email-confirm.html";
    private const string EmailSuccess = "email-success.html";

    public static async Task<string> GenerateEmailSuccess()
    {
        return await File.ReadAllTextAsync(EmailSuccess);
    }
    
    public static async Task<string> GeneratePasswordResetHtml(string username, string link)
    {
        var content = await File.ReadAllTextAsync(ResetFileName);

        return content
            .Replace("{{USERNAME}}", username)
            .Replace("{{RESET_LINK}}", link)
            .Replace("{{CURRENT_YEAR}}", DateTime.UtcNow.Year.ToString());
    }

    public static async Task<string> GenerateConfirmEmailHtml(string username, string link)
    {
        var content = await File.ReadAllTextAsync(ConfirmFileName);

        return content
            .Replace("{{USERNAME}}", username)
            .Replace("{{LINK}}", link)
            .Replace("{{CURRENT_YEAR}}", DateTime.UtcNow.Year.ToString());
    }
}
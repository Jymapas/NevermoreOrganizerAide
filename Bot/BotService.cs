using NevermoreOrganizerAide.ImageProcessing;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace NevermoreOrganizerAide.Bot;

public class BotService(string token)
{
    private readonly TelegramBotClient _botClient = new(token);
    private readonly ImageService _imageService = new();
    private readonly ReceiverOptions _receiverOptions = new();

    public void Start()
    {
        var cts = new CancellationTokenSource();
        _botClient.StartReceiving(HandleUpdate, HandleError, _receiverOptions, cts.Token);
    }

    private async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        if (update.Message is not { Text: { } text } message)
        {
            return;
        }

        var imageBytes = _imageService.AddTextToImage(text);
        using var stream = new MemoryStream(imageBytes);
        await bot.SendPhoto(
            message.Chat.Id,
            InputFile.FromStream(stream, "result.png"),
            "Вот ваша картинка",
            cancellationToken: ct);
    }

    private Task HandleError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    {
        Console.WriteLine($"Ошибка бота: {ex.Message}");
        return Task.CompletedTask;
    }
}

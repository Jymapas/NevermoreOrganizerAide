using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace NevermoreOrganizerAide.Bot;

public class BotService(string token)
{
    private readonly TelegramBotClient _botClient = new(token);
    private readonly ReceiverOptions _receiverOptions = new();

    public void Start(string token)
    {
        var cts = new CancellationTokenSource();
        _botClient.StartReceiving(HandleUpdate, HandleError, _receiverOptions, cts.Token);
    }

    private Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        Console.WriteLine("Not implemented");
        return Task.CompletedTask;
    }

    private Task HandleError(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    {
        Console.WriteLine($"Ошибка бота: {ex.Message}");
        return Task.CompletedTask;
    }
}

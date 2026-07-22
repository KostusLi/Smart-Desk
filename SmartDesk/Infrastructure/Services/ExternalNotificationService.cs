using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Infrastructure.Services
{
    public class ExternalNotificationService(HttpClient _httpClient) : IExternalNotificationService
    {
        public async Task NotifyRoomCreatingAsync(string roomName, CancellationToken cancellationToken)
        {
            string message = $"Создана комната: {roomName}";
            Message mes = new Message(message);

            await _httpClient.PostAsJsonAsync("https://webhook.site/894f356f-1820-4fd5-a183-2ffc39db9d2b", mes, cancellationToken);
        }
    }

    public record Message(string message);
}

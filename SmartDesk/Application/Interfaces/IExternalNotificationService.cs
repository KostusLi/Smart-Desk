using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IExternalNotificationService
    {
        public Task NotifyRoomCreatingAsync(string roomName, CancellationToken cancellationToken);
    }
}

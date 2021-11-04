using System;
using AngularDynamicDashboard.Api.Models;

namespace AngularDynamicDashboard.Api.Features
{
    public static class StoredEventExtensions
    {
        public static StoredEventDto ToDto(this StoredEvent storedEvent)
        {
            return new ()
            {
                StoredEventId = storedEvent.StoredEventId
            };
        }
        
    }
}

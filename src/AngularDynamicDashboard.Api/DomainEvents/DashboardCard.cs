using AngularDynamicDashboard.Api.Core;
using Newtonsoft.Json.Linq;
using System;

namespace AngularDynamicDashboard.Api.DomainEvents
{
    public class CreateDashboardCard : BaseDomainEvent
    {
        public Guid DashboardCardId { get; private set; } = Guid.NewGuid();
        public string CardType { get; private set; }
        public JObject Settings { get; private set; }

        public CreateDashboardCard(string cardType, JObject settings)
        {
            CardType = cardType;
            Settings = settings;
        }
    }

    public class UpdateDashboardCardSettings : BaseDomainEvent
    {
        public JObject Settings { get; private set; }

        public UpdateDashboardCardSettings(JObject settings)
        {
            Settings = settings;
        }
    }

    public class UpdateDashboardCardType : BaseDomainEvent
    {
        public string CardType { get; private set; }

        public UpdateDashboardCardType(string cardType)
        {
            CardType = cardType;
        }
    }

    public class RemoveDashboardCard : BaseDomainEvent { }
}

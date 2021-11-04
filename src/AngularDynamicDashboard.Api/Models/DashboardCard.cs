using AngularDynamicDashboard.Api.Core;
using AngularDynamicDashboard.Api.DomainEvents;
using Newtonsoft.Json.Linq;
using System;

namespace AngularDynamicDashboard.Api.Models
{
    public class DashboardCard : AggregateRoot
    {
        public Guid DashboardCardId { get; private set; }
        public string CardType { get; private set; }
        public JObject Settings { get; private set; }

        public DashboardCard(CreateDashboardCard @event)
        {
            Apply(@event);
        }

        private DashboardCard()
        {

        }

        protected override void EnsureValidState()
        {

        }

        protected override void When(dynamic @event) => When(@event);

        private void When(CreateDashboardCard @event)
        {
            DashboardCardId = @event.DashboardCardId;
            CardType = @event.CardType;
            Settings = @event.Settings;
        }
        private void When(UpdateDashboardCardType @event)
        {
            CardType = @event.CardType;
        }
        private void When(UpdateDashboardCardSettings @event)
        {
            Settings = @event.Settings;
        }
        private void When(RemoveDashboardCard @event)
        {

        }
    }
}

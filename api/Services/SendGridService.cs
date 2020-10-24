using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api.Configuration;
using api.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace api.Services
{
    public class SendGridService : INotificationService
    {
        private readonly string _apiKey;
        private readonly string _from;
        public SendGridService(ISendGridSettings settings)
        {
            _apiKey = settings.ApiKey;
            _from = settings.From;
        }

        private string ListOrderedDishes(IEnumerable<OrderedDish> orderedDishes)
        {
            var content = new StringBuilder();
            foreach (var orderedDish in orderedDishes)
            {
                content.Append($"{orderedDish.Quantity}x {orderedDish.Name}.");
                if (orderedDish.Extras != null && orderedDish.Extras.Any())
                {
                    content.Append(" Dodatki: ");
                    foreach (var orderedExtras in orderedDish.Extras)
                    {
                        content.Append(orderedExtras.Name).Append(", ");
                    }
                }

                // append new line for the next ordered dish
                content.AppendLine();
            }

            return content.ToString();
        }

        private string GenerateEmailContent(Order order)
        {
            var emailContent = new StringBuilder();
            emailContent.AppendLine("Twoje zamówienie zostało przyjęte.");
            emailContent.Append("Całkowita kwota Twojego zamówienia: ").Append(order.TotalPrice).AppendLine("zł.");
            emailContent.AppendLine("Zamówione produkty:");
            emailContent.AppendLine(ListOrderedDishes(order.Dishes));
            emailContent.Append("Identyfikator zamówienia: ").Append(order.OrderIdentifier);

            return emailContent.ToString();
        }

        public async Task SendNotification(string receiver, Order order)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_from);
            const string subject = "PizzaPack przyjęło Twoje zamówienie!";
            var to = new EmailAddress(receiver);
            var emailContent = GenerateEmailContent(order);

            var msg = MailHelper.CreateSingleEmail(from, to, subject, emailContent, string.Empty);
            await client.SendEmailAsync(msg);
        }

    }
}

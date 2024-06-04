using FanKart.FanKartDbModels;
using FanKart.Services.Interfaces;

namespace FanKart.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly FanKartContext _context;
        public PaymentService(FanKartContext context)
        {
            _context = context;
        }
        public Card AddCard(Card card)
        {
            _context.Cards.Add(card);
            _context.SaveChanges();
            return card;
        }

        public List<Card> GetSavedCards(string emailId)
        {
            return _context.Cards.Where(card => card.EmailId == emailId && card.IsAcive == true).ToList();
        }

        public void RemoveCard(Card card)
        {
            _context.Cards.Remove(card);
            _context.SaveChanges();
        }

        public bool ValidateCard(int cardId, string encryptedSecurityCode)
        {
            return _context.Cards.Where(c => c.Id == cardId && c.IsAcive == true && c.EncryptedSecurityCode == encryptedSecurityCode).Any();
        }
    }
}

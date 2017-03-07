using System.Collections.Generic;
using Pyrotechnics.Models.Database;

namespace Pyrotechnics.Models.DataRepositoryInterfaces
{
    public interface ICardTypeRepository
    {
        IList<CardType> GetCards();
        CardType GetCardDetails(int id);
        void AddCard(CardType card);
        void UpdateCard(CardType card);
        void DeleteCard(int id);
    }
}

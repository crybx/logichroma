using System.Collections.Generic;
using ChromaMatch.Models.Database;

namespace ChromaMatch.Models.DataRepositoryInterfaces
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

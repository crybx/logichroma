using System.Collections.Generic;
using Logichroma.Database;

namespace Logichroma.Areas.Admin.Models.DataRepositoryInterfaces
{
    public interface ICardValuesRepository
    {
        IList<CardType> GetCards();
        CardType GetCardDetails(int id);
        void AddCard(CardType card);
        void UpdateCard(CardType card);
        void DeleteCard(int id);
    }
}

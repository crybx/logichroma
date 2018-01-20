using System.Collections.Generic;
using Logichroma.Database;

namespace Logichroma.Areas.Admin.Models.DataRepositoryInterfaces
{
    public interface ICardValuesRepository
    {
        IList<CardValue> GetCards();
        CardValue GetCardDetails(int id);
        void AddCard(CardValue card);
        void UpdateCard(CardValue card);
        void DeleteCard(int id);
    }
}

using Logichroma.Database;
using Logichroma.Models.DataRepositories;
using Logichroma.Models.DataRepositoryInterfaces;
using System.Net;
using System.Web.Mvc;

namespace Logichroma.Controllers
{
    [Authorize(Roles = "canEditGameAssets")]
    public class CardTypesController : Controller
    {
        private readonly ICardValuesRepository _cardValuesRepo;

        public CardTypesController(ICardValuesRepository cardValuesRepo)
        {
            _cardValuesRepo = cardValuesRepo;
        }

        public CardTypesController() : this(new CardValuesRepository()) {}

        // GET: Cards
        public ActionResult Index()
        {
            var model = _cardValuesRepo.GetCards();
            return View(model);
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cardType = _cardValuesRepo.GetCardDetails(id.Value);

            if (cardType == null)
            {
                return HttpNotFound();
            }

            return View(cardType);
        }

        // GET: Cards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cards/Create
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FaceValue,CountInDeck")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                _cardValuesRepo.AddCard(cardType);
                return RedirectToAction("Index");
            }

            return View(cardType);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var card = _cardValuesRepo.GetCardDetails(id.Value);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Edit/5
        // To protect from over posting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FaceValue,CountInDeck")] CardType cardType)
        {
            if (ModelState.IsValid)
            {
                _cardValuesRepo.UpdateCard(cardType);
                return RedirectToAction("Index");
            }
            return View(cardType);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cardType = _cardValuesRepo.GetCardDetails(id.Value);
            if (cardType == null)
            {
                return HttpNotFound();
            }
            return View(cardType);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cardValuesRepo.DeleteCard(id);
            return RedirectToAction("Index");
        }
    }
}

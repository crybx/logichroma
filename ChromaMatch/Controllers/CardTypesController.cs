using ChromaMatch.Models.Database;
using ChromaMatch.Models.DataRepositories;
using ChromaMatch.Models.DataRepositoryInterfaces;
using System.Net;
using System.Web.Mvc;

namespace ChromaMatch.Controllers
{
    [Authorize(Roles = "canEditGameAssets")]
    public class CardTypesController : Controller
    {
        private readonly ICardTypeRepository _cardTypeRepo;

        public CardTypesController(ICardTypeRepository cardTypeRepo)
        {
            _cardTypeRepo = cardTypeRepo;
        }

        public CardTypesController() : this(new CardTypeRepository()) {}

        // GET: Cards
        public ActionResult Index()
        {
            var model = _cardTypeRepo.GetCards();
            return View(model);
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var cardType = _cardTypeRepo.GetCardDetails(id.Value);

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
                _cardTypeRepo.AddCard(cardType);
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
            var card = _cardTypeRepo.GetCardDetails(id.Value);
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
                _cardTypeRepo.UpdateCard(cardType);
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
            var cardType = _cardTypeRepo.GetCardDetails(id.Value);
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
            _cardTypeRepo.DeleteCard(id);
            return RedirectToAction("Index");
        }
    }
}

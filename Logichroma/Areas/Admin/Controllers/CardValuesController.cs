using Logichroma.Areas.Admin.Models.DataRepositories;
using Logichroma.Areas.Admin.Models.DataRepositoryInterfaces;
using Logichroma.Database;
using System.Net;
using System.Web.Mvc;

namespace Logichroma.Areas.Admin.Controllers
{
    [Authorize(Roles = "canEditGameAssets")]
    public class CardValuesController : Controller
    {
        private readonly ICardValuesRepository _cardValuesRepo;

        public CardValuesController(ICardValuesRepository cardValuesRepo)
        {
            _cardValuesRepo = cardValuesRepo;
        }

        public CardValuesController() : this(new CardValuesRepository()) {}

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

            var cardValue = _cardValuesRepo.GetCardDetails(id.Value);

            if (cardValue == null)
            {
                return HttpNotFound();
            }

            return View(cardValue);
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
        public ActionResult Create([Bind(Include = "Id,FaceValue,CountInDeck")] CardValue cardValue)
        {
            if (ModelState.IsValid)
            {
                _cardValuesRepo.AddCard(cardValue);
                return RedirectToAction("Index");
            }

            return View(cardValue);
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
        public ActionResult Edit([Bind(Include = "Id,FaceValue,CountInDeck")] CardValue cardValue)
        {
            if (ModelState.IsValid)
            {
                _cardValuesRepo.UpdateCard(cardValue);
                return RedirectToAction("Index");
            }
            return View(cardValue);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cardValue = _cardValuesRepo.GetCardDetails(id.Value);
            if (cardValue == null)
            {
                return HttpNotFound();
            }
            return View(cardValue);
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

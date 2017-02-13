﻿using System.Net;
using System.Web;
using System.Web.Mvc;
using Pyrotechnics.Models;
using Pyrotechnics.Models.Database;
using Pyrotechnics.Models.DataRepositories;

namespace Pyrotechnics.Controllers
{
    public class CardsController : Controller
    {
        private readonly CardsRepository _cardRepo = new CardsRepository();

        // GET: Cards
        public ActionResult Index()
        {
            var model = _cardRepo.GetCards();
            return View(model);
        }

        // GET: Cards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var card = _cardRepo.GetCardDetails(id.Value);

            if (card == null)
            {
                return HttpNotFound();
            }

            return View(card);
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
        public ActionResult Create([Bind(Include = "Id,FaceValue,CountInDeck")] Card card)
        {
            if (ModelState.IsValid)
            {
                _cardRepo.CreateCard(card);
                return RedirectToAction("Index");
            }

            return View(card);
        }

        // GET: Cards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var card = _cardRepo.GetCardDetails(id.Value);
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
        public ActionResult Edit([Bind(Include = "Id,FaceValue,CountInDeck")] Card card)
        {
            if (ModelState.IsValid)
            {
                _cardRepo.UpdateCard(card);
                return RedirectToAction("Index");
            }
            return View(card);
        }

        // GET: Cards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var card = _cardRepo.GetCardDetails(id.Value);
            if (card == null)
            {
                return HttpNotFound();
            }
            return View(card);
        }

        // POST: Cards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _cardRepo.DeleteCard(id);
            return RedirectToAction("Index");
        }
    }
}
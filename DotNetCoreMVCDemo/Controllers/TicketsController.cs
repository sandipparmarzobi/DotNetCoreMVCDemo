using DotNetCoreMVCDemo.Data.Repository;
using DotNetCoreMVCDemo.DomainLayer.Entity;
using DotNetCoreMVCDemo.DomainLayer.Interfaces;
using DotNetCoreMVCDemo.InfrastructureLayer.Data;
using DotNetCoreMVCDemo.InfrastructureLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreMVCDemo.Controllers
{
    public class TicketsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TicketRepository _ticketRepository;
        private readonly MovieRepository _movieRepository;

        public TicketsController(IUnitOfWork unitOfWork,TicketRepository ticketRepository, MovieRepository movieRepository)
        {
            _unitOfWork = unitOfWork;
            _ticketRepository = ticketRepository;
            _movieRepository = movieRepository;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            //SP: Include the movice refrence object in ticket list (relationship example)
            return _ticketRepository.GetTicketsIncludeMovie() != null ?
                        View( _ticketRepository.GetTicketsIncludeMovie()) :
                        Problem("Entity set 'DotNetCoreMVCDemoContext.Tickets'  is null.");
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _ticketRepository.GetAll() == null)
            {
                return NotFound();
            }

            var tickets =  _ticketRepository.GetById(id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        // GET: Tickets/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            Tickets ticket = new Tickets();
            var movie = _movieRepository.GetById(id);
            if (movie != null)
            {
                ticket.Movie = movie;
            }
            ViewBag.MovieId = id;
            return View(ticket);
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid? Id,[Bind("CustomerName,ShowDate,Gender,Amount,MovieId")] Tickets tickets)
        {
            if (ModelState.IsValid)
            {
                _ticketRepository.Add(tickets);
                _unitOfWork.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(tickets);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tickets = _ticketRepository.GetById(id);
            if (tickets == null)
            {
                return NotFound();
            }
            return View(tickets);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CustomerName,ShowDate,Gender,Amount,MovieId")] Tickets ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketRepository.UpdateState(ticket);
                    _unitOfWork.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ticketRepository.IsExists(ticket))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _ticketRepository.GetAll() == null)
            {
                return NotFound();
            }

            var tickets = _ticketRepository.GetById(id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        } 

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_ticketRepository.GetAll() == null)
            {
                return Problem("Entity set 'DotNetCoreMVCDemoContext.Tickets'  is null.");
            }
            var ticket = _ticketRepository.GetById(id);
            if (ticket != null)
            {
                _ticketRepository.Remove(ticket);
                _unitOfWork.Commit();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

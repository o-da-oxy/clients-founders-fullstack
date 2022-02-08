using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ClientsApp.Data;
using ClientsApp.Models;
using ClientsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClientsApp.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ClientsContext _context;
        private readonly IMapper _mapper;
        
        public ClientsController(ILogger<ClientsController> logger, ClientsContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var clients = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_context.Clients.ToList());
            return View(clients);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ClientViewModel>(_context.Clients.FirstOrDefault(c => c.Id == id));

            
            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TIN,Name,Type")] CreateClientViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Client>(inputModel));
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _mapper.Map<EditClientViewModel>(_context.Clients.FirstOrDefault(m => m.Id == id));
            
            if (editModel == null)
            {
                return NotFound();
            }

            return View(editModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("TIN,Name,Type,UpdateDate")] EditClientViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var client = _mapper.Map<Client>(editModel);
                    client.Id = id;
                    client.UpdateDate = DateTime.Now;
                    _context.Update(client);
                    _context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    if (!ClientExists(id))
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
            return View(editModel);
        }
        
        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
        
    }
}


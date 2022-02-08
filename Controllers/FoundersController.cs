using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ClientsApp.Data;
using ClientsApp.Models;
using ClientsApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ClientsApp.Controllers
{
    public class FoundersController : Controller
    {
        private readonly ILogger<FoundersController> _logger;
        private readonly ClientsContext _context;
        private readonly IMapper _mapper;
        
        public FoundersController(ILogger<FoundersController> logger, ClientsContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            var founders = _mapper.Map<IEnumerable<Founder>, IEnumerable<FounderViewModel>>(_context.Founders.ToList());
            return View(founders);
        }
        
        [HttpGet]
        public IActionResult GetClient(int? id)
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
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<FounderViewModel>(_context.Founders.FirstOrDefault(f => f.Id == id));

            
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
        public IActionResult Create([Bind("FirstName,LastName,Patronymic,TIN,ClientId")] CreateFounderViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(_mapper.Map<Founder>(inputModel));
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }
    }
}
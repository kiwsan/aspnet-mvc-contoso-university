using System.Web.Mvc;
using Application.Commands.Person.Create;
using MediatR;

namespace ContosoUniversity.Controllers
{
    public class PersonController : Controller
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CreatePersonCommand command)
        {
            if (ModelState.IsValid)
            {
                //Insert data in tables.
                _mediator.Send(command);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
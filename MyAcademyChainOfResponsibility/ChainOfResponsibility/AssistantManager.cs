using MyAcademyChainOfResponsibility.DataAccess.Context;
using MyAcademyChainOfResponsibility.DataAccess.Entities;
using MyAcademyChainOfResponsibility.Models;

namespace MyAcademyChainOfResponsibility.ChainOfResponsibility
{
	public class AssistantManager : Employee
	{
		private readonly CoFContext _context;

		public AssistantManager(CoFContext context)
		{
			_context = context;
		}

		public override void Process(CustomerProcessViewModel request)
		{

			if (request.Price <= 100000)
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Orhan Savas - Mudur Yardimcisi",
					Description = "Para cekme islemi basariyla gerceklesti, Musteriye para odendi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();
			}
			else if (_nextApprover != null)
			{
				var customerProcess = new CustomerProcess
				{
					Name = request.Name,
					Price = request.Price,
					EmployeeName = "Orhan Savas - Mudur Yardimcisi",
					Description = "Para cekme islemi basarisiz oldu, Musteri Mudure yonlendirildi."
				};
				_context.Add(customerProcess);
				_context.SaveChanges();

				_nextApprover.Process(request);
			}
		}
	}
}
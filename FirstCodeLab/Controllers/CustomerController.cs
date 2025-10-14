using FirstCodeLab.DB.DatabaseContext;
using FirstCodeLab.DB.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstCodeLab.Controllers;

[Route("[controller]")]
[ApiController]
public class CustomerController(
  AppDbContext _dbctx
  ) : ControllerBase
{
  [HttpPost("[action]")]
  public IEnumerable<Customer> Search()
  {
    return _dbctx.Customer.Select(c => c);
  }

  [HttpPost("[action]")]
  public Customer Create(Customer customer) 
  {
    using var txn = _dbctx.Database.BeginTransaction();
    _dbctx.Customer.Add(customer);
    _dbctx.SaveChanges();
    txn.Commit();
    return customer;
  }
}

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
    var now = DateTimeOffset.UtcNow;
    using var txn = _dbctx.Database.BeginTransaction();

    // auto fills the status fields.
    customer.CreatedAt = now;
    customer.UpdatedAt = now;

    _dbctx.Customer.Add(customer);
    _dbctx.SaveChanges();
    txn.Commit();
    return customer;
  }


  [HttpPost("[action]")]
  public Customer Update(Customer customer)
  {
    var now = DateTimeOffset.UtcNow;
    using var txn = _dbctx.Database.BeginTransaction();
    var info = _dbctx.Customer.Find(customer.Id) ??
      throw new ApplicationException("Not found!");

    info.Name = customer.Name;
    info.Email = customer.Email;

    // auto fills the status fields.
    info.UpdatedAt = now;

    _dbctx.Customer.Update(info);
    _dbctx.SaveChanges();
    txn.Commit();
    return info;
  }

}

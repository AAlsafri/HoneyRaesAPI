using HoneyRaesAPI.Models;
// using HoneyRaesAPI.Models.DTOs;

List<Customer> customers = new List<Customer> {
    new Customer { Id = 1, Name = "Alice", Address = "123 Oak st" },
    new Customer { Id = 2, Name = "Sarah", Address = "76 Riverside ave" },
    new Customer { Id = 3, Name = "James", Address = "2293 21st Ave NE" }
};
List<Employee> employees = new List<Employee> {
    new Employee { Id = 1, Name = "Chris", Specialty = "HVAC"},
    new Employee { Id = 2, Name = "Donald", Specialty = "Plumbing"}
};
List<ServiceTicket> serviceTickets = new List<ServiceTicket> {
    new ServiceTicket { Id = 1, CustomerId = 1, EmployeeId = 2, Description = "Leaky faucet", Emergency = true, DateCompleted = DateTime.Now},
    new ServiceTicket { Id = 3, CustomerId = 3, Description = "Power outage", Emergency = true },
    new ServiceTicket { Id = 4, CustomerId = 1, EmployeeId = 2, Description = "Toilet clogged", Emergency = true },
    new ServiceTicket { Id = 5, CustomerId = 2, Description = "Broken window", Emergency = false },
    new ServiceTicket { Id = 1, CustomerId = 1, EmployeeId = 1, Description = "AC not working", Emergency = true }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/servicetickets", () => 
{
    return serviceTickets.Select(t => new ServiceTicketDTO
    {
        Id = t.Id,
        CustomerId = t.CustomerId,
        EmployeeId = t.EmployeeId,
        Description = t.Description,
        DateCompleted = t.DateCompleted
    });
});

app.MapGet("/servicetickets/{id}", (int id) =>
{
    ServiceTicket serviceTicket = serviceTickets.FirstOrDefault(st => st.Id == id);
  
    return new ServiceTicketDTO
    {
        Id = serviceTicket.Id,
        CustomerId = serviceTicket.CustomerId,
        EmployeeId = serviceTicket.EmployeeId,
        Description = serviceTicket.Description,
        Emergency = serviceTicket.Emergency,
        DateCompleted = serviceTicket.DateCompleted
    };
});

app.Run();

// class Customer {}
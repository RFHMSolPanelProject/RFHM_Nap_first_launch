using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RHM_Napv02_projekt_server.Models;
using static RHM_Napv02_projekt_server.Models.SqlTable;

namespace RHM_Napv02_projekt_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolController : ControllerBase
    {
    private readonly SolContext _solContext;

    public SolController(SolContext solContext)
    {
        _solContext = solContext;
    }

        #region Customer

        [HttpGet("customers")]
        public async Task<ActionResult<IEnumerable<SqlTable.Customer>>> GetCustomers()
        {
            try
            {
                var customers = await _solContext.Customers.ToListAsync();
                if (customers == null)
                {
                    return NotFound();
                }

                return customers;
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SqlTable.Customer>> GetCustomer(string id)
        {
            var customer = await _solContext.Customers.FindAsync(id);
            
            if (_solContext.Customers == null)
            {
                return NotFound();
            }
            
            if(customer == null)
            {
                return NotFound();
            }


            return customer;
        }

        [HttpPost("customer")]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _solContext.Customers.Add(customer);
            await _solContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomer), new {id = customer.CustomerID}, customer);
        }

        /*
         Ez a kód egy ASP.NET Core kontroller, amely különböző HTTP kérésekre válaszol az ügyfelekkel kapcsolatban. Itt van egy rövid összefoglalás arról, hogy mit csinál a kód:

        GetCustomers() metódus:
            GET kérésre válaszol a "customers" végponton keresztül.
            Lekéri az összes ügyfelet az adatbázisból.
            Ha az ügyfelek listája üres, akkor NotFound (404) választ küld vissza.
            Ha sikerült lekérni az ügyfeleket, akkor azokat visszaküldi.

        GetCustomer(string id) metódus:
            GET kérésre válaszol a "customer" végponton keresztül egy specifikus ügyféllel azonosítva az azonosító alapján.
            Megpróbálja lekérni az ügyfelet az adatbázisból az adott azonosító alapján.
            Ha az ügyfél nem található az adatbázisban, akkor NotFound (404) választ küld vissza.
            Ha az ügyfél megtalálható, akkor azt visszaküldi.

        PostCustomer(Customer customer) metódus:
            POST kérésre válaszol a "customer" végponton keresztül egy új ügyfél létrehozásával.
            Hozzáadja az új ügyfelet az adatbázishoz.
            Elmenti az adatbázisban az új ügyfelet.
            CreatedAtAction (201) választ küld vissza, amely tartalmazza az új ügyfél részleteit, valamint a helyét, ahol az ügyfelet további lekérdezhető.
         */

        #endregion Customer

        [HttpGet("projects")]
            public async Task<ActionResult<IEnumerable<SqlTable.Project>>> GetProjects()
            {
                try
                {
                    var projects = await _solContext.Projects.ToListAsync();

                    if (projects == null)
                    {
                        return NotFound();
                    }

                    return projects;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("projectpackages")]
            public async Task<ActionResult<IEnumerable<SqlTable.ProjectPackage>>> GetProjectPackages()
            {
                try
                {
                    var projectPackages = await _solContext.ProjectPackages.ToListAsync();

                    if (projectPackages == null)
                    {
                        return NotFound();
                    }

                    return projectPackages;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("components")]
            public async Task<ActionResult<IEnumerable<SqlTable.Component>>> GetComponents()
            {
                try
                {
                    var components = await _solContext.Components.ToListAsync();

                    if (components == null)
                    {
                        return NotFound();
                    }

                    return components;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("compartments")]
            public async Task<ActionResult<IEnumerable<SqlTable.Compartment>>> GetCompartments()
            {
                try
                {
                    var compartments = await _solContext.Compartments.ToListAsync();

                    if (compartments == null)
                    {
                        return NotFound();
                    }

                    return compartments;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("processes")]
            public async Task<ActionResult<IEnumerable<SqlTable.Process>>> GetProcesses()
            {
                try
                {
                    var processes = await _solContext.Processes.ToListAsync();

                    if (processes == null)
                    {
                        return NotFound();
                    }

                    return processes;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("coworker")]
            public async Task<ActionResult<IEnumerable<SqlTable.CoworkerMain>>> GetCoworkers()
            {
                try
                {
                    var coworkers = await _solContext.CoworkerMains.ToListAsync();

                    if (coworkers == null)
                    {
                        return NotFound();
                    }

                    return coworkers;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("coworkerdata")]
            public async Task<ActionResult<IEnumerable<SqlTable.CoworkerData>>> GetCoworkerDatas()
            {
                try
                {
                    var coworkerdatas = await _solContext.CoworkerDatas.ToListAsync();
                    if (coworkerdatas == null)
                    {
                        return NotFound();
                    }

                    return coworkerdatas;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("permission")]
            public async Task<ActionResult<IEnumerable<SqlTable.CoworkerPermission>>> GetPermissions()
            {
                try
                {
                    var permissions = await _solContext.CoworkerPermissions.ToListAsync();
                    if (permissions == null)
                    {
                        return NotFound();
                    }

                    return permissions;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }

            [HttpGet("login")]
            public async Task<ActionResult<IEnumerable<SqlTable.CoworkerLogin>>> GetLogins()
            {
                try
                {
                    var logins = await _solContext.CoworkerLogins.ToListAsync();
                    if (logins == null)
                    {
                        return NotFound();
                    }

                    return logins;
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error retrieving data: {ex.Message}");
                }
            }
        }   
}


/*
 IEnumerable egy interfész a .NET Frameworkben, amely egy generikus gyűjteményt 
reprezentál, amelyen végig lehet iterálni. Ez az interfész definiálja a 
GetEnumerator metódust, amely lehetővé teszi a gyűjtemény elemeinek sorrendben való bejárását.

A IEnumerable<T> interfész generikus változata, ahol T a gyűjtemény 
elemének típusát jelöli. Például, ha van egy IEnumerable<int>, az azt jelenti, hogy egy 
int típusú elemeket tartalmazó gyűjteményről van szó, amelyen végig lehet iterálni.

Az IEnumerable interfész gyakran használatos a LINQ (Language Integrated Query)
lekérdezésekben és más függvénykönyvtárakban a .NET világában.
 */
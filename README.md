
# Net Core Sample Code Architecture

Sample Asp Net Core Architecture provides skeleton to start working and build modules on top of your requirement needs. It has been taken care of 

1. API List, CRUD operation with generalization class 
2. Exception
3. Security
4. Content Negotiation

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

Sample ASP.NET Core reference application, demo monolitic application architecture model.

Running the sample

After cloning or downloading the sample you should be able to run it using an In Memory database immediately.

If you wish to use the sample with a persistent database, you will need to run its Entity Framework Core migrations before you will be able to run the app, and update the ConfigureServices method in Startup.cs (see below).

You can also run the samples in Docker (see below).

```
 //services.AddDbContext<PPMContext>(c => c.UseInMemoryDatabase("Catalog"));
 services.AddDbContext<PPMContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PPMDatabase")));
```

Configuring the sample to use SQL Server

Ensure your connection strings in appsettings.json point to a local SQL Server instance.

Open a command prompt in the Web folder and execute the following commands:

Create Database and fire below commond at Package Manager Console with selection of Default Project as "Infrastructure".

-- create migration (from Web folder CLI)

Scaffold-DbContext "Server=xxx.xxx.xx.xx;Database=PPM;user id=ppm;password=Password#456@;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data

Above command will create scaffold database context files under Data folder. 

Introduction 
Content Negotiation

please find code in Startup.js file as per  below. Uncomment below code to support XML Formatter.

```
  //Below is for xml formatter.
  //services.AddMvc()
  //.AddMvcOptions(opt => opt.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
```

To restrict JSON output formatter, please add below code above your controller.

```
 [Produces("application/json")]
``` 
## Exceptions
```
  public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other scoped dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            //todo : handle common error
            //if (exception is ) code = HttpStatusCode.NotFound;
            //else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            //else if (exception is MyException) code = HttpStatusCode.BadRequest;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
```

## Security

To restrict to CORS policy, please update below code in startup.cs.
```
 services.AddCors(o => o.AddPolicy("SiteCorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
	    
``` 
##API - List, CRUD operation

###### Structure

1. WebApplication1 : This project contains Controller, Web Pages (if needed -  in case only API no web pages will be added), Helpers ( Exception middleware, ValidateModel). Controller Method calls to "ApplicationCore" Interfaces and Services.

```
        [Route("")]
        [HttpGet]
        public IActionResult List(int? page, int? itemsPage)
        {

            var projectModel = _projectService.GetProjectList(page ?? 1, itemsPage);
            return Ok(projectModel);
        }
```
2. Tools -> Helper : This project contains common extension that can be commonly used to other projects in solution.
3. ApplicationCore :

```
public ProjectResponse GetProjectList(int pageIndex, int? pageSize)
        {

            var filterSpecification = new ProjectwithDetailSpecification(statusId: (int)Enums.Status.Active);
            
            var root = _itemRepository.List(filterSpecification);

            var totalItems = root.Count();

            var itemsOnPage = root.Skip(pageSize ?? 0 * pageIndex).TakeIfNotNull(pageSize).OrderBy(x => x.Name).ToList();

            var vm = new ProjectResponse()
            {
                ProjectList = itemsOnPage.Select(i => new project()
                {
                   ProjectId = i.ProjectId,
                   Name = i.Name,
                   ProposalId= i.ProposalId,
                   Code = i.Code,
                  CustomerId = i.CustomerId,
                  Description = i.Description,
                  ModelId = i.ModelId,
                  StartDate = i.StartDate != null ? i.StartDate.Value.ToString("yyyy/MM/dd"):DateTime.Now.ToString("yyyy/MM/dd"),
                  State = i.State,
                  EndDate = i.EndDate != null ? i.EndDate.Value.ToString("yyyy/MM/dd"): DateTime.Now.ToString("yyyy/MM/dd"),
                  Status = i.Status,
                  CreatedByUserId = i.CreatedByUserId,
                  CreatedDateTime = i.CreatedDateTime,
                  LastModifiedByUserId = i.LastModifiedByUserId,
                  LastModifiedDateTime = i.LastModifiedDateTime,
                  TechnologyId = i.TechnologyId,
                  CustomerName = i.Customer != null ? i.Customer.Name:"n/a",
                    ModelName = i.Model != null ? i.Model.Name : "n/a",
                  Technology = i.Technology != null ? i.Technology.Name : "n/a",
                  PrimaryReposting = "",
                  SecondaryReporting = ""
                }),
                PaginationInfo = new Entities.Entities.Project.PaginationInfoModel()
                {
                    CurrentPage = pageIndex,
                    ItemsPerPage = itemsOnPage.Count,
                    TotalItems = totalItems,
                    TotalPages = int.Parse(Math.Ceiling(((decimal)totalItems / pageSize ?? 1)).ToString())
                }
            };
            return vm;
            
        }
```

ApplicatioCore.Specification : Contains common defination of what to include i.e. below case need to include customer, technology and model when returning project object.

```
 public class ProjectwithDetailSpecification : BaseSpecification<Project>
    {
        public ProjectwithDetailSpecification(int statusId)
            : base(b => b.Status == statusId)
        {
            AddInclude(b => b.Customer);
            AddInclude(b => b.Technology);
            AddInclude(b => b.Model);
        }

    }
```
4. ApplicationCore.Entities contains Model.
 
5. Infrastructure contains

Data : Contains DataContext.
Services : Contains Common Services.

6. Infrastructure.DataAccess.SqlServer

```
 var root = _itemRepository.List(filterSpecification);
```
Above is common line to fetch list.
Repository : 

EFRepository - Common implementation for List and CRUD operations.

```
namespace Infrastructure.DataAccess.SqlServer.Repository
{
    public class EfRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly PPMContext _dbContext;

        public EfRepository(PPMContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(long id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public virtual T GetId(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll()
        {
            return _dbContext.Set<T>().AsNoTracking().AsEnumerable();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
           // fetch a Queryable that includes all expression - based includes
             var queryableResultWithIncludes = spec.Includes
                 .Aggregate(_dbContext.Set<T>().AsQueryable(),
                     (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));


            // return the result of the query using the specification's criteria expression
            return secondaryResult
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }
        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        
    }
```
## Authors

* **Hiral Patel** (https://github.com/mehiralpatel)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details


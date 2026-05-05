
using Xunit;
using Moq;
using IMS.Services;
using IMS.Models;
using IMS.Data;
using Microsoft.EntityFrameworkCore;

namespace IMS.IMS.Tests
{
    public class IncidentServiceTests
    {
       /* private AppDbContext GetDb()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            return new AppDbContext(options);
        }

        [Fact]
        public async Task Close_Should_Fail_If_RCA_Missing()
        {
            // Arrange
            var db = GetDb();
            var mongo = new Mock<MongoService>(null);

            var service = new IncidentService(mongo.Object, db);

            var work = new WorkItem { ComponentId = "TEST" };
            db.WorkItems.Add(work);
            await db.SaveChangesAsync();

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.Close(work.Id));
        }*/
    }
}

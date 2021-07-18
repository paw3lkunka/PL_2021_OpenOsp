using Microsoft.EntityFrameworkCore;

namespace OpenOsp.Data.Configurations {
  internal interface IEntityConfiguration {
    void AddConfiguration(ModelBuilder builder);

    void SeedData(ModelBuilder builder);
  }
}
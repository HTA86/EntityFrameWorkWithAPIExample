using Data.Contexts;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

        // OBS!
        // Ändra sökvägen till den lokala databasen så den matchar sökvägen på din dator.
        //optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\HBGROCA\\Desktop\\Sideprojects\\Data\\Data\\DataBaseLocal.mdf;Integrated Security=True;Connect Timeout=30");
        optionsBuilder.UseSqlServer("Server=11.0.0.21;Database=demo;User Id=sa;Password=B2MTDZVUO1GTD1VSo1CDZVUO1VakedSO;TrustServerCertificate=True;");

        return new DataContext(optionsBuilder.Options);
    }
}
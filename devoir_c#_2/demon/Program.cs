using GesStud.Repository.Impl;
using GesStud.Services.Impl;
using GesStud.View;

class Program
{
    static void Main()
    {
        var etudiantRepo = new EtudiantRepository();
        var etudiantService = new EtudiantService(etudiantRepo);
        var consoleView = new ConsoleView(etudiantService);

        consoleView.AfficherMenu();
    }
}

namespace Konsoli.Options.TechnicalSupport;

internal class TechnicalSupportController : Controller
{
    public override Controller HandleInput(string? input)
    {
        if (input is "1")
        {
            return new HydrometerInstallationController();
        }

        throw new InvalidOperationException("Invalid/unsupported input!");
    }
    public override string PromptOptions()
    {
        return """
            Sobre qual problema técnico deseja tratar?
            1- Instalação de hidrômetro
            """;
    }
    public override bool ValidateOption(string? input, out string? error)
    {
        error = null;
        if (input is not "1") 
        {
            error = "Por favor, forneça uma opção!";
            return false;
        }
        return true;
    }
}

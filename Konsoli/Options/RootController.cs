using Konsoli.Options.TechnicalSupport;

namespace Konsoli.Options;

internal class RootController : Controller
{
    public static string Presentation()
    {
        return "Bem-vindo ao Chatbot da Saneago";
    }
    public override Controller HandleInput(string? input)
    {
        if (input is "2") return new TechnicalSupportController();
        throw new NotImplementedException();
    }
    public override string PromptOptions()
    {
        return """
            "Selecione uma das opções abaixo:"
            1- Suporte Financeiro
            2- Suporte Técnico
            """;
    }
    public override bool ValidateOption(string? input, out string? error)
    {
        error = null;
        if (input is not "1" or "2")
        {
            error = "Selecione uma das opções fornecidas!";
            return false;
        }
        return true;
    }
}

namespace Konsoli.Options;

internal class RootController : Controller
{
    public string Presentation()
    {
        return "Bem-vindo ao Chatbot da Saneago";
    }
    public override Controller HandleInput(string input)
    {
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
    public override bool ValidateOption(string input, out string? error)
    {
        throw new NotImplementedException();
    }
}

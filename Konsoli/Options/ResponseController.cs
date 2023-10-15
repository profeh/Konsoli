using System.Diagnostics;
namespace Konsoli.Options;

internal class ResponseController : Controller
{
    private readonly string _responseMessage;
    public ResponseController(string responseMessage)
    {
        _responseMessage = responseMessage;
    }

    public override Controller HandleInput(string? input)
    {
        switch (input)
        {
            case "1": return new RootController();
            case "2": Environment.Exit(0); break;
            default: throw new InvalidOperationException("the input text was invalid");
        }

        throw new UnreachableException();
    }
    public override string PromptOptions()
    {
        return _responseMessage + $"""
            {'\n'} Escolha uma das opções a seguir para continuar
            1- Voltar ao inicio
            2- Finalizar atendimento
            """;
    }
    public override bool ValidateOption(string? input, out string? error)
    {
        if (input is "1" or "2")
        {
            error = null;
            return true;
        }
        else
        {
            error = "Opção Invalida! Por favor, selecione uma das opções entre 1 e 2";
            return false;
        }
    }
}

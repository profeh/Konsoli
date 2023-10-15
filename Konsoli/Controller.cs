namespace Konsoli;

abstract class Controller
{
    public abstract Controller HandleInput(string? input);
    public abstract string PromptOptions();
    public abstract bool ValidateOption(string? input, out string? error);
}
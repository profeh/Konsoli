using System.Diagnostics;

namespace Konsoli.Options.TechnicalSupport;

internal class HydrometerInstallationController : Controller
{
    enum State
    {
        GetDate,
        GetZipCode,
        GetAddress
    }
    private State _state;
    private string? _zipCode;
    private string? _address;
    private DateOnly? _date;
    
    public override Controller HandleInput(string? input)
    {
        if (input is null) throw new InvalidOperationException("Input cannot be null!");
        if (string.IsNullOrWhiteSpace(input)) throw new InvalidOperationException("The input was null, empty or a whitespace");

        switch (_state)
        {
            case State.GetDate:
                if (DateOnly.TryParse(input, out DateOnly result) is false) throw new InvalidDataException("Invalid date format!");
                _date = result;
                _state = State.GetZipCode;
            return this;
            
            case State.GetZipCode:
                if (input.Length is not 8) throw new InvalidOperationException("Input size for CEP cannot be different from 9 caracthers");
                if (input.All(char.IsDigit) is false) throw new InvalidOperationException("Invalid CEP format");
                _zipCode = input;
                _state = State.GetAddress;
            return this;
                            
            case State.GetAddress:
                _address = input;
            return new ResponseController($"Instalação agendada na data {_date} no endereço {_address} no cep {_zipCode} foi programada com sucesso");

            default: throw new UnreachableException();
        }
    }
    public override string PromptOptions()
    {
        return _state switch
        {
            State.GetZipCode => "Digite o cep desejado para agendamento",
            State.GetDate => "Digite a data de agendamento",
            State.GetAddress => "Digite o endereço de instalação",
            _ => throw new UnreachableException()
        };
    }
    public override bool ValidateOption(string? input, out string? error)
    {
        error = null;
        switch (_state)
        {
            case State.GetDate:
                if (DateOnly.TryParse(input, out DateOnly result) is false || result == default)
                {
                    error = "O formato da data fornecida é desconhecido! Por favor, utilize \"dd/mm/yyyy\"";
                    return false;
                }
            return true;
            case State.GetZipCode:
                if (input is not string { Length: 8 })
                {
                    error = "Por favor, forneça o cep valido do local de instalação";
                    return false;
                }
            return true;
            case State.GetAddress:
                if (input is null)
                {
                    error = "Por favor, forneça um endereço de instalação";
                    return false;
                }
            return true;
            default: return false;
        }
    }
}

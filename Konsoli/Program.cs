using Konsoli;
using Konsoli.Options;

Controller controller = new RootController();

Console.WriteLine(RootController.Presentation());

while (true)
{
    Console.WriteLine(controller.PromptOptions());
    var input = Console.ReadLine();
    if (controller.ValidateOption(input, out var error) is false)
    {
        Console.WriteLine(error);
        continue;
    };
    controller = controller.HandleInput(input);
}
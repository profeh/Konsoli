using Konsoli;
using Konsoli.Options;

Controller controller = new RootController();

Console.WriteLine(((RootController)controller).Presentation());

while (true)
{
    Console.WriteLine(controller.PromptOptions());
    var input = Console.ReadLine();
    controller = controller.HandleInput(input);
}
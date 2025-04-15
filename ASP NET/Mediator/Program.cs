
var textBox = new TextBox();
var checkBox = new CheckBox();
var button = new Button();

var mediator = new DialogMediator
{
    Button = button,
    CheckBox = checkBox,
    TextBox = textBox
};

textBox.SetMediator(mediator);
checkBox.SetMediator(mediator);
button.SetMediator(mediator);

public interface IMediator
{

    void Notify(object sender, string @event);

}


public abstract class Component
{

    protected IMediator _mediator;

    public void SetMediator(IMediator mediator) => _mediator = mediator;
        

}


public class TextBox: Component
{
    public string Text { get; private set; } = string.Empty;

    public void Input(string value)
    {
        Text = value;
        Console.WriteLine(value);
        _mediator.Notify(this, Text);
    }
}


public class CheckBox : Component
{
    public bool IsChecked { get; private set; } = false;

    public void Toggle()
    {
        IsChecked = !IsChecked;
        Console.WriteLine(IsChecked);
        _mediator.Notify(this, "CheckedChange");
    }
}


public class Button : Component
{
    public bool IsEnabled { get; set; } = true;

    public void Click()
    {

        if (IsEnabled) 
        {
            Console.WriteLine("Enabled");
        }
        else
        {
            Console.WriteLine("Not enabled");
        }

        _mediator.Notify(this, "Clicked");
    }
}


public class DialogMediator : IMediator
{

    public TextBox TextBox { get; set; }
    public CheckBox CheckBox { get; set; }

    public Button Button { get; set; }

    public void Notify(object sender, string @event)
    {
        if (@event == "TextChange" || @event == "CheckedChange") 
        { 
            var enableButton = !string.IsNullOrEmpty(TextBox.Text) && CheckBox.IsChecked;
            Button.IsEnabled = enableButton;
            Console.WriteLine("Botão Habilitado");
        }

    }
}
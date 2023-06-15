namespace crud_cqrs_pattern.Commands;

public class CreateClienteCommand
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

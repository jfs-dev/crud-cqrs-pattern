namespace crud_cqrs_pattern.Commands;

public class UpdateClienteCommand
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

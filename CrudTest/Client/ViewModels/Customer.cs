namespace Client.ViewModels;

public class CustomerCreateInput
{
    public string Name { get; set; }

    public string Family { get; set; }

    public DateTime BirthDate { get; set; }

    public ulong MobileNumber { get; set; }

    public uint CountryCode { get; set; }

    public string Email { get; set; }

    public string BankAccounNumber { get; set; }
}

public class CustomerUpdateInput
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Family { get; set; }

    public DateTime BirthDate { get; set; }

    public ulong MobileNumber { get; set; }

    public uint CountryCode { get; set; }

    public string Email { get; set; }

    public string BankAccounNumber { get; set; }
}
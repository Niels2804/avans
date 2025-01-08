public class PhonebookEntry {
    public string name {get;}
    public string firstName {get;}
    public string lastName {get;}
    public string phoneNumber {get;}
    public PhonebookEntry(
        string firstName,
        string lastName,
        string phoneNumber
    ) {
        this.name = firstName + " " + lastName;
        this.firstName = firstName;
        this.lastName = lastName;
        this.phoneNumber = phoneNumber;
    }
}
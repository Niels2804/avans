using System.ComponentModel;

public class PhoneBook {
    private List<PhonebookEntry> Entries = new List<PhonebookEntry>();
    
    // Search for phoneNumber by name
    public string PhoneNumber(string name) {
        string phoneNumber;
        foreach(PhonebookEntry entry in this.Entries) {
            if(entry.name == name) {
                phoneNumber = entry.phoneNumber;
            }
        }
    }
    
    // Add new contact to the PhonebookEntry
    public void Add(
        string firstName,
        string lastName,
        string phoneNumber
    ) {
        PhonebookEntry entry = new PhonebookEntry(firstName, lastName, phoneNumber);
        Entries.Add(entry);
    }
}
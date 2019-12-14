namespace A10
{
    public class Node
    {
        public Contact Contact { get; set; }
        public string Word { get; set; }
        public Node Next { get; set; }
        public Node(string name, int phoneNumber)
        {
            Contact = new Contact(name, phoneNumber);
        }

        public Node(string word)
        {
            Word = word;
        }
    }
}
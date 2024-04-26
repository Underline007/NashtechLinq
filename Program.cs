namespace NashtechLinqDay2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int userChoice;
            List<Member> members = new List<Member>();
            members.Add(new Member("John", "Doe", "Male", new DateTime(1989, 5, 15), "123-456-7890", "Ha Noi", true));
            members.Add(new Member("Jane", "Smith", "Female", new DateTime(2000, 8, 25), "987-654-3210", "Ha Noi", false));
            members.Add(new Member("Alex", "Doe", "Male", new DateTime(1979, 5, 15), "123-456-7890", "New York", true));
            members.Add(new Member("Peter", "Smith", "Female", new DateTime(2001, 8, 25), "987-654-3210", "Los Angeles", false));
            members.Add(new Member("Fake", "Doe", "Male", new DateTime(1979, 3, 15), "123-456-7890", "New York", true));
            members.Add(new Member("David", "Smith", "Female", new DateTime(2001, 8, 25), "987-654-3210", "Los Angeles", false));
            //UI
            DisplayMenu();
            try
            {
                do
                {
                    Console.Write("\nYour choice: ");
                    while (!int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                        Console.Write("Your choice: ");
                    }
                    switch (userChoice)
                    {
                        case 1:
                            DisplayMaleMembers();
                            break;
                        case 2:
                            OldestMember();
                            break;
                        case 3:
                            ShowListMemberWithFullName();
                            break;
                        case 4:
                            ShowThreeListAfterBeforeAndEqual2000();
                            break;
                        case 5:
                            DisplayFirstMemberBornInHaNoi();
                            break;
                        case 6:
                            Console.Clear();
                            break;
                        case 7:
                            Console.WriteLine("\nSee You Again! ");
                            break;
                        default:
                            Console.WriteLine("\nWrong choice");
                            break;
                    }
                }
                while (userChoice != 7);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            //Display Menu
            void DisplayMenu()
            {
                Console.WriteLine("1. Return members who are Male");
                Console.WriteLine("2. Return oldest member");
                Console.WriteLine("3. Return list containing Fullname");
                Console.WriteLine("4. Return 3 lists (Born In 2000, Born After 2000 and Born before 2000)");
                Console.WriteLine("5. Return the first person who was born in Ha Noi");
                Console.WriteLine("6. Clean Screen");
                Console.WriteLine("7. Exit");
            }
            //Male Members
            void DisplayMaleMembers()
            {
                Console.WriteLine("Members who are Male: ");
                foreach (Member member in members.Where(m => m.Gender == "Male"))
                {
                    member.DisplayMember();
                    Console.WriteLine();
                }
            }
            // Oldest Member
            void OldestMember()
            {
                var ShowOldestMember = members.OrderByDescending(m => m.Age).ThenBy(m => m.DateOfBirth).FirstOrDefault();
                if (ShowOldestMember != null)
                {
                    ShowOldestMember.DisplayMember();
                }
                else
                {
                    Console.WriteLine("No members found.");
                }
            }
            // List Member With Full Name
            void ShowListMemberWithFullName()
            {  
                // Member with FullName
                foreach (Member member in members)
                {
                    member.DisplayMemberWithFullName();
                }
            }
            // 3 List (<2000, 2000 and >2000)
            void ShowThreeListAfterBeforeAndEqual2000()
            {
                foreach (Member member in members.Where(m => m.DateOfBirth.Year == 2000))
                {
                    member.DisplayMember();
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("List member born after 2000:");
                foreach (Member member in members.Where(m => m.DateOfBirth.Year > 2000))
                {
                    member.DisplayMember();
                    Console.WriteLine();
                }
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("List member born before 2000:");
                foreach (Member member in members.Where(m => m.DateOfBirth.Year < 2000))
                {
                    member.DisplayMember();
                    Console.WriteLine();
                }
            }
            //First Member Was Born In Ha Noi
            void DisplayFirstMemberBornInHaNoi()
            {
                var firstMemberBornInHaNoi = members.FirstOrDefault(m => m.Birthplace == "Ha Noi");
                Console.WriteLine(firstMemberBornInHaNoi != null ? "First member born in Ha Noi: " : "Not found member born in Ha Noi");
                firstMemberBornInHaNoi?.DisplayMember();
            }
        }
    }
}

namespace WorkingProject {
    public static class ParkingLot {
        private readonly static Dictionary<int, string> roles = 
            new Dictionary<int, string>() {
                {1, "docent"},
                {2, "researcher"}
            };
        public static void Main() {
            int role = 1;
            bool accessPass = true;

            Console.WriteLine(
                (roles.ContainsKey(role) && accessPass) ? 
                    $"Medewerker \"{roles[role]}\" heeft toegang tot parkeerplaats" :
                    "parkeer maar ergens anders"
            );
        }
    }
}






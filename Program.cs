namespace AdventOfCode2021 {
    interface IDay {
        void getResults();
    }
    class Program {
        static void Main(string[] args) {
            var day01 = new Day01();
            day01.getResults();
        }    
    }
}
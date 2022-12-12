using AdventOfCode.Core;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Y2021.Solutions {
    public class Fish {
        private int timer;

        public void newDay() {
            timer  = (timer == 0) ? 6 : (timer-1);
        }

        public Fish(int timer) {
            this.timer = timer;
        }
        public int getTimer() {
            return timer;
        }
    }
    class Day06 {
        private static List<Fish> createFishGroup (int[] puzzleInput) {
            List<Fish> theFish = new List<Fish>();

            foreach(int fish in puzzleInput) {
                theFish.Add(new Fish(fish));
            }
            return theFish;
        }
        private static List<Fish> newDay(List<Fish> theFish) {
            List<Fish> moreFish = new List<Fish>(theFish);
            foreach(Fish fisch in theFish) {
                if (fisch.getTimer() == 0) {
                    moreFish.Add(new Fish(8));
                }
                fisch.newDay();
            }
            return moreFish;
        }
        private static int fastForwardTime (int days, List<Fish> theFish) {
            
            for (int i = 0; i < days; i++) {
                theFish = newDay(theFish);
            }

            return theFish.Count;
        }

        private static Dictionary<int, long> plusOneDay(Dictionary<int, long> storage) {
            long sean = storage[0];

            storage[0] = storage[1];
            storage[1] = storage[2];
            storage[2] = storage[3];
            storage[3] = storage[4];
            storage[4] = storage[5];
            storage[5] = storage[6];
            storage[6] = storage[7] + sean; 
            storage[7] = storage[8];
            storage[8] = sean;
            
            return storage;
        }
        private static long getPart2(int[] puzzleInput, int days) {

            Dictionary<int, long> storage = new Dictionary<int, long>();
            storage.Add(0, (puzzleInput.Where(x => x==0).Count()));
            storage.Add(1, (puzzleInput.Where(x => x==1).Count()));
            storage.Add(2, (puzzleInput.Where(x => x==2).Count()));
            storage.Add(3, (puzzleInput.Where(x => x==3).Count()));
            storage.Add(4, (puzzleInput.Where(x => x==4).Count()));
            storage.Add(5, (puzzleInput.Where(x => x==5).Count()));
            storage.Add(6, (puzzleInput.Where(x => x==6).Count()));
            storage.Add(7, (puzzleInput.Where(x => x==7).Count()));
            storage.Add(8, (puzzleInput.Where(x => x==8).Count()));

            for (int i = 0; i < days; i++) {
                storage = plusOneDay(storage);
            }     

            long sean = 0;
            for (int i = 0; i < storage.Count; i++) {
                sean += storage[i];
            }       
            return sean;
        }
        
        public static void getDay06Results() {
            var input = Utils.sliceLineToIntegerArray("./puzzleInputs/day06.txt");
            List<Fish> theFish = createFishGroup(input);

            Console.WriteLine("~~~~~~~~~~~~~ Day 6 ~~~~~~~~~~~~~");
            //Console.WriteLine("Part 1: " + fastForwardTime(80, theFish));
            Console.WriteLine("Part 2: " + getPart2(input, 256));

        }
    }
}

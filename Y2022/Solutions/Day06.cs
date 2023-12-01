using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Core;

namespace AdventOfCode.Y2022.Solutions {
    public class Day06 : Day {

        private int getMarkerPosition(string datastream, int markerSize) {

            for (int i = 0; i < datastream.Length - markerSize; i++) {
                var possibleMarker = new List<char>(datastream.Substring(i, markerSize));   // store characters for validation into a char array 
                if (possibleMarker.Distinct().Count() == possibleMarker.Count()) return i + markerSize;  // check if characters in the list are unique
            }
            
            return datastream.Length;   // safety net
        }

        protected override int GetPartOne(dynamic key) => getMarkerPosition(key, 4);

        protected override int GetPartTwo(dynamic key) => getMarkerPosition(key, 14);

        public Day06() {
            day = 6;
            year = 2022;
            title = "Tuning Trouble";
        }
    }
}

using System;
using System.Collections.Generic;

namespace AdventOfCode.Y2021.Solutions {
    class Day03 {
        private static int getMoreCommonBit(List<string[]> input, int index, bool inverted = false) {
            int beat = 0;
            foreach(string[] entry in input) {
                beat += (int.Parse(entry[0][index].ToString()) > 0) ? 1 : 0;
            }
            if (inverted) {
                return (beat >= (input.Count - beat)) ? 0 : 1;
            } else {
                return (beat >= (input.Count - beat)) ? 1 : 0;
            }
        }
        public static String getGammaRate(List<string[]> input) {
            String gammaRate = "";
            for (int i = 0; i < input[0][0].Length; i++) {
                gammaRate += getMoreCommonBit(input, i);
            }
            return gammaRate;
        }
        public static String getepsilonRate(List<string[]> input) {
            String gammaRate = "";
            for (int i = 0; i < input[0][0].Length; i++) {
                gammaRate += getMoreCommonBit(input, i, true);
            }
            return gammaRate;
        }
        public static int getPowerConsumption(String gammaRate, String epsilonRate){
            return(Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2));
        }   
        private static List<string[]> filterOut(List<string[]> input, int index, bool inverted = false) {
            List<string[]> filteredList = new List<string[]>();
            int beat = getMoreCommonBit(input, index, inverted);

            foreach(String[] entry in input) {
                if(int.Parse(entry[0][index].ToString()) == beat) {
                    filteredList.Add(entry);
                }
            }
            if(filteredList.Count > 1) {
                return (filterOut(filteredList, index + 1, inverted));
            } else {
                return filteredList;
            }       
        }
        public static int getOxygenGneratorRating(List<string[]> input) {
            return (Convert.ToInt32(filterOut(input, 0)[0][0], 2));
        }
        public static int getCO2ScrubberRating(List<string[]> input) {
            return (Convert.ToInt32(filterOut(input, 0, true)[0][0], 2));
        }
        public static int getLifeSupportRating(List<string[]> input) {
            return getOxygenGneratorRating(input) * getCO2ScrubberRating(input);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BeautifulPairsProblem
{
    // todo unfinished
    internal static class Program
    {
        internal static void Main()
        {
            int[] array1;
            int[] array2;
            int maxBeautifulPairs;

            //array1 = new[] {10, 11, 12, 5, 14};
            //array2 = new[] {8, 9, 11, 11, 5};
            //List<Pair> beautifulPairList =  GetBeautifulPairs(array1, array2);

            //----------------------------------------------------------------

            array1 = new[] { 1, 2, 3, 4 };
            array2 = new[] { 1, 2, 3, 3 };
            maxBeautifulPairs = BeautifulPairs(array1, array2);                 // 4
            Console.WriteLine($"maxBeautifulPairs = {maxBeautifulPairs}");

            array1 = new[] { 3, 5, 7, 11, 5, 8 };
            array2 = new[] { 5, 7, 11, 10, 5, 8 };
            maxBeautifulPairs = BeautifulPairs(array1, array2);                 // 6
            Console.WriteLine($"maxBeautifulPairs = {maxBeautifulPairs}");

            array1 = CreateTestInput1();
            array2 = CreateTestInput2();
            maxBeautifulPairs = BeautifulPairs(array1, array2);                 // 228
            Console.WriteLine($"maxBeautifulPairs = {maxBeautifulPairs}");
        }

        private class Pair
        {
            public int Left;
            public int Right;
        }

        private static int BeautifulPairs(int[] array1, int[] array2)
        {
            int len1 = array1.Length;
            int len2 = array2.Length;

            if (len1 != len2)
            {
                throw new ArgumentException("array1 and array2 must have the same length");
            }

            int[] newArray2 = MaximizeBeautyOfSecondArray(array1, array2);
            List<Pair> beautifulPairList = GetBeautifulPairs(array1, newArray2);
            //beautifulPairList = GetPairwiseDisjointPairs(beautifulPairList);

            return beautifulPairList.Count;
        }

        private static int[] MaximizeBeautyOfSecondArray(int[] array1, int[] array2)
        {
            int len = array2.Length;
            Dictionary<int, int> occurancesDictionary = GetOccurances(array2);
            GetMaxOccurrance(occurancesDictionary, out int maxKey, out int maxOccurances);
            int newElement = 0;

            for (int n = 0; n < len; n++)
            {
                newElement = array1[n];

                // the new element belongs to array1 and does not belong to array2
                if (!array2.Contains(newElement))
                {
                    break;
                }
            }

            // replace duplicate element with new element
            for (int n = 0; n < len; n++)
            {
                if (array2[n] == maxKey)
                {
                    array2[n] = newElement;
                    break;
                }
            }

            return array2;
        }

        private static Dictionary<int, int> GetOccurances(int[] array)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            foreach (int element in array)
            {
                if (!dictionary.ContainsKey(element))
                {
                    dictionary[element] = 1;
                }
                else
                {
                    dictionary[element]++;
                }
            }

            return dictionary;
        }

        private static void GetMaxOccurrance(Dictionary<int, int> dictionary, out int maxKeyOut, out int maxOcccuranceOut)
        {
            int maxOccurance = 0;
            int maxKey = 0;

            foreach (KeyValuePair<int, int> kvp in dictionary)
            {
                int key = kvp.Key;
                int occurance = kvp.Value;

                if (occurance > maxOccurance)
                {
                    maxOccurance = occurance;
                    maxKey = key;
                }
            }

            maxKeyOut = maxKey;
            maxOcccuranceOut = maxOccurance;
        }

        private static List<Pair> GetBeautifulPairs(int[] array1, int[] array2)
        {
            List<Pair> beautifulPairList = new List<Pair>();
            int len = array1.Length;

            for (int n1 = 0; n1 < len; n1++)
            {
                for (int n2 = 0; n2 < len; n2++)
                {
                    bool isBeautiful = array1[n1] == array2[n2];

                    if (isBeautiful)
                    {
                        Pair beautifulPair = new Pair
                        {
                            Left = n1, 
                            Right = n2
                        };

                        beautifulPairList.Add(beautifulPair);
                    }
                }
            }

            return beautifulPairList;
        }

        private static List<Pair> GetPairwiseDisjointPairs(List<Pair> pairList)
        {
            List<Pair> disjointPairList = new List<Pair>();

            foreach (Pair pair in pairList)
            {
                GetLeftRightOccurances(pairList, pair, out int leftOccurances, out int rightOccurances);

                if (leftOccurances == 1 && rightOccurances == 1)
                {
                    disjointPairList.Add(pair);
                }
            }

            return disjointPairList;
        }

        private static void GetLeftRightOccurances(List<Pair> pairList, Pair selectedPair, out int leftOccurances, out int rightOccurances)
        {
            leftOccurances = 0;
            rightOccurances = 0;

            int selectedLeft = selectedPair.Left;
            int selectedRight = selectedPair.Right;

            foreach (Pair pair in pairList)
            {
                int left = pair.Left;
                int right = pair.Right;

                if (left == selectedLeft)
                {
                    leftOccurances++;
                }

                if (right == selectedRight)
                {
                    rightOccurances++;
                }
            }
        }

        private static int[] CreateTestInput1()
        {
            int[] array =
            {
                140, 978, 829, 564, 379, 418, 543, 516, 910, 109, 185, 562, 801, 214, 532, 228, 66, 19, 713, 78, 405, 
                540, 254, 198, 540, 102, 545, 444, 324, 377, 464, 362, 158, 794, 515, 9, 641, 963, 580, 426, 170, 878, 
                312, 643, 553, 48, 600, 924, 317, 950, 308, 553, 464, 674, 461, 839, 769, 983, 626, 651, 405, 206, 221, 
                282, 344, 684, 287, 496, 354, 455, 891, 149, 907, 555, 426, 976, 346, 543, 997, 666, 348, 796, 570, 400, 
                683, 428, 106, 803, 332, 369, 687, 12, 318, 883, 476, 449, 82, 856, 761, 253, 325, 632, 485, 308, 779, 78, 
                202, 150, 303, 354, 215, 108, 451, 464, 984, 94, 916, 862, 628, 376, 145, 364, 906, 73, 548, 130, 213, 357, 
                493, 969, 112, 954, 672, 94, 127, 375, 787, 156, 224, 464, 497, 561, 863, 969, 114, 172, 221, 732, 609, 254, 
                43, 99, 240, 526, 757, 656, 558, 744, 363, 60, 254, 750, 814, 133, 260, 578, 306, 209, 83, 745, 562, 16, 534, 
                817, 904, 483, 889, 110, 764, 73, 974, 912, 139, 430, 812, 565, 647, 880, 759, 543, 934, 597, 408, 133, 829, 
                221, 821, 325, 314, 207, 218, 435, 413, 655, 696, 983, 618, 34, 968, 823, 592, 444, 643, 268, 748, 393, 24, 
                778, 754, 806, 644, 722, 689, 477, 114, 345, 606, 583, 348, 43, 608, 704, 189, 104, 214, 134, 961, 968, 509, 
                378, 621, 13, 205, 693, 586, 172, 544, 364, 363, 522, 531, 957, 767, 265, 173, 76, 416, 139, 295, 799, 717, 
                685, 825, 579, 541, 373, 178, 302, 341, 416, 488, 722, 577, 633, 316, 432, 722, 863, 263, 730, 19, 166, 266, 
                150, 50, 85, 577, 277, 144, 594, 106, 191, 631, 336, 541, 496, 24, 727, 68, 810, 411, 383, 892, 1, 564, 530, 
                671, 764, 12, 760, 351, 740, 477, 191, 322, 183, 906, 825, 920, 600, 299, 133, 186, 818, 266, 244, 795, 728, 
                686, 811, 692, 626, 938, 69, 777, 289, 149, 155, 29, 643, 671, 189, 319, 876, 397, 327, 426, 889, 431, 159, 
                770, 558, 686, 280, 337, 802, 830, 536, 782, 708, 900, 73, 467, 729, 780, 903, 348, 818, 730, 594, 891, 752, 
                878, 962, 980, 366, 939, 211, 391, 546, 84, 350, 116, 628, 793, 306, 290, 414, 842, 550, 230, 71, 966, 281, 
                214, 914, 398, 675, 564, 478, 44, 564, 169, 634, 150, 637, 227, 727, 477, 141, 913, 243, 535, 530, 985, 607, 
                506, 407, 677, 366, 341, 208, 622, 406, 211, 108, 535, 667, 409, 200, 252, 126, 290, 402, 251, 575, 464, 107, 
                787, 172, 359, 661, 987, 440, 717, 368, 218, 142, 864, 453, 645, 821, 313, 245, 350, 33, 106, 499, 808, 607, 
                798, 705, 687, 368, 611, 570, 998, 624, 378, 626, 746, 745, 333, 567, 206, 543, 530, 550, 895, 54, 842, 992, 
                23, 167, 286, 836, 829, 164, 214, 641, 925, 355, 717, 575, 596, 530, 22, 261, 165, 973, 770, 160, 938, 95, 
                378, 493, 775, 39, 844, 795, 379, 251, 201, 353, 829, 110, 40, 404, 739, 510, 378, 973, 587, 497, 305, 941, 
                368, 148, 737, 557, 625, 68, 41, 370, 919, 613, 225, 486, 976, 888, 330, 399, 697, 805, 503, 989, 804, 500, 
                453, 795, 500, 569, 374, 46, 28, 895, 562, 215, 263, 758, 745, 326, 619, 987, 926, 90, 499, 165, 875, 25, 172, 
                213, 669, 183, 350, 54, 139, 552, 310, 47, 717, 435, 576, 562, 625, 324, 886, 978, 986, 443, 67, 167, 23, 803, 
                396, 63, 999, 858, 951, 12, 876, 367, 918, 225, 871, 869, 478, 659, 601, 551, 456, 134, 125, 773, 596, 468, 
                558, 375, 443, 503, 910, 120, 778, 380, 923, 475, 669, 584, 420, 4, 420, 405, 457, 848, 168, 639, 850, 901, 269
            };

            return array;
        }

        private static int[] CreateTestInput2()
        {
            int[] array =
            {

                921, 792, 944, 382, 852, 732, 568, 169, 921, 295, 352, 971, 810, 87, 311, 426, 281, 605, 854, 778, 305, 19, 
                828, 80, 753, 135, 938, 247, 566, 97, 879, 611, 251, 907, 506, 337, 370, 637, 466, 322, 989, 754, 726, 925, 
                995, 919, 567, 908, 8, 73, 218, 430, 578, 812, 266, 213, 675, 106, 364, 502, 271, 968, 427, 320, 828, 769, 
                792, 508, 53, 746, 894, 614, 636, 655, 795, 866, 115, 168, 836, 881, 374, 465, 46, 872, 19, 284, 349, 429, 
                288, 637, 10, 65, 225, 270, 792, 32, 983, 340, 706, 779, 4, 53, 119, 164, 954, 905, 918, 219, 988, 600, 790, 
                707, 584, 996, 664, 384, 38, 168, 26, 317, 624, 30, 81, 858, 283, 223, 593, 448, 733, 150, 319, 105, 631, 347, 
                977, 849, 463, 237, 616, 519, 110, 292, 413, 186, 247, 588, 490, 380, 452, 451, 685, 698, 21, 58, 943, 162, 
                21, 127, 774, 499, 186, 945, 983, 660, 583, 928, 317, 741, 877, 316, 100, 789, 240, 197, 375, 29, 274, 213, 
                218, 985, 36, 601, 449, 140, 920, 535, 616, 690, 81, 803, 550, 175, 174, 350, 869, 372, 934, 610, 753, 876, 
                123, 707, 908, 331, 50, 193, 488, 492, 313, 193, 24, 506, 554, 409, 662, 928, 527, 907, 666, 812, 68, 840, 
                452, 118, 931, 545, 555, 574, 200, 679, 235, 603, 474, 940, 237, 445, 461, 406, 104, 608, 250, 217, 670, 750, 
                402, 135, 190, 722, 997, 907, 747, 890, 784, 30, 231, 234, 554, 277, 495, 636, 280, 148, 387, 297, 87, 913,
                600, 267, 81, 390, 638, 553, 917, 322, 805, 744, 66, 640, 16, 608, 610, 370, 338, 573, 77, 806, 35, 113, 588, 
                777, 811, 48, 956, 158, 67, 416, 935, 39, 645, 898, 190, 904, 458, 789, 874, 331, 720, 666, 20, 605, 945, 973, 
                442, 325, 195, 232, 225, 409, 539, 435, 458, 773, 23, 973, 813, 701, 565, 666, 45, 12, 926, 148, 65, 329, 291, 
                162, 54, 298, 545, 875, 986, 184, 445, 204, 675, 843, 121, 319, 63, 589, 684, 138, 719, 8, 311, 431, 85, 329, 
                882, 305, 20, 583, 37, 300, 560, 109, 620, 823, 772, 179, 457, 429, 362, 112, 652, 935, 732, 791, 919, 896, 
                709, 265, 790, 48, 64, 885, 413, 490, 133, 338, 694, 879, 974, 261, 791, 397, 12, 359, 216, 724, 109, 961, 
                817, 293, 370, 375, 504, 906, 972, 656, 294, 596, 673, 346, 296, 337, 2, 806, 285, 579, 339, 7, 575, 748, 
                748, 564, 284, 727, 753, 839, 265, 788, 802, 259, 899, 310, 412, 904, 970, 46, 911, 508, 241, 945, 388, 455,
                711, 404, 573, 16, 772, 310, 649, 174, 57, 119, 446, 514, 958, 943, 963, 890, 723, 405, 919, 205, 558, 25, 
                733, 258, 4, 622, 624, 757, 910, 701, 815, 622, 939, 963, 111, 704, 1, 440, 240, 816, 2, 156, 31, 173, 715, 
                516, 699, 701, 865, 96, 353, 875, 973, 105, 523, 720, 881, 413, 468, 611, 810, 425, 117, 144, 941, 862, 791,
                154, 62, 773, 369, 559, 994, 71, 939, 294, 9, 699, 117, 475, 716, 924, 33, 725, 201, 223, 745, 621, 905, 978,
                999, 343, 31, 819, 666, 908, 138, 920, 651, 642, 665, 117, 815, 500, 888, 941, 31, 759, 412, 381, 335, 514,
                831, 603, 320, 340, 960, 834, 996, 916, 732, 527, 691, 639, 208, 84, 492, 565, 759, 68, 866, 381, 377, 863, 
                604, 734, 726, 648, 593, 99, 462, 423, 550, 570, 355, 598, 584, 586, 952, 169, 305, 802, 14, 855, 925, 663, 
                864, 586, 397, 771, 43, 894, 680, 311, 514, 696, 486, 158, 520, 368, 469, 249, 1, 825, 529, 770, 715, 392, 
                97, 201, 475, 380, 800, 515, 768, 808, 151, 630, 446, 685, 361, 773, 938
            };

            return array;
        }
    }
}

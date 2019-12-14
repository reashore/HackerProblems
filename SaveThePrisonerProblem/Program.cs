using System;

namespace SaveThePrisonerProblem
{
    internal static class Program
    {
        internal static void Main()
        {
            RunSpecialTests();
            RunTests();
        }

        private static void RunSpecialTests()
        {
            int numberPrisoners;
            int numberCandies;
            int startChairIndex;
            int endChairIndex;

            numberPrisoners = 5;
            numberCandies = 2;
            startChairIndex = 1;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 2
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 5;
            numberCandies = 2;
            startChairIndex = 2;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 3
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 7;
            numberCandies = 19;
            startChairIndex = 2;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 6
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 3;
            numberCandies = 7;
            startChairIndex = 3;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 3
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            //-------------------------------------------------------

            numberPrisoners = 4;
            numberCandies = 4;
            startChairIndex = 1;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 4
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 4;
            numberCandies = 4;
            startChairIndex = 2;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 1
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 4;
            numberCandies = 4;
            startChairIndex = 3;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 2
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 4;
            numberCandies = 4;
            startChairIndex = 4;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 3
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            //-------------------------------------------------------

            numberPrisoners = 352926151;
            numberCandies = 380324688;
            startChairIndex = 94730870;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 122129406
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 208526924;
            numberCandies = 756265725;
            startChairIndex = 150817879;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 72975907
            Console.WriteLine($"endChairIndex = {endChairIndex}");

            numberPrisoners = 999999999;
            numberCandies = 999999999;
            startChairIndex = 1;
            endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);           // 999999999
            Console.WriteLine($"endChairIndex = {endChairIndex}");
        }

        private static void RunTests()
        {
            int[][] testInputArray = CreateTestInput();
            int[] testResults = CreateTestResults();
            int len = testResults.Length;

            for (int n = 0; n < len; n++)
            {
                int[] row = testInputArray[n];
                int numberPrisoners = row[0];
                int numberCandies = row[1];
                int startChairIndex = row[2];

                int endChairIndex = SaveThePrisoner(numberPrisoners, numberCandies, startChairIndex);

                int result = testResults[n];
                string message;

                if (endChairIndex != result)
                {
                    message = $"test {n,2} failed";
                }
                else
                {
                    message = $"test {n,2} passed";
                }

                Console.WriteLine(message);
            }
        }

        private static int SaveThePrisoner(int numberPrisoners, int numberCandies, int startChairIndex)
        {
            int remainder = numberCandies % numberPrisoners;
            int endChairIndex = startChairIndex + remainder - 1;

            if (endChairIndex == 0)
            {
                endChairIndex = numberPrisoners;
            }

            if (endChairIndex > numberPrisoners)
            {
                endChairIndex -= numberPrisoners;
            }

            return endChairIndex;
        }

        private static int[][] CreateTestInput()
        {
            int[][] array =
            {
                new[] {352926151, 380324688, 94730870},
                new[] {94431605, 679262176, 5284458},
                new[] {208526924, 756265725, 150817879},
                new[] {962975336, 972576181, 396355184},
                new[] {464237185, 937820284, 255816794},
                new[] {649320641, 742902564, 647542323},
                new[] {174512033, 711706897, 68977959},
                new[] {107283902, 156676511, 67149447},
                new[] {104513201, 298399273, 96292548},
                new[] {113378824, 274011418, 98103763},
                new[] {934815799, 991959468, 212396037},
                new[] {88325121, 435452998, 24617705},
                new[] {984873585, 997634055, 103050157},
                new[] {344218387, 715364875, 90658180},
                new[] {556065259, 615709967, 156417592},
                new[] {57109959, 451440582, 4188603},
                new[] {353972922, 573651462, 244520504},
                new[] {946486979, 973168361, 647886035},
                new[] {368127406, 680428368, 105517295},
                new[] {884634320, 965112925, 119757238},
                new[] {422557970, 744431033, 28932300},
                new[] {634954007, 957414623, 341366379},
                new[] {190265362, 445253893, 184632922},
                new[] {293315518, 479153471, 120684020},
                new[] {72410472, 80198999, 984948},
                new[] {784893322, 849791807, 360911386},
                new[] {846191883, 880790237, 510053756},
                new[] {297201660, 812278057, 198376746},
                new[] {945087694, 999220046, 465061514},
                new[] {786859800, 831171414, 378370933},
                new[] {528402029, 859318899, 224559950},
                new[] {522640531, 755821672, 28838424},
                new[] {864006909, 879474138, 806467486},
                new[] {613544440, 943850900, 258190755},
                new[] {734228459, 928771704, 265979283},
                new[] {542812502, 597832172, 330877768},
                new[] {541133561, 748691081, 126348492},
                new[] {51187317, 524866691, 1143193},
                new[] {885290374, 990676850, 373368385},
                new[] {147955933, 450823700, 138416059},
                new[] {100046465, 587967212, 32555061},
                new[] {233926824, 996957988, 31809378},
                new[] {785405778, 835771758, 689182705},
                new[] {444389615, 870657324, 72775880},
                new[] {702580369, 895325888, 345053199},
                new[] {968559651, 974760313, 326732084},
                new[] {299437419, 514618345, 254272806},
                new[] {901702945, 930227426, 727030891},
                new[] {721843209, 736359383, 225283784},
                new[] {833018320, 883439261, 806599246},
                new[] {267346244, 307857609, 46989880},
                new[] {299901304, 892163356, 210218436},
                new[] {565637506, 795821687, 158300457},
                new[] {107336562, 781910357, 54488503},
                new[] {513281286, 916998022, 254269425},
                new[] {413431205, 611661371, 188998419},
                new[] {740163288, 938647312, 571382392},
                new[] {44702121, 296589002, 43470596},
                new[] {771733011, 919327188, 317638907},
                new[] {718860003, 815844769, 495144331},
                new[] {377975600, 438513404, 111085209},
                new[] {424965480, 928959619, 20776133},
                new[] {234986523, 732169039, 205952749},
                new[] {377078343, 981597420, 219264561},
                new[] {612269027, 791414524, 580170106},
                new[] {232336090, 616084008, 81392003},
                new[] {75059328, 274029861, 53524881},
                new[] {239121359, 646856043, 141349731},
                new[] {923193147, 943368157, 206717532},
                new[] {12565064, 536852817, 11557940},
                new[] {360225746, 970375527, 284883902},
                new[] {213705306, 380885426, 14495860},
                new[] {659446919, 699401237, 73837176},
                new[] {335372713, 785363124, 7610828},
                new[] {538388654, 859196325, 110284314},
                new[] {118558760, 713483972, 83950807},
                new[] {896959032, 961368580, 8848444},
                new[] {25543240, 521123082, 2472730},
                new[] {258530682, 935834352, 194732411},
                new[] {465248213, 679599042, 334563499},
                new[] {331230504, 637771661, 76778140},
                new[] {976340152, 988657462, 243958260},
                new[] {552994811, 922743535, 540135280},
                new[] {626831986, 839281366, 24222267},
                new[] {157704591, 253731033, 59023773},
                new[] {806377559, 859228114, 238044289},
                new[] {838798445, 996851254, 268459446},
                new[] {847646888, 928001503, 755190846},
                new[] {877625009, 999275937, 874127074},
                new[] {847949466, 893343194, 10497830},
                new[] {35029316, 784675240, 8200127},
                new[] {111807455, 690309882, 23190325},
                new[] {355765714, 554560093, 311565654},
                new[] {1890615, 614626804, 976253},
                new[] {132293206, 165429783, 65360680},
                new[] {506726160, 934170235, 455394293},
                new[] {210041918, 328800789, 159203369},
                new[] {499999999, 999999997, 2},
                new[] {499999999, 999999998, 2},
                new[] {999999999, 999999999, 1}
            };

            return array;
        }

        private static int[] CreateTestResults()
        {
            int[] array =
            {
                122129406,
                23525398,
                72975907,
                405956028,
                265162707,
                91803604,
                82636723,
                9258153,
                81152217,
                31978708,
                269539705,
                18445097,
                115810626,
                117586280,
                216062299,
                55859471,
                110226121,
                674567416,
                49690850,
                200235842,
                350805362,
                28872987,
                59090728,
                13206454,
                8773474,
                425809870,
                544652109,
                119049822,
                519193865,
                422682546,
                27074790,
                262019564,
                821934714,
                588497214,
                460522527,
                385897437,
                333906011,
                14136713,
                478754860,
                145371959,
                20243482,
                93060069,
                739548684,
                54653973,
                537798717,
                332932745,
                170016312,
                755555371,
                239799957,
                24001866,
                87501244,
                202677879,
                388484637,
                85042925,
                144704874,
                387228584,
                29703127,
                27144750,
                465233083,
                592129096,
                171623012,
                99804791,
                233162218,
                69626951,
                147046575,
                467740,
                27317429,
                70841696,
                226892541,
                8113004,
                174582190,
                181675979,
                113791493,
                122228525,
                431091984,
                86082218,
                73257991,
                12731011,
                96444034,
                83666114,
                52088792,
                256275569,
                356889192,
                236671646,
                155050214,
                290894843,
                426512254,
                835545460,
                118152992,
                55891557,
                22230414,
                42655476,
                154594318,
                1153181,
                98497256,
                376112207,
                67920321,
                499999999,
                1,
                999999999
            };

            return array;
        }
    }
}

namespace InterviewScheduling
{
    class Program
    {
        static void Main(string[] args)
        {


            ApplicantsClass[] Applicants = new ApplicantsClass[13];


            Applicants[0] = new ApplicantsClass("Danunsi Helen", 5);
            Applicants[1] = new ApplicantsClass("Dami Olubanke", 5);
            Applicants[2] = new ApplicantsClass("Ojo Michael", 4);
            Applicants[3] = new ApplicantsClass("Justice Ogbobula", 2);
            Applicants[4] = new ApplicantsClass("Ogunwo Michael", 4);
            Applicants[5] = new ApplicantsClass("Anthony Akinwa", 3);
            Applicants[6] = new ApplicantsClass("Akinubi Busayo", 3);
            Applicants[7] = new ApplicantsClass("Daniel Ayo", 1);
            Applicants[8] = new ApplicantsClass("Damilola Ileola", 3);
            Applicants[9] = new ApplicantsClass("Idowu Tomiwa", 2);
            Applicants[10] = new ApplicantsClass("Shoduke Toyosi", 3);
            Applicants[11] = new ApplicantsClass("Eniola Esther", 1);
            Applicants[12] = new ApplicantsClass("Funmi Toyosi", 7);


            int[] somr = new int[] { 1, 2, 5, 6, 8, 4, 7 };

            MergeSort(somr);

            Array.Reverse(somr);

            foreach (int number in somr)
            {
                Console.Write(number);
            }


            #region DERIVE THE SCORES FROM THE APPLICATION LIST

            int[] applicantsScores = new int[13];


            foreach (var applicant in Applicants)
            {

                for (int i = 0; i <= applicantsScores.Length - 1; i++)
                {
                    applicantsScores[i] = applicant.Score;
                }
            }

            foreach (var item in applicantsScores)
            {
                Console.WriteLine(item);
            }

            #endregion




            #region MOVE THE RESPECTIVE APPLICANTS TO THEIR VARIOUS LISTS FOR SCHEDULING

            // 1. Make two IEnumerable<ApplicantsClass>, then use LINQ to add the ones higher than 5 and the ones lower than 5 to their respective IEnumerable<ApplicantsClass>

            // 2. Then make two new IEnumerable<ApplicantsClass>, then use LINQ to add the applicants whose scores are equal to the IEnumerable<ApplicantsClass> created above





            // 2.

            //ApplicantsClass[] ApplicantsAbove5 = (ApplicantsClass[])Applicants.Where(x => x.Score >= 5);

            //ApplicantsClass[] ApplicantsBelow5 = (ApplicantsClass[])Applicants.Where(x => x.Score <= 5);

            IEnumerable<ApplicantsClass> ApplicantsAbove5 = from applicant in Applicants where applicant.Score >= 5 select applicant;

            IEnumerable<ApplicantsClass> ApplicantsBelow5 = from applicant in Applicants where applicant.Score < 5 select applicant;

            #endregion





            Console.WriteLine("WEEK 1:");
            foreach (ApplicantsClass applicant in ApplicantsAbove5)
            {
                Console.WriteLine("Applicant: " + applicant.Name + "    -   " + applicant.Score);
            }

            Console.WriteLine();

            Console.WriteLine("WEEK 2:");
            foreach (ApplicantsClass applicant in ApplicantsBelow5)
            {
                Console.WriteLine("Applicant: " + applicant.Name + "    -   " + applicant.Score);
            }


        }


        #region PERFORM A MERGERSORT ON THE DERIVED DATA, THEN REVERSE IT TO KEEP THE DATA IN DESCENDING ORDER

        //The MergeSort Algorithm recursively divides an array in 2, sorts, and recombines

        public static void MergeSort(int[] array)
        {
            int arrayLength = array.Length;

            // we always divide our array in two, so we stop when we can no longer divide
            if (arrayLength <= 1)
            {
                return;
            }

            int middleofArray = arrayLength / 2;

            int[] leftArray = new int[middleofArray];
            int[] rightArray = new int[arrayLength - middleofArray];

            int l = 0; //for left array
            int r = 0; //for right array

            for (; l < arrayLength; l++)
            {
                if (l < middleofArray)
                {
                    leftArray[l] = array[l];
                }
                else
                {
                    rightArray[r] = array[l];
                    r++;
                }
            }

            // recursion
            MergeSort(leftArray);
            MergeSort(rightArray);
            Merger(leftArray, rightArray, array);
        }

        public static void Merger(int[] leftHalf, int[] rightHalf, int[] array)
        {
            int leftArraySize = array.Length / 2; //half of the array
            int rightArraySize = array.Length - leftArraySize; //the other half of the array

            int i = 0, l = 0, r = 0; //indices for initial, left and right arrays

            // check the conditions for merging


            while (l < leftArraySize && r < rightArraySize)
            {
                //if the left number at each index is less, add it to the initial array
                if (leftHalf[l] < rightHalf[r])
                {
                    array[i] = leftHalf[l];
                    i++;
                    l++;
                }
                //else add the right number
                else
                {
                    array[i] = rightHalf[r];
                    i++;
                    r++;
                }
            }

            //for that one last element we can't compare
            while (l < leftArraySize)
            {
                array[i] = leftHalf[l];

                r++;
                l++;
            }
            while (r < rightArraySize)
            {
                array[i] = rightHalf[r];

                i++;
                r++;
            }
        }

        #endregion



        public class ApplicantsClass : IComparable<ApplicantsClass>
        {
            public string Name;
            public int Score;

            public ApplicantsClass(string name, int score)
            {
                this.Name = name;
                this.Score = score;
            }


            public int CompareTo(ApplicantsClass applicants)
            {
                return applicants.Score - this.Score;
            }
        }
    }
}
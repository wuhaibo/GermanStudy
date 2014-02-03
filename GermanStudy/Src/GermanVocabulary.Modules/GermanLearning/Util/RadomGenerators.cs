using System;

namespace GermanLearningModule.Util
{
    /// <summary>
    /// Class to generate Radom numbers
    /// </summary>
    public class RadomGenerators
    {

        /// <summary>
        /// Method to generates radom numbers.
        /// The radom numbers contain no number of notThisNum and are in the range of [rangMin rangeMax).
        /// </summary>
        /// <param name="results"></param>
        /// <param name="resultsLen"></param>
        /// <param name="notThisNum"></param>
        /// <param name="rangeMin"></param>
        /// <param name="rangeMax"></param>
        /// <param name="rndGenerator"></param>
        /// <returns></returns>
         public string GetRadoms(int[] results, int resultsLen, int notThisNum, int rangeMin, int rangeMax, Random rndGenerator)
        {
            
            for (int i = 0; i < resultsLen; i++)
            {
                int counter = 0;
                while (true)
                {
                    counter++;

                    //generate radom number
                    int rndNum = rndGenerator.Next(rangeMin, rangeMax);

                    //check if the radom number is already there
                    if (NotSame(results, i+1, notThisNum, rndNum))
                    {
                        results[i] = rndNum;
                        break;
                    }

                    //too many iterations not allowed
                    if (counter > 20)
                    {
                        return "radom number is not generated.";
                    }
                }
            }
            return String.Empty;

        }

         private bool NotSame(int[] results, int resultsLen, int notThisNum, int rndNum)
        {
             if (results == null) throw new ArgumentNullException("results");

             for (int i = 0; i < resultsLen; i++)
            {
                if (rndNum == results[i] || rndNum == notThisNum)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

using System;

namespace ConsoleApp2
{
    class Program
    {
        public static int BinaryGap(int N)
        {
            //converts N to string that contains the binary number representation
            string M = Convert.ToString(N, 2);

            //counter
            int binaryGap = 0;
            //maxGap will be returned
            int maxGap = 0;

            //iterates each item within string M
            for (int i = 0; i < M.Length; i++)
            {
                //if the current value in M is not 0, skip to reduce resource use
                if (M[i] == '1')
                {
                    continue;
                }

                else
                {
                    //since M[i] = 0, increase count by 1
                    binaryGap += 1;

                    //j is equal to i + 1 to avoid backtracking and reduce resource use
                    for (int j = i+1 ; j < M.Length; j++)
                    {
                        //prevents an out of range exception
                        if (j <= M.Length)
                        {
                            //increases count if M[j] = 0
                            if (M[j] == '0')
                            {
                                binaryGap += 1;
                            }
                            else
                            {
                                //added to ensure that count is 
                                maxGap = Math.Max(binaryGap, maxGap);
                                break;
                            }
                        }
                        //prevents an out of range exception
                        else
                        {
                            break;
                        }
                    }

                    //if the binary number consists of only 0's, there is no gap. Therefore the current count is deleted. *See line 48 to see how previous counts were stored
                    if (M[M.Length -1]== '0')
                    {
                        binaryGap = 0;
                    }

                    //checks whether previous binary gap(int maxGap) was higher than current one
                    maxGap = Math.Max(binaryGap, maxGap); 

                    //resets the count for the next iteration
                    binaryGap = 0;
                }
            }
            
             return maxGap;
           
        }
    }
}


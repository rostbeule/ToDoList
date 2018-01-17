using System;
using System.Collections.Generic;

namespace ToDoList
{
    public class SortAscending : IComparer<Calendar>
    {
        public int Compare(Calendar day1, Calendar day2)
        {
            if (day1 is Calendar && day2 is Calendar)
            {
                string[] day1arr = day1.Date.Split('.');
                string[] day2arr = day2.Date.Split('.');

                int[] d1 = new int[day1arr.Length];
                for (int i = 0; i < day1arr.Length; i++)
                    d1[i] = Convert.ToInt32(day1arr[i]);

                int[] d2 = new int[day2arr.Length];
                for (int i = 0; i < day2arr.Length; i++)
                    d2[i] = Convert.ToInt32(day2arr[i]);

                if (d1[d1.Length - 1] < d2[d2.Length - 1])
                    return -1;
                else if (d1[d1.Length - 1] > d2[d2.Length - 1])
                    return 1;
                else
                {
                    if (d1[d1.Length - 2] < d2[d2.Length - 2])
                        return -1;
                    else if (d1[d1.Length - 2] > d2[d2.Length - 2])
                        return 1;
                    else
                        return (d1[d1.Length - 3] < d2[d2.Length - 3]) ? -1 :
                               (d1[d1.Length - 3] > d2[d2.Length - 3]) ? 1 : 0;
                }
            }
            throw new ArgumentException("At least one object is not of type XML_Handler.");        
        }
    }
}

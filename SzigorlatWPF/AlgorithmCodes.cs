﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SzigorlatWPF
{
    class AlgorithmCodes
    {
        int[] array = new int[20];
        Random rnd = new Random();
        private void FillArray()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rnd.Next(0, 11);
            }

        }
        public int SumFunc()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
        public int LinearSearch()
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 5) index = i; //Hányadik elem az ötös. -1 ha nincs ötös.
            }
            return index;
        }
        public string GetArrayString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i].ToString() + " ");
            }
            return sb.ToString();
        }
        public AlgorithmCodes()
        {
            FillArray();
        }


    }
}

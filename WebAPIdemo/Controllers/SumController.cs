using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace WebAPIdemo.Controllers
{
    public class SumController : ApiController
    {
        //cheacks if the number is a real number
        public static Boolean ValidAsNum(String num)
        {
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] < '0' || num[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }

        //return a reverse int array from string num
        public static int[] ToArrayInt(String num)
        {
            int[] output = new int[num.Length];
            for(int i = 0; i < num.Length; i++)
            {
                if(num[i]>='0' && num[i] <= '9')
                {
                    output[output.Length - i - 1] = num[i]-'0';
                }
            }
            int notReally = 0;
            for (int j = output.Length-1; j > -1; j--)
            {
                if (output[j] != 0)
                {
                    return PartArray(output, output.Length - notReally);
                }
                notReally++;
            }
            int[] zero = { 0 };
            return zero;
        }

        //erase the starting zeros
        public static int[] PartArray(int[] arr, int newLength)
        {
            if (newLength == arr.Length)
            {
                Array.Reverse(arr);
                return arr;
            }
            int[] output = new int[newLength];
            for (int i = 0; i < newLength; i++)
            {
                output[i] = arr[i];
            }
            Array.Reverse(output);
            return output;
        }

        public static int[] sum(int[] firstNum, int[] secondNum)
        {
            Array.Reverse(firstNum);
            Array.Reverse(secondNum);
            int[] bigger = firstNum;
            int[] smaller = secondNum;
            if (firstNum.Length < secondNum.Length)
            {
                bigger = secondNum;
                smaller = firstNum;
            }
            //digtis of sum of two numbers is maximum 
            //the num of digits of the bigger one plus one  
            int[] output = new int[bigger.Length + 1];
            int curry = 0; //if sum of 2 digits are bigger than 10 we need to add the rest for next digits
            int i;
            for (i = 0; i < bigger.Length; i++)
            {
                int sumDigit = 0;
                if (i < smaller.Length) // if i>smaller.length then we only need bigger digit
                    sumDigit = smaller[i];
                sumDigit = sumDigit + bigger[i] + curry;
                curry = sumDigit / 10;
                output[i] = sumDigit % 10;
            }
            output[bigger.Length] = curry;
            int notReally = 0;
            //cheack what is the real number without starting zeros
            for (int j = bigger.Length; j > -1; j--)
            {
                if (output[j] != 0)
                {
                    return PartArray(output, output.Length - notReally);
                }
                notReally++;
            }
            //if we got to here so we got [0,0,0,0...] then its a zero
            int[] zero = { 0 };
            return zero;
        }

        public String Get(String numA = "0", String numB = "0")
        {
            if (ValidAsNum(numA) && ValidAsNum(numB))
            {
                int[] output = sum(ToArrayInt(numA), ToArrayInt(numB));
                String getOut = "";
                for (int i = 0; i < output.Length; i++)
                {
                    String digit = output[i].ToString();
                    getOut = String.Concat(getOut, digit);
                }
                return getOut;
            }
            return "Not a Valid number";
        }
    }
}
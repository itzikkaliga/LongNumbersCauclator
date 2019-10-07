using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace WebAPIdemo.Controllers
{
    public class MultiplyController : ApiController
    {
        //check if the given string is realy a number
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

        //convert the string to an int array such that if
        //the original string was 0001 we return [1]
        public static int[] ToArrayInt(String num)
        {
            int[] output = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] >= '0' && num[i] <= '9')
                {
                    output[output.Length - i - 1] = num[i] - '0';
                }
            }
            int notReally = 0;
            for (int j = output.Length - 1; j > -1; j--)
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

        //returning an array without all the first zeros to get a real number
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

        public static int[] multiply(int[] firstNum, int[] secondNum)
        {
            Array.Reverse(firstNum);
            Array.Reverse(secondNum);
            //digtis of multiply of two numbers is maximum 
            //the sum of the digits from the two numbers  
            int[] output = new int[firstNum.Length + secondNum.Length];
            //using long multiply
            for (int i = 0; i < firstNum.Length; i++)
            {
                for (int j = 0; j < secondNum.Length; j++)
                {
                    int sumDigit = 0;
                    sumDigit = firstNum[i] * secondNum[j]  + output[i + j];
                    output[i + j] = sumDigit % 10;
                    int s = 1;
                    //moving the curry for next digits
                    sumDigit = sumDigit / 10;
                    while (sumDigit != 0)
                    {
                        output[i + j + s] += sumDigit % 10;
                        sumDigit = sumDigit / 10;
                    }
                }
            }
            //we want to earse the zeros from the start of the number to retun a real number
            int notReally = 0;
            for (int j = output.Length - 1; j > -1; j--)
            {
                if (output[j] != 0)
                {
                    return PartArray(output, output.Length - notReally);
                }
                notReally++;
            }
            //if we got here than it say that the number was [0,0,0,...] so it is a zero
            int[] zero = { 0 };
            return zero;
        }

        public String Get(String numA = "0", String numB = "0")
        {
            if (ValidAsNum(numA) && ValidAsNum(numB))
            {
                int[] output = multiply(ToArrayInt(numA), ToArrayInt(numB));
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
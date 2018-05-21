using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
  class Program
  {
    static void Main(string[] args)
    {
      string result = "";
      Console.WriteLine("Please write a password");
      string password = Console.ReadLine();

      Dictionary<string, int> goodPasswords = new Dictionary<string, int>();   //holds the good password stored so far; Dictionary. K: password, V:passwordLength

      StringBuilder streek = new StringBuilder();   //holds the current streek
      int streekLength = 0;  //holds the length of the password.
      bool isPasswordValid = false;
      int sCount = 0;  //number of s's
      int dCount = 0;  //number of d's
      char[] unallowedChars = new[] { 'c', '!' };
      for (int i = 0; i < password.Length + 1; i++)
      {
        if (i == password.Length)
        {
          if (isPasswordValid)
          {
            goodPasswords.Add(streek.ToString(), streekLength);   //[vassdfqwer, 10], [@#$assd,7]
          }
          break;
        }


        char ch = password[i];  //z  //x  //c  //v  //a  //s //s  //d  //f  //q  //w  //e  //r  //!  //@  //#  //$  //a  //s  //s  //d
        if (unallowedChars.Contains(ch))   //the current char is unallowed, stop the streek
        {
          if (isPasswordValid)
          {
            goodPasswords.Add(streek.ToString(), streekLength);   //vassdfqwec, 10
          }
          streek.Clear();
          streekLength = 0;
          sCount = 0;
          dCount = 0;
          isPasswordValid = false;
          continue;
        }

        streek.Append(ch);   //z  //zx  //v  //va  //vas  //vass  //vassd  //vassdf //vassdfq  //vassdfqw  //vassdfqwe  //vassdfqwec  //@  //@#  //@#$  //@#$a  //@#$as  //@#$ass  //@#$assd
        streekLength++;     //1  //2  //1  //2  //3  //4  //5  //6  //7  //8  //9  //10  //1  //2  //3  //4  //5  //6  //7
        if (!isPasswordValid)
        {
          if (ch == 's')
          {
            sCount++;  //1  //2  //1  //2
          }
          else if (ch == 'd')
          {
            dCount++;  //1  //1
          }
          if (sCount >= 2 && dCount >= 1)
          {
            isPasswordValid = true;  //true  //true
          }
        }
      }

      //find the best password
      int max = 0;
      string maxPassword = "";
      for (int i = 0; i < goodPasswords.Count; i++)
      {
        var kp = goodPasswords.ElementAt(i);

        if (kp.Value >= max)
        {
          max = kp.Value;
          maxPassword = kp.Key;
        }
      }
      result = maxPassword;

      //return it
      Console.WriteLine("The best password found is: " + result);
      Console.ReadLine();
    }
  }
}

// a e o u i 
string s = "aeiou"; int k = 2;

   Console.Write(MaxVowels(s,k));

int MaxVowels(string s, int k)
{
        int max=0;
   for(int i = 0; i < k; i++)
    {
        if (IsVowel(s[i]))
        {
            max++;
        }
    }
    
    
      int start =1;
      int end=k;
      int check=max;
    while (end<s.Length)
    {


        if (IsVowel(s[start - 1]))
        {
            check--;
        }

        if (IsVowel(s[end]))
        {
            check++;
        }
        start++;
        end++;

        if (check > max)
        {
            max=check;
        }
       
    }


   return max;
}

 bool IsVowel(char c)
{
    return c=='a' || c=='e' || c=='o' || c=='u' || c=='i';    
}
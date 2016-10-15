//Programmer:   Brett Reinhard
//Date:         10/13/2016
using System;
public class Fraction
{
    //Defaults Fraction to 0 0/1
    public Fraction()
    {
        Whole = 0;
        Numerator = 0;
        Denominator = 1;
    }
    //Defaults Fraction to 0 0/1 then Parses string to see 
    public Fraction(string fracFirst)
    {
        Whole = 0;
        Numerator = 0;
        Denominator = 1;
        //When FractionDemo initializes with a string, parseString is called to set the Whole, Numerator, and Denominator.
        parseString(fracFirst);

    }
    // FractionDemo constructor overloaded to allow for only Numerator and Denominator
    public Fraction(int num, int denom)
    {
       
        Whole = 0;
        Numerator = num;
        Denominator = denom;


    }
    // FractionDemo constructor overloaded to allow for Whole, Numerator, and Denominator
    public Fraction(int whole, int num, int denom)
    {
        //Sets Whole with whole passed
        Whole = whole;
        //Sets Numerator with numerator passed
        Numerator = num;
        //Checkes denominator for non zero, then initializes as 1 if 0 or as denominator passed as Denominator value
        if (denom != 0)
            Denominator = denom;
        else
            Denominator = 1;
        
    }
    //Whole number field
    private int _whole;
    //Whole number Property
    public int Whole
    {
        get
        {
            return _whole;
        }
        set
        {
            _whole = value;
        }
    }
    //Numerator number field
    private int _numerator;
    //Numerator number Property
    public int Numerator
    {
        get
        {
            return _numerator;
        }
        set
        {
            _numerator = value;
        }
    }
    //Denominator number field
    private int _denominator;
    //Denominator number Property
    public int Denominator
    {
        get
        {
            return _denominator;

            }
        set
        {
            if (value == 0)
            {
                _denominator = 1;
            }
            else
            {
                _denominator = value;
            }
        }
    }
    //Private Method to reduce a fraction into its lowest terms, allows for whole, numerator, and denominator
    private void Reduce( int whole,  int num,  int denom)
    {
        //Factors fracting into improper fractions for easier calculation of lowest form and get rid of any possible user error input ie: 1 32/12
        Numerator = num + (whole * denom);
        Whole = 0;
        Denominator = denom;

        if (Numerator == Denominator && whole == 0)
        {
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator))));
            Numerator = 0;
            Denominator = 1;

        }else if(num == denom)
        {
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator))));
            Numerator = 0;
            Denominator = 1;
        }
        else if (num > denom)
        {
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator))));
            Numerator = num % denom;
        }
        //For loop to ensure Numerator and Denominator are factored into their lowest possible form
        for (int i =Numerator * Denominator; i>1; i--)
        {
            if((Numerator % i == 0) && (Denominator % i == 0)){
                Numerator /= i;
                Denominator /= i;
            }
        }


    }
    //Private Method to reduce a fraction into its lowest terms, overloaded to allow for just numerator and denominator
    private void Reduce( int num, int denom)
    {

        Whole = 0;
        Numerator = 0;
        Denominator = 1;
        //Tests to see if Numerator = Denominator and sets Whole number while settings Numerator and Denominator to 0
        if (num == denom)
        {
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(num) / Convert.ToDouble(denom))));
            Numerator = 0;
            Denominator = 1;

        }
        //Tests to see if Numerator is greater than Denominator to set the Whole number, and set Numerator value to the left over amount 
        else if (num > denom)
        {
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(num) / Convert.ToDouble(denom))));
            Numerator = num % denom;
            Denominator = denom;
        }
        //For loop to ensure Numerator and Denominator are factored into their lowest possible form
        for (int i = Numerator * Denominator; i > 1; i--)
        {
            if ((Numerator % i == 0) && (Denominator % i == 0))
            {
                Numerator /= i;
                Denominator /= i;
            }
        }


    }
    //Adds two fractions including whole numbers, numerators, and denominators
    public void Add(int wholeFirst,int numFirst, int denomFirst, int wholeSecond, int numSecond, int denomSecond)
    {
        Whole = wholeFirst + wholeSecond;
        Numerator = (numFirst * denomSecond) + (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Adds two fractions using only 2 numerators and 2 denominators
    public void Add( int numFirst, int denomFirst,  int numSecond, int denomSecond)
    {
        Whole = 0;
        Numerator = (numFirst * denomSecond) + (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Adds two fractions in string form and parses them by use of Private void parseString() to get integer values for proper mathmatical operations
    public void Add(string fracFirst, string fracSecond)
    {
        int wholeFirst=0, wholeSecond=0, numFirst=0, numSecond=0, denomFirst=0, denomSecond=0;
        //Calls parseString() with pass by reference for mathmatical operations
        parseString(fracFirst, fracSecond, ref wholeFirst, ref numFirst, ref denomFirst, ref wholeSecond, ref numSecond, ref denomSecond);
        Whole = wholeFirst + wholeSecond;
        Numerator = (numFirst * denomSecond) + (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Subtracts two fractions including whole numbers, numerators, and denominators
    public void Subtract(int wholeFirst, int numFirst, int denomFirst, int wholeSecond, int numSecond, int denomSecond)
    {
        Whole = wholeFirst - wholeSecond;
        Numerator = (numFirst * denomSecond) - (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Subtracts two fractions using only 2 numerators and 2 denominators
    public void Subtract(int numFirst, int denomFirst, int numSecond, int denomSecond)
    {
        Whole = 0;
        Numerator = (numFirst * denomSecond) - (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Subtracts two fractions in string form and parses them by use of Private void parseString() to get integer values for proper mathmatical operations
    public void Subtract(string fracFirst, string fracSecond)
    {
        int wholeFirst = 0, wholeSecond = 0, numFirst = 0, numSecond = 0, denomFirst = 0, denomSecond = 0;
        //Calls parseString() with pass by reference for mathmatical operations
        parseString(fracFirst, fracSecond, ref wholeFirst, ref numFirst, ref denomFirst, ref wholeSecond, ref numSecond, ref denomSecond);
        Whole = wholeFirst - wholeSecond;
        Numerator = (numFirst * denomSecond) - (numSecond * denomFirst);
        Denominator = denomFirst * denomSecond;
        Reduce(Whole, Numerator, Denominator);
    }
    //Multiplies 2 whole numbers, 2 numerators, and 2 denominators
    public void Multiply( int wholeFirst, int numFirst,  int denomFirst, int wholeSecond, int numSecond, int denomSecond)
    {
        // Creates 2 improper fractions to multiply for proper results
        numFirst = numFirst + (wholeFirst * denomFirst);
        wholeFirst = 0;
        numSecond = numSecond + (wholeSecond * denomSecond);
        wholeSecond = 0;
        Whole = 0;
        //Combines the Numerators to pass to Reduce() for a reduced proper fraction
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Could also use Reduce(Numerator, Denominator), but the below code is a bit more clear
        Reduce(Whole,Numerator, Denominator);
    }
    //Overloaded Multiplies 2 numerators and 2 denominators
    public void Multiply( int numFirst, int denomFirst, int numSecond, int denomSecond)
    {
        Whole = 0;
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Calls Reduce to reduce to proper fraction
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Multiplies 2 fractions in string variables and parses by means of parseString to return integers for proper mathematical operations
    public void Multiply( string fracFirst, string fracSecond)
    {
        int wholeFirst = 0, wholeSecond = 0, numFirst = 0, numSecond = 0, denomFirst = 0, denomSecond = 0;
        //Parses fraceFirst and fracSecond and returns them by means of referenced variables
        parseString(fracFirst, fracSecond, ref wholeFirst, ref numFirst, ref denomFirst, ref wholeSecond, ref numSecond, ref denomSecond);
        //Converts to improper fraction and multiplies the results together
        numFirst = numFirst + (wholeFirst * denomFirst);
        wholeFirst = 0;
        numSecond = numSecond + (wholeSecond * denomSecond);
        wholeSecond = 0;
        Whole = 0;
        //Combines into one Numerator and Denominator to be passed to reduce
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Reduce function to reduce to proper fraction
        Reduce(Whole, Numerator, Denominator);
    }
    //Divides 2 whole numbers(if included), 2 numerators, and 2 denominators which are parsed from 2 string inputs
    public void Divide(string fracFirst, string fracSecond)
    {
        int wholeFirst = 0, wholeSecond = 0, numFirst = 0, numSecond = 0, denomFirst = 0, denomSecond = 0, tempDenom;
        //Parses fraceFirst and fracSecond and returns them by means of referenced variables
        parseString(fracFirst, fracSecond, ref wholeFirst, ref numFirst, ref denomFirst, ref wholeSecond, ref numSecond, ref denomSecond);
        //Converts to improper fraction and multiplies the results together
        numFirst = numFirst + (wholeFirst * denomFirst);
        wholeFirst = 0;
        numSecond = numSecond + (wholeSecond * denomSecond);
        wholeSecond = 0;
        Whole = 0;
        //Inverses second fraction to simply multiply and reuse code from multiply
        //After temp is given back to numSecond a private Multiply function could be used if adding to the stack is of no importance.
        tempDenom = denomSecond;
        denomSecond = numSecond;
        numSecond = tempDenom;
        //Combines into one Numerator and Denominator to be passed to reduce
        //MultiplyForDivision(numFirst,denomFirst,numSecond,denomSecond); instead of the next 2 lines
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Reduce function to reduce to proper fraction
        Reduce(Whole, Numerator, Denominator);
    }
    private void MultiplyForDivision(int numFirst, int denomFirst, int numSecond, int denomSecond)
    {
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
    }
    //Overloaded Divides
    public void Divide(int wholeFirst, int numFirst, int denomFirst, int wholeSecond, int numSecond, int denomSecond)
    {
        int tempDenom;
        // Creates 2 improper fractions to multiply for proper results
        numFirst = numFirst + (wholeFirst * denomFirst);
        wholeFirst = 0;
        numSecond = numSecond + (wholeSecond * denomSecond);
        wholeSecond = 0;
        Whole = 0;
        //Inverses second fraction to simply multiply and reuse code from multiply
        //After temp is given back to numSecond a private Multiply function could be used if adding to the stack is of no importance.
        tempDenom = denomSecond;
        denomSecond = numSecond;
        numSecond = tempDenom;
        //Combines the Numerators to pass to Reduce() for a reduced proper fraction
        //MultiplyForDivision(numFirst,denomFirst,numSecond,denomSecond); instead of the next 2 lines
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Could also use Reduce(Numerator, Denominator), but the below code is a bit more clear
        Reduce(Whole, Numerator, Denominator);
    }
    //Overloaded Multiplies 2 numerators and 2 denominators
    public void Divide(int numFirst, int denomFirst, int numSecond, int denomSecond)
    {
        int tempDenom;
        Whole = 0;
        //Inverses second fraction to simply multiply and reuse code from multiply
        //After temp is given back to numSecond a private Multiply function could be used if adding to the stack is of no importance.
        tempDenom = denomSecond;
        denomSecond = numSecond;
        numSecond = tempDenom;
        //Combines the Numerators to pass to Reduce() for a reduced proper fraction
        //MultiplyForDivision(numFirst,denomFirst,numSecond,denomSecond); instead of the next 2 lines
        Numerator = numFirst * numSecond;
        Denominator = denomFirst * denomSecond;
        //Calls Reduce to reduce to proper fraction
        Reduce(Whole, Numerator, Denominator);
    }
    //ReturnFraction() method used to look at current Properties of FractionDemo class and depending on values will return the results in string format
    public string ReturnFraction()
    {
        //Checks for a whole number
        if (Numerator == Denominator)
        {
            //Reduces values to proper fraction
            Reduce(Whole, Numerator, Denominator);
        }
        //Checks to see Whole is not 0 and a valid fraction remains
        if (Whole != 0 && Numerator != 0 && Numerator < Denominator)
        {
            //Ensures fraction is in lowest possible form and proper
            Reduce(Whole, Numerator, Denominator);
            return Whole + " " + Numerator + "/" + Denominator;
         
        }
        //Checks that whole is 0 and that the remaining fraction needs to be reduced
        else if (Whole == 0 && Numerator != 0 && Numerator >= Denominator)
        {
            //Grabs the whole number from the improper fraction and creates
            int temp;
            temp = Numerator;
            //Using Math.Floor to Round Down so that the Whole Number isn't incorrectly rounding up causing incorrect values
            Whole = Convert.ToInt16(Math.Floor(Convert.ToDouble(Convert.ToDouble(Numerator) / Convert.ToDouble(Denominator))));
            //Sets Numerator as the left over from division from Whole and Denominator
            Numerator = Whole % Denominator;
            //Reduces the remaining values and ensures everything was calculated right
            Reduce(Whole, Numerator, Denominator);
            if (Numerator < Denominator)
            {
                return Whole + " " + Numerator + "/" + Denominator;
            }else
            //Used for debugging, I still believe I may have overlooked some logic error, this will remain until more testing is done
            {
                return "Uncalculated Error In Reduce Function Where Numerator is greater than Denominator";
            }
            
        }
        //Checks that whole is 0 and numerator is not 0 then checks for improper fraction
        else if (Whole == 0 && Numerator != 0 && Numerator < Denominator)
        {
            //Reduces the remaining values to ensure  they are in lowest form
            Reduce(Numerator, Denominator);
            //Returns string as Numerator and Denominator
            return Numerator + "/" + Denominator;
        }
        //Since Numerator is 0 the fraction is zero and returns the whole, even if whole is non 0
        else if (Numerator == 0)
        {
            return Convert.ToString(Whole);
        }
        else
        //Anything else
        {
            return Convert.ToString(Whole);
        }
    }
    //Parses the string value to allow for proper mathematical operation in other methods
    private void parseString(string fracFirst, string fracSecond, ref int wholeFirst, ref int numFirst, ref int denomFirst, ref int wholeSecond, ref int numSecond, ref int denomSecond)
    {
        //Looks at the first string Fraction and finds the end index
        int endString = fracFirst.Length;
        //initializes variable to hold spaceIndex if there is a whole number
        int spaceIndex = 0;
        //Checks for space
        if (fracFirst.Contains(" "))
        {
            //Grabs the index of the space
            spaceIndex = fracFirst.IndexOf(" ");
            //Grabs the whole number from the string
            wholeFirst = Convert.ToInt16(fracFirst.Substring(0, spaceIndex)); //parses from index 0 and sets the length of the substring to the spaceIndex
        }
        //Checks for slash
        if (fracFirst.Contains("/"))
        {
            //Grabs the index of the space
            int slashIndex = fracFirst.IndexOf("/");
            //Grabs the numerator from the remaining string
            numFirst = Convert.ToInt16(fracFirst.Substring(spaceIndex, slashIndex - spaceIndex)); //parses from the index of the space and sets the length of the substring to the (slashes index - spaceIndex) ie. The string value from the space to the slash
            //Grabs the denominator from the remaining string
            denomFirst = Convert.ToInt16(fracFirst.Substring(slashIndex + 1, endString - slashIndex - 1)); //parses from the index after the slash and sets the length of the substring to the (end of the string - slashindex - 1) ie. The string value from the slash to the end of the string


        }
        
        //initializes variable to hold spaceIndex if there is a whole number
        int spaceIndex2 = 0;
        //Looks at the first string Fraction and finds the end index
        int endString2 = fracSecond.Length;
        //Checks for space
        if (fracSecond.Contains(" "))
        {
            //Grabs the index of the space
            spaceIndex2 = fracSecond.IndexOf(" ");
            //Grabs the whole number from the string
            wholeSecond = Convert.ToInt16(fracSecond.Substring(0, spaceIndex2));//parses from index 0 and sets the length of the substring to the spaceIndex
        }
        //Checks for slash
        if (fracSecond.Contains("/"))
        {
            //Grabs the index of the space
            int slashIndex2 = fracSecond.IndexOf("/");
            //Grabs the numerator from the remaining string
            numSecond = Convert.ToInt16(fracSecond.Substring(spaceIndex2, slashIndex2 - spaceIndex2));//parses from the index of the space and sets the length of the substring to the (slashes index - spaceIndex) ie. The string value from the space to the slash
            //Grabs the denominator from the remaining string
            denomSecond = Convert.ToInt16(fracSecond.Substring(slashIndex2 + 1, endString2 - slashIndex2 - 1));//parses from the index after the slash and sets the length of the substring to the (end of the string - slashindex - 1) ie. The string value from the slash to the end of the string



        }
    }
    private void parseString(string fracFirst)
    {
        //Looks at the first string Fraction and finds the end index
        int endString = fracFirst.Length;
        //initializes variable to hold spaceIndex if there is a whole number
        int spaceIndex = 0;
        //Checks for space
        if (fracFirst.Contains(" "))
        {
            //Grabs the index of the space
            spaceIndex = fracFirst.IndexOf(" ");
            //Grabs the whole number from the string
            Whole = Convert.ToInt16(fracFirst.Substring(0, spaceIndex));//parses from index 0 and sets the length of the substring to the spaceIndex
        }
        if (fracFirst.Contains("/"))
        {
            //Grabs the index of the space
            int slashIndex = fracFirst.IndexOf("/");
            //Grabs the numerator from the remaining string
            Numerator = Convert.ToInt16(fracFirst.Substring(spaceIndex, slashIndex-spaceIndex));//parses from the index of the space and sets the length of the substring to the (slashes index - spaceIndex) ie. The string value from the space to the slash
            //Grabs the denominator from the remaining string
            Denominator = Convert.ToInt16(fracFirst.Substring(slashIndex + 1, endString - slashIndex - 1));//parses from the index after the slash and sets the length of the substring to the (end of the string - slashindex - 1) ie. The string value from the slash to the end of the string



        }
    }
        

}

/*
Hello and welcome to my very own Fraction class. It is in its infancy and I am creating this class as a bit of a project and to learn hopefully a lot on the way. It started as a project for class, but as I went along I felt there was a lot missing from what the project asked for. Anyway, without further adieu lets explain how this class and these methods are to be used.

The Class is named BARFraction - its my initials (no, all the establishments you see around various towns with 'BAR' on them are not mine, but if you are a BAR owner and would like to extend free drinks my way I will be happy to take part)

EDIT: I just realized I left the class name as Fraction, forget what was said about, aside from the BAR owner part, remember that.


Within this class there are Several Properties that can be called in your project you are including this class in; Whole, Numerator, Denominator.
Whole: pretty self explanatory it is the whole number of the fraction.
Numerator: again explanatory, it is the Numerator of the fraction.
Denominator: "...", it is the Denominator of the fraction.*/


/*Within this class there are Several Methods that can be called in your project that you are including this class in; Add, Subtract, Multiply, Divide, ReturnFraction, MakeImproper, and MakeProper.
Each of the Mathematical Operating Methods include the same number of overloads and essentially function the same way aside from what the Method name hints, which include the following:*/
(int wholeFirst,int numFirst, int denomFirst, int wholeSecond, int numSecond, int denomSecond)
(int numFirst, int denomFirst,  int numSecond, int denomSecond)
(string fracFirst, string fracSecond)

/*The Remaining Methods do not use any overloads and are simply called
i.e. */
ReturnFraction(); /* Will Return the Fraction in a string format i.e. */ 1 1/2; /*If All Have Values*/ 1/2; /*If Whole is Zero*/ 0; /*If Numerator is Zero*/ //Depending on what values are in Whole, Numerator, and Denominator
MakeImproper(); // Will Change the Properties Whole, Numerator, ande Denominator. Adding Whole * Denominator to Numerator and Making Whole = 0
MakeProper(); // Used only when MakeImproper() has been called to revert the Improper fraction back to a proper fraction.
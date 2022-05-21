namespace PrimeCounter
{
	public class PrimeNumber
	{
		//this object holds the total sum, and four component numbers, that make up a valid solution to this problem.

		public long value;
		public long component1;
		public long component2;
		public long component3;
		public long component4;
	}

	public class PrimeCounter
	{
		//Declare our holding pens for these Prime Boys.
		public static List<int> primes = new List<int>();
		//Declare list to hold PrimeNumber objects once they've been made.
		public static List<PrimeNumber> prodList = new List<PrimeNumber>();

		[STAThread]
		static void Main()
		{
			//Load the Primes
			getPrimes();
			//Do a math on those Primes
			getProducts();

		}

		public static void getPrimes()
		{
			//Set a variable to use as a flag later
			int a;

			//Initial for loop, runs from 1 to 1000 to catch all the prime numbers within the expected bounds.
			for (int i = 2; i < 1000; i++)
			{
				//Make sure the flag is reset for every loop.
				a = 0;

				//Sub loop, for each step between 1 to 1000 it will loop through all previous digits and look for divisions.
				for (int j = 1; j <= i; j++)
				{
					if (i % j == 0) //If the first round 'i' can be divided by 'j' with no remainders then increase the flag int by one.
					{
						a++; //This increases with every successful division.
					}
				}
				if (a == 2) //Prime numbers can only be divided by 1 and themselves, which will equal 2 divisions. If this flag matches, then it's a prime.
				{
					primes.Add(i); //Add the prime value to the primes list.
				}
			}

		}

		public static void getProducts()
		{

			//using long values, ints could not handle the larger numbers

			//declare four longs to hold the prime numbers from the list.
			//set default values to avoid any warnings/errors about uninitialised variables.
			long a = 0, b = 0, c = 0, d = 0;

			//Get total number of prime numbers.
			int iterations = primes.Count();
			HashSet<long> sums = new HashSet<long>();
			//Outer Loop to set the first of four components.
			for (int i = 1; i < iterations; i++)
			{
				//Set a to be the first prime number
				a = primes[i];

				//Second loop to set the second component.
				for (int j = 2; j < iterations; j++)
				{
					//set b to be the second prime
					b = primes[j];

					//Third loop, you get one guess what it's for.
					for (int k = 3; k < iterations; k++)
					{
						//third time's the charm
						c = primes[k];

						//Inner Loop to set the fourth component and multiply them together.
						for (int l = 4; l < iterations; l++)
						{
							//I think you know what this is about
							d = primes[l];

							//multiply these prime boys together
							long sum = a * b * c * d;

							//We only interested in 12 digit numbers.
							if (sum.ToString().Length == 12)
							{
								//Break the long 'sum' into it's component digits, as char values.
								char[] charArray = sum.ToString().ToCharArray();
								//declare a bool to use as a simple flag
								bool good = false;

								//loop through the char values, until length - 1 (because we add one later, and the loop breaks if you try to add one more than is available).
								for (int e = 0; e < charArray.Length - 1; e++)
								{
									//check if char E is less than or equal to the character after it. Won't run on the 12th digit (see above) because we're comparing to the right.
									if ((int)charArray[e] <= (int)charArray[e + 1])
									{
										//all is well, please continue
										good = true;
									}
									else
									{
										//the number is no good, scrap it and move on.
										good = false;
										break;
									}

								}

								//if the number is 'good' add it to a hashset
								if (good)
								{
									//if the hashset doesn't already contain the sum
									if (!sums.Contains(sum))
									{
										//jam it in there
										sums.Add(sum);

										//declare a new PrimeNumber object
										PrimeNumber product = new PrimeNumber();
										//Set all it's bits and pieces to match the sum (and component primes) for this loop.
										product.value = sum;
										product.component1 = a;
										product.component2 = b;
										product.component3 = c;
										product.component4 = d;

										//Add it to the list of prime objects
										prodList.Add(product);

										//Output valid results to the Console window.
										Console.WriteLine(product.value + " " + product.component1 + " " + product.component2 + " " + product.component3 + " " + product.component4);
									}
								}
							}
						}
					}
				}
			}

			//Final count
			Console.WriteLine("There are " + prodList.Count + " valid solutions to this problem.");
		}
	}
}



using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace algorithm
{
	class Program
	{
		static async System.Threading.Tasks.Task Main(string[] args)
		{
			//open test file connection
			StreamWriter streamWriter = new("Results.csv", append: true);
			using StreamWriter file = streamWriter;
			await file.WriteLineAsync("new test");
			int i = 0;
			int j = 0;
			int[] sizes = new int[] { 100, 200, 500, 800 , 1024, 2048};
			do
			{
				Console.WriteLine("\n Step number: "+i+" \n");
				//generate numbers
				int[] list = Enumerable.Range(1, sizes[j])
					.Select(x => x * x).ToArray();
				//print numbers
				Console.WriteLine("{0}", string.Join(", ", list));

				//target:
				Random rnd = new Random();
				int n = rnd.Next(1, sizes[j]);
				int k = list[n];


				//execute all searches:
				int index = InterpolationSrch(list, k);
				string text = Convert.ToString(index);

				index =  BinarySrch(list, k);
				text = text+","+Convert.ToString(index);
				 
				index = iteratedsearches(list, k);
				text = text + "," + Convert.ToString(index);
				//copy results in file
				await file.WriteLineAsync(text);
				
				i++;j++;
				
			} while (i <= sizes.Length -1);
		}


		public static int InterpolationSrch(int[] list, int k)
		{
			Console.Write("Interpolation search:\n");
			int bottom = 0;
			int mid = -1;
			int top = list.Length - 1;
		
			int counter = 1; //number of steps

			while (bottom <= top) 
			{// interpolation formula
				mid = (int)(bottom +(((double)(top - bottom) / 
					(list[top] - list[bottom])) * (k - list[bottom]))); 
				//if prediction is correct
				if (list[mid] == k) 
				{
					Console.WriteLine("found at step: " + counter 
						+ " prediction index: "+ mid
						+ " value: " + list[(int)mid]);
					break;
				}//if searched in all array then unsuccessful
				else if (counter == top) 
				{
					Console.WriteLine("Search unsuccessfull");
					break;
				}//if prediction was wrong 
				else 
				{
					if (list[mid] < k)
					{ // if prediction is smaller then target
						bottom = mid + 1; // prediction become bottom
					}
					else //if prediction is greater 
					{
						top = mid - 1; //top becomes top
					}
				}
				Console.WriteLine("step: " + counter 
					+ " prediction: " +mid
					+ " value: " + list[(int)mid]);
				counter++;
			}

			return counter;
		}

		public static int BinarySrch(int[] list, int k)
		{
			Console.Write("\nBinary search:\n");
			
			int counter = 1;
			int bottom = 0;
			int top = list.Length - 1;
			//find middle of array 
            double tempMid = top / 2;
            double mid = (int)Math.Ceiling(tempMid); 
			//while result is not found or bottom is minor then top
            while (list[(int)mid] != k || bottom <= top) 
            {
				// if prediction is right 
                if (list[(int)mid] == k) 
                {
                    Console.WriteLine("found at step: " + counter 
						+ " prediction: " + mid 
						+ " value: " + list[(int)mid]);
                    
                    break;
                }//if target is smaller then prediction
				//then prediction -1 becames top 
                else if (k < list[(int)mid]) 
				{
					top = (int)mid - 1;
				} 
				// stop if search is unsuccessful
                else if (counter == top) 
				{
					Console.WriteLine("Search unsuccessfull");
					break; 
				}  
				//if target is greater then prediction
				//bottom becames prediction+1
                else {bottom = (int)mid + 1;} 

				mid = (bottom + top) / 2; // find new middle 
                Console.WriteLine("step: " + counter +
					" middle: " + mid 
					+ " value: " + list[(int)mid]);
                counter++;
            }
            return counter;
		}

		public static int iteratedsearches(int[] list, int k)
		{
			Console.Write("\nITERATED SEARCH\n");
			

			
			int bottom = 0;
			int mid = -1;
			int top = list.Length - 1;
			int counter = 1;
			

			while (bottom <= top)
			{
				int percent = ((top -bottom)* 25) / 100;

				Console.Write("Interpolation search:\n");
				//interpolation formula
				mid = (int)(bottom + (((double)(top - bottom) / 
					(list[top] - list[bottom])) * (k - list[bottom])));

				if (list[mid] == k) //if prediction is correct
				{
					Console.WriteLine("found at step: " + counter 
						+ " prediction: " + mid 
						+ " Value: " + list[mid]);
					
					break;
				}
				else if (counter == top)
				{
					Console.WriteLine("Search unsuccessfull");
					break;
				}
				else
				{//if prediction is smaller then k 
					if (list[mid] < k)
                    {
						bottom = mid + 1;
                    }

                    else
                    {
						top = mid - 1;
                    }
						
					Console.WriteLine("step: " + counter
						+ " prediction: " + mid
						+" Value: "+ list[mid]);
				}
				 if ((list.Length - top + bottom) < percent) 
				{// if it's a bad prediction 

					Console.WriteLine("items removerd / min item to remove : " 
						+ (list.Length - top + bottom) + " / " + percent);
					Console.WriteLine("this is a bad prediction," +
						" binary search will start");
					counter++;
					Console.Write("Binary search:\n");
					//find middle
					double tempmid = ((top - bottom) / 2)+ bottom; 

					double middle = Math.Ceiling(tempmid);
					//if target is found
					if (list[(int)middle] == k)
					{
						Console.WriteLine("found at step: " 
							+ counter 
							+ " prediction: " + middle 
							+ " value: " + list[(int)middle]);
						break;
					}//if target is smaller then middle
					//middle +1 is new top
					else if (k < list[(int)middle])
					{
						top = (int)middle - 1;
						middle = Math.Floor(middle / 2 + bottom);
					}//if target is larger then middle
					 //middle -1 is new top
					else
					{
						bottom = (int)middle + 1;
						double lenght = (middle + top) / 2;
						middle = Math.Ceiling(lenght);
     				}

					Console.WriteLine("step: " + counter
						+ " middle: " + middle);
                }
                counter++;
			}
			return counter;
		}
	}
}




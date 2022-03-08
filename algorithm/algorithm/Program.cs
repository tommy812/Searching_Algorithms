using System;
using System.Collections.Generic;
using System.Linq;

namespace algorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] list = new int[] {  1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14,  29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99 };
			Console.WriteLine("{0}", string.Join(", ", list));
			string option;
			//do
			//{
				Console.WriteLine("\n Insert 1 to start;\nSelect 2 to end");
				option = Console.ReadLine(); 
				switch (option)
				{
					case "1":
						Console.WriteLine("Insert target");
						//int k = Console.Read();
						int k = 10;
						int index = InterpolationSrch(list, k);
						index = BinarySrch(list, k);
						//index = CombinedSrch(list, k);
						index = iteratedsearches(list, k);
						//Console.WriteLine(index);
						break;
					case "2":
						Console.WriteLine("bye bye");
						break;
				}
			//} while (option != "2");

			
		}


		public static int InterpolationSrch(int[] list, int k)
		{
			Console.Write("Interpolation search:\n");
			int bottom = 0;
			int mid = -1;
			int top = list.Length - 1;
			int index = -1;
			int counter = 1;

			while (bottom <= top)
			{
				mid = (int)(bottom + (((double)(top - bottom) / (list[top] - list[bottom])) * (k - list[bottom])));

				//mid = (top - bottom) * ((k - list[bottom]) / (list[top] - list[bottom])) + bottom;

				if (list[mid] == k)
				{
					Console.WriteLine("found at step: " + counter + " prediction: " + mid+ " value: " + list[(int)mid]);
					index = mid;
					break;
				}
				else
				{
					if (list[mid] < k)
						bottom = mid + 1;
					else
						top = mid - 1;
				}
				Console.WriteLine("step: " + counter + " prediction: " +mid + " value: " + list[(int)mid]);
				counter++;
			}

			return index;
		}

		public static int BinarySrch(int[] list, int k)
		{
			Console.Write("\nBinary search:\n");
			int index = -1;
			int counter = 1;
			int bottom = 0;
			int top = list.Length - 1;
			double tempMid = (list.Length - 1) / 2;
			double mid = (int)Math.Ceiling(tempMid);

			while (bottom <= top)
			{
				
				if (list[(int)mid] == k)
				{
					Console.WriteLine("found at step: " + counter + " prediction: " + mid + " value: " + list[(int)mid]);
					index = (int)mid;
					break;
				}
				else if (k < list[(int)mid])
				{


					top = (int)mid - 1;
					mid = Math.Floor(mid / 2);
				}
				else
				{
					bottom = (int)mid + 1;
					double lenght = (mid + top) / 2;
					mid = Math.Ceiling(lenght);
				}

				Console.WriteLine("step: " + counter + " middle: " + mid);
				counter++;
			}
			return index;
		}


		public static int CombinedSrch(int[] list, int k)
		{
			Console.Write("\nCOMBINED SEARCH\n");
			int index = -1;

			Console.Write("\nInterpolation search:\n");
			int bottom = 0;
			int mid = -1;
			int top = list.Length - 1;
			int counter = 1;
			int percent = (top * 25) / 100;

			while (bottom <= top)
			{
				mid = (int)(bottom + (((double)(top - bottom) / (list[top] - list[bottom])) * (k - list[bottom])));

				//mid = (top - bottom) * ((k - list[bottom]) / (list[top] - list[bottom])) + bottom;

				if (list[mid] == k)
				{
					Console.WriteLine("found at step: " + counter + " prediction: " + mid);
					index = mid;
					break;
				}
				else if(bottom < percent){

					Console.WriteLine("step: " + counter + " prediction: " + mid+"; position / min position : "+bottom+" / "+percent);
					Console.WriteLine("this is a bad prediction, binary search will start\n");
					counter++;
					break;
                }
				else
				{
					if (list[mid] < k)
						bottom = mid + 1;
					else
						top = mid - 1;
				}
				Console.WriteLine("step: " + counter + " prediction: " + mid);
				counter++;
			}

			if (index == -1)
			{
				Console.Write("Binary search:\n");
				double tempMid = (list.Length - 1) / 2;
				double middle = (int)Math.Ceiling(tempMid);

				while (bottom <= top)
				{
					Console.WriteLine(" value: " + list[(int)middle]);
					if (list[(int)middle] == k)
					{
						Console.WriteLine("found at step: " + counter + " prediction: " + middle + " value: " + list[(int)middle]);
						index = (int)middle;
						break;
					}
					else if (k < list[(int)middle])
					{


						top = (int)middle - 1;
						middle = Math.Floor(middle / 2);
					}
					else
					{
						bottom = (int)middle + 1;
						double lenght = (middle + top) / 2;
						middle = Math.Ceiling(lenght);
					}

					Console.WriteLine("step: " + counter + " middle: " + middle);
					counter++;
					//if (counter == 5)
     //               {
					//	break;
     //               }
				}
			}

			return index;
		}


		public static int iteratedsearches(int[] list, int k)
		{
			Console.Write("\nITERATED SEARCH\n");
			int index = -1;

			
			int bottom = 0;
			int mid = -1;
			int top = list.Length - 1;
			int counter = 1;
			

			while (bottom <= top)
			{
				int percent = ((top -bottom)* 25) / 100;

				Console.Write("\nInterpolation search:\n");
				//mid = (int)(bottom + (((double)(top - bottom) / (list[top] - list[bottom])) * (k - list[bottom])));

				mid = (top - bottom) * ((k - list[bottom]) / (list[top] - list[bottom])) + bottom;

				if (list[mid] == k)
				{
					Console.WriteLine("found at step: " + counter + " prediction: " + mid + " Value: " + list[mid]);
					index = mid;
					break;
				}else
				{
					if (list[mid] < k)
						bottom = mid + 1;
					else
						top = mid - 1;
					Console.WriteLine("step: " + counter + " prediction: " + mid+" Value: "+ list[mid]);
				}
				 if ((list.Length - top + bottom) < percent)
				{

					Console.WriteLine("items removerd / min item to remove : " + (list.Length - top + bottom) + " / " + percent);
					Console.WriteLine("this is a bad prediction, binary search will start\n");
					counter++;
					Console.Write("Binary search:\n");
					double tempmid = (bottom + top) / 2;
					double middle = Math.Ceiling(tempmid);

					if (list[(int)middle] == k)
					{
						Console.WriteLine("found at step: " + counter + " prediction: " + middle + " value: " + list[(int)middle]);
						index = (int)middle;
						break;
					}
					else if (k < list[(int)middle])
					{
						top = (int)middle - 1;
						middle = Math.Floor(middle / 2);
					}
					else
					{
						bottom = (int)middle + 1;
						double lenght = (middle + top) / 2;
						middle = Math.Ceiling(lenght);
					}

					Console.WriteLine("step: " + counter + " middle: " + middle);

                    

                }
                counter++;
			}
			return index;
		}
	}
}




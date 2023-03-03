public class Program
{
    public static void Main()
    {

        //-------------------------------- Problem 1 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m=Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter array 2 Size:");
        //int n=Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //int[] b = new int[n];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i]=Convert.ToInt32(Console.ReadLine());
        //}
        //Console.WriteLine("Enter array 2 elements :");
        //for (int i = 0; i < n; i++)
        //{
        //    b[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //Array.Sort(a);
        //Array.Sort(b);
        //int s = m+n;
        //int[] merged= new int[s];
        //for (int j=0, i = 0; i < s; i++)
        //{
        //    if (i < m)
        //    {
        //        merged[i] = a[i];
        //    }
        //    if(i==m || i>m)
        //    {
        //        merged[i] = b[j];
        //        j++;
        //    }
        //}

        //for (int i = 0; i < s; i++)
        //{
        //    Console.WriteLine(" "+merged[i]+" ");
        //}

        //-------------------------------- Problem 2 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //int j = 0;
        //int[] b= new int[m];
        //for (int i = 0; i < m-1; i++)
        //{
        //    if (a[i] != a[i + 1])
        //    {
        //        b[j++] = a[i];
        //    }
        //}
        //b[j++] = a[m-1];
        //for (int i = 0; i < j; i++)
        //{
        //    a[i] = b[i];
        //}
        //for(int i=0;i<j;i++) 
        //{
        //    Console.Write("" + b[i] + " ");
        //}


        //-------------------------------- Problem 3 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}

        //bool[] v = new bool[m];
        //for (int i = 0; i < m; i++)
        //{
        //    if (v[i] == true)
        //        continue;
        //    int count = 1;
        //    for (int j = i + 1; j < m; j++)
        //    {
        //        if (a[i] == a[j])
        //        {
        //            v[j] = true;
        //            count++;
        //        }
        //    }
        //    Console.WriteLine("Element "+a[i] + " Count " + count);
        //}

        //-------------------------------- Problem 4 --------------------------------

        //Console.WriteLine("Enter the Size:");
        //int n = Convert.ToInt32(Console.ReadLine());
        //int[] array = new int[n];
        //int c = 0;
        //Console.WriteLine("Enter the Sum Value");
        //int X = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter Array Elements");
        //for (int i = 0; i < n; i++)
        //{
        //    array[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //Console.WriteLine("Triplets are: ");
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = i + 1; j < n; j++)
        //    {
        //        if (array[i] + array[j] == X)
        //        {
        //            c++;
        //            Console.WriteLine("[ " + array[i] + " " + array[j] + " ]");
        //            Console.WriteLine("[ " + array[j] + " " + array[i] + " ]");
        //        }
        //    }
        //}

        //-------------------------------- Problem 5 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //int maxi=0,min=0;
        //for (int i = 0; i < m-1; i++)
        //{
        //    if (a[i] > maxi)
        //    {
        //        maxi = a[i];
        //    }
        //}
        //for(int i = 0; i < m - 1; i++)
        //{
        //    if (a[i] < min)
        //    {
        //        min = a[i];
        //    }
        //}
        //Console.WriteLine("Maximum : "+maxi+"\nMinimum : "+min);

        //-------------------------------- Problem 6 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine("Enter element to be searched:");
        //int k = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //for (int i = 0; i < m; i++)
        //{
        //    if (a[i]==k)
        //    {
        //        Console.WriteLine(i);
        //        break;
        //    }
        //    else if (a[i]>k)
        //    {
        //        Console.WriteLine(i);
        //        break;
        //    }
        //}

        //-------------------------------- Problem 7 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //Array.Sort(a);
        //int t = a[m-3];
        //Console.WriteLine("The third largest element is : "+ t);

        //-------------------------------- Problem 8 --------------------------------

        //Console.WriteLine("Enter array 1 Size:");
        //int m = Convert.ToInt32(Console.ReadLine());
        //int[] a = new int[m];
        //int[] b = new int[m];
        //int k = 0;
        //Console.WriteLine("Enter array 1 elements :");
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //Console.WriteLine("Enter rotating positions");
        //int n = Convert.ToInt32(Console.ReadLine());
        //for (int i = n; i < m; i++)
        //{
        //    b[k] = a[i];
        //    k++;
        //}
        //for (int j = 0; j < n; j++)
        //{
        //    b[k] = a[j];
        //    k++;
        //}
        //for (int i = 0; i < m; i++)
        //{
        //    a[i] = b[i];
        //}
        //for (int i = 0; i < m; i++)
        //{
        //    Console.Write(" " + a[i] + " ");
        //}

        //-------------------------------- Problem 9 --------------------------------

        //Console.WriteLine("Enter the Size:");
        //int n = Convert.ToInt32(Console.ReadLine());
        //int[] array = new int[n];
        //int c = 0;
        //Console.WriteLine("Enter Array Elements");
        //for (int i = 0; i < n; i++)
        //{
        //    array[i] = Convert.ToInt32(Console.ReadLine());
        //}
        //int MaxSum=int.MinValue;
        //int x = 0, y = 0, z = 0 ;
        //Console.WriteLine("Triplets are: ");
        //for (int i = 0; i < n; i++)
        //{
        //    for (int j = i + 1; j < n; j++)
        //    {
        //        for (int k = j + 1; k < n; k++)
        //        {
        //            if(array[i] * array[j] * array[k] > MaxSum)
        //            {
        //                MaxSum= array[i] * array[j]* array[k];
        //                x = array[i];
        //                y= array[j];
        //                z = array[k];
        //            }
        //        }
        //    }
        //}
        //Console.WriteLine(x + " " + y + " " + z);

        //---------------------------- Array Completed ---------------------------------
        
    }
}

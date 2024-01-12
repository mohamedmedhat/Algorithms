using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _Algorithms_
{
// SelectionSort
class SelectionSort
{
private static SelectionSort instance;
private static readonly object padlock = new object();

private SelectionSort() { }

public static SelectionSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new SelectionSort();
}
return instance;
}
}
public void help()
{
Console.WriteLine("Selection Sort is a simple sorting algorithm that repeatedly selects the minimum element from an unsorted portion of the array and places it at the beginning of the sorted portion. The algorithm maintains two subarrays within the array: the sorted subarray at the beginning and the unsorted subarray at the end. In each iteration, it finds the smallest element from the unsorted subarray and swaps it with the first unsorted element.\r\n\r\nThe steps of the Selection Sort algorithm are as follows:\r\n\r\nSet the first element as the minimum.\r\nCompare this minimum element with the other elements in the array.\r\nIf a smaller element is found, update the minimum element.\r\nSwap the minimum element with the first unsorted element.\r\nRepeat this process for the remaining unsorted portion of the array.");
}
public static void Sort(int[] arr)
{
int n = arr.Length;

for (int i = 0; i < n - 1; i++)
{
int minIndex = i;

// Find the index of the minimum element in the unsorted portion
for (int j = i + 1; j < n; j++)
{
if (arr[j] < arr[minIndex])
{
minIndex = j;
}
}

// Swap the found minimum element with the first unsorted element
int temp = arr[minIndex];
arr[minIndex] = arr[i];
arr[i] = temp;
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//BubbleSort
class BubbleSort
{
public void help()
{
Console.WriteLine("Bubble Sort is a simple sorting algorithm that repeatedly steps through the list, compares adjacent elements, and swaps them if they are in the wrong order. The pass-through is repeated for the entire list until no more swaps are needed, indicating that the list is sorted.\r\n\r\nThe steps of the Bubble Sort algorithm are as follows:\r\n\r\nStart at the beginning of the array.\r\nCompare the current element with the next element.\r\nIf the current element is greater than the next element, swap them.\r\nMove to the next pair of elements and repeat steps 2 and 3.\r\nContinue this process for all elements in the array until no more swaps are needed.");
}
public static void Sort(int[] arr)
{
int n = arr.Length;
bool swapped;

for (int i = 0; i < n - 1; i++)
{
swapped = false;

// Last i elements are already in place, so no need to check them
for (int j = 0; j < n - i - 1; j++)
{
if (arr[j] > arr[j + 1])
{
// Swap arr[j] and arr[j + 1]
int temp = arr[j];
arr[j] = arr[j + 1];
arr[j + 1] = temp;

swapped = true; // Set swapped to true to indicate a swap occurred
}
}

// If no two elements were swapped in the inner loop, the array is sorted
if (!swapped)
break;
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


// InsertionSort
class InsertionSort
{
private static InsertionSort instance;
private static readonly object padlock = new object();

private InsertionSort() { }

public static InsertionSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new InsertionSort();
}
return instance;
}
}
public void help()
{
Console.WriteLine("Insertion Sort is a simple sorting algorithm that builds the final sorted array one item at a time. It works by taking an element from the unsorted part of the array and inserting it into its correct position within the sorted part of the array. The algorithm maintains a sorted subarray at the beginning of the array and gradually expands this subarray by adding one element at a time from the unsorted part.\r\n\r\nThe steps of the Insertion Sort algorithm are as follows:\r\n\r\nStart with the second element in the array (considering the first element as already sorted).\r\nCompare this element with the elements in the sorted subarray, moving larger elements to the right to make space for the current element.\r\nInsert the current element into its correct position in the sorted subarray.\r\nRepeat steps 2 and 3 for the remaining elements in the unsorted part of the array.");
}
public static void Sort(int[] arr)
{
int n = arr.Length;

for (int i = 1; i < n; i++)
{
int key = arr[i];
int j = i - 1;

// Move elements of arr[0..i-1], that are greater than key, to one position ahead of their current position
while (j >= 0 && arr[j] > key)
{
arr[j + 1] = arr[j];
j--;
}

arr[j + 1] = key;
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//CountSort
class CountingSort
{
private static CountingSort instance;
private static readonly object padlock = new object();

private CountingSort() { }

public static CountingSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new CountingSort();
}
return instance;
}
}
public void help()
{
Console.WriteLine("Counting Sort is an efficient, non-comparison-based sorting algorithm that works well for a specific range of integer elements. It operates by counting the occurrences of each distinct element in the input array, creating a count array, and then using this information to place elements in their correct sorted positions.\r\n\r\nThe steps of the Counting Sort algorithm are as follows:\r\n\r\nFind the range of input elements (minimum and maximum values).\r\nCreate a count array to store the count of each element. The size of this count array should be (max - min + 1).\r\nTraverse the input array and count the occurrences of each element, storing the counts in the count array.\r\nModify the count array to store the cumulative count of each element. This step helps in determining the positions of elements in the sorted array.\r\nIterate through the original array and place each element in its correct sorted position based on the count array.\r\nDecrement the count of each element in the count array to handle duplicate elements.\r\nThe sorted array is obtained after this process.");
}
public static void Sort(int[] arr)
{
int n = arr.Length;

// Find the maximum and minimum elements in the array
int min = arr[0];
int max = arr[0];
for (int i = 1; i < n; i++)
{
if (arr[i] < min)
min = arr[i];
if (arr[i] > max)
max = arr[i];
}

// Create a count array to store the count of each element
int[] count = new int[max - min + 1];

// Store the count of each element in the count array
for (int i = 0; i < n; i++)
{
count[arr[i] - min]++;
}

// Modify the count array to store cumulative count
for (int i = 1; i < count.Length; i++)
{
count[i] += count[i - 1];
}

// Create a temporary array to store the sorted elements
int[] output = new int[n];

// Place elements in their correct sorted positions
for (int i = n - 1; i >= 0; i--)
{
output[count[arr[i] - min] - 1] = arr[i];
count[arr[i] - min]--;
}

// Copy the sorted elements from the output array to the original array
for (int i = 0; i < n; i++)
{
arr[i] = output[i];
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//QuickSort
class QuickSort
{
private static QuickSort instance;
private static readonly object padlock = new object();

private QuickSort() { }

public static QuickSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new QuickSort();
}
return instance;
}
}
public void help()
{
Console.WriteLine("Quick Sort is a highly efficient and widely used sorting algorithm based on the divide-and-conquer strategy. It works by selecting a 'pivot' element from the array and partitioning the other elements into two sub-arrays according to whether they are less than or greater than the pivot. The process is then applied recursively to the sub-arrays.\r\n\r\nThe steps of the Quick Sort algorithm are as follows:\r\n\r\nSelect a pivot element from the array (usually the last element in the array).\r\nPartition the array into two sub-arrays:\r\nElements less than the pivot (left side of the pivot).\r\nElements greater than the pivot (right side of the pivot).\r\nRecursively apply the same process to the left and right sub-arrays until the entire array is sorted.");
}
public static void Sort(int[] arr, int low, int high)
{
if (low < high)
{
// Partition the array and get the index of the pivot element
int pivotIndex = Partition(arr, low, high);

// Recursively sort elements before and after the pivot
Sort(arr, low, pivotIndex - 1);
Sort(arr, pivotIndex + 1, high);
}
}

public static int Partition(int[] arr, int low, int high)
{
int pivot = arr[high]; // Choose the last element as pivot
int i = low - 1;

for (int j = low; j < high; j++)
{
// If current element is smaller than or equal to the pivot
if (arr[j] <= pivot)
{
i++;
// Swap arr[i] and arr[j]
int temp = arr[i];
arr[i] = arr[j];
arr[j] = temp;
}
}

// Swap arr[i + 1] and arr[high] (pivot)
int tempSwap = arr[i + 1];
arr[i + 1] = arr[high];
arr[high] = tempSwap;

return i + 1; // Return the partitioning index
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//MergeSort
class MergeSort
{
private static MergeSort instance;
private static readonly object padlock = new object();

private MergeSort() { }

public static MergeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new MergeSort();
}
return instance;
}
}
public void help()
{
Console.WriteLine("Merge Sort is a divide-and-conquer-based sorting algorithm that divides the unsorted array into smaller sub-arrays, sorts those sub-arrays recursively, and then merges them back together to create a sorted array.\r\n\r\nThe steps of the Merge Sort algorithm are as follows:\r\n\r\nDivide: Divide the unsorted array into two halves.\r\nConquer: Recursively sort the two halves.\r\nMerge: Merge the sorted halves to produce the final sorted array.\r\nHere's an explanation of the Merge Sort algorithm:\r\n\r\nDivide: The unsorted array is divided into two halves until each sub-array has only one element, which is inherently sorted.\r\nConquer: The sorting process begins when the recursion starts merging the smaller sorted arrays into larger sorted arrays.\r\nMerge: The merge operation combines two sorted arrays into a single sorted array. It repeatedly compares the elements from both arrays, placing the smaller (or larger, for descending order) element into the final merged array.");
}

public static void Sort(int[] arr, int left, int right)
{
if (left < right)
{
int mid = left + (right - left) / 2;

// Sort the first and second halves
Sort(arr, left, mid);
Sort(arr, mid + 1, right);

// Merge the sorted halves
Merge(arr, left, mid, right);
}
}

public static void Merge(int[] arr, int left, int mid, int right)
{
int n1 = mid - left + 1;
int n2 = right - mid;

int[] leftArray = new int[n1];
int[] rightArray = new int[n2];

// Copy data to temp arrays
for (int i = 0; i < n1; ++i)
leftArray[i] = arr[left + i];
for (int j = 0; j < n2; ++j)
rightArray[j] = arr[mid + 1 + j];

// Merge the temp arrays
int iIndex = 0, jIndex = 0;
int k = left;
while (iIndex < n1 && jIndex < n2)
{
if (leftArray[iIndex] <= rightArray[jIndex])
{
arr[k] = leftArray[iIndex];
iIndex++;
}
else
{
arr[k] = rightArray[jIndex];
jIndex++;
}
k++;
}

// Copy remaining elements of leftArray[], if any
while (iIndex < n1)
{
arr[k] = leftArray[iIndex];
iIndex++;
k++;
}

// Copy remaining elements of rightArray[], if any
while (jIndex < n2)
{
arr[k] = rightArray[jIndex];
jIndex++;
k++;
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

//HeapSort
public class HeapSort
{
private static HeapSort instance;
private static readonly object padlock = new object();

private HeapSort() { }

public static HeapSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new HeapSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Heap Sort isn't inherently a straightforward algorithm to parallelize due to its sequential nature, especially during the heap creation phase and the sorting process. However, an approach to utilize multithreading could be dividing the array into smaller parts and building heaps separately for each section in parallel before performing the final merge.\r\n\r\nHere's an example of Heap Sort with multithreading (although the effectiveness might be limited due to the nature of the algorithm");
}

public void Sort(int[] arr, int numThreads)
{
int len = arr.Length;
Thread[] threads = new Thread[numThreads];

int segmentSize = len / numThreads;

for (int i = 0; i < numThreads; i++)
{
int start = i * segmentSize;
int end = (i == numThreads - 1) ? len - 1 : (i + 1) * segmentSize - 1;

threads[i] = new Thread(() => Heapify(arr, start, end));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

for (int i = len / 2 - 1; i >= 0; i--)
{
Heapify(arr, len, i);
}

for (int i = len - 1; i >= 0; i--)
{
int temp = arr[0];
arr[0] = arr[i];
arr[i] = temp;

Heapify(arr, i, 0);
}
}

private void Heapify(int[] arr, int n, int i)
{
int largest = i;
int left = 2 * i + 1;
int right = 2 * i + 2;

if (left < n && arr[left] > arr[largest])
{
largest = left;
}

if (right < n && arr[right] > arr[largest])
{
largest = right;
}

if (largest != i)
{
int temp = arr[i];
arr[i] = arr[largest];
arr[largest] = temp;

Heapify(arr, n, largest);
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//RadixSort
public class RadixSort
{
private static RadixSort instance;
private static readonly object padlock = new object();

private RadixSort() { }

public static RadixSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new RadixSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Radix Sort is a sorting algorithm suitable for parallelization because it processes the elements in the input array based on their individual digits or characters. This property allows the algorithm to be parallelized effectively by sorting each digit or character separately in different threads.");
}

public void Sort(int[] arr, int numThreads)
{
int maxVal = FindMaxValue(arr);
int numDigits = GetNumDigits(maxVal);

for (int digit = 0; digit < numDigits; digit++)
{
Thread[] threads = new Thread[10]; // 10 threads for 10 digits (0-9)

for (int i = 0; i < 10; i++)
{
int d = i; // capture variable to pass in thread

threads[i] = new Thread(() => CountingSortByDigit(arr, d, digit));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private void CountingSortByDigit(int[] arr, int digit, int currentDigit)
{
int[] output = new int[arr.Length];
int[] count = new int[10];

for (int i = 0; i < arr.Length; i++)
{
int d = GetDigit(arr[i], currentDigit);
if (d == digit)
{
count[d]++;
}
}

for (int i = 1; i < 10; i++)
{
count[i] += count[i - 1];
}

for (int i = arr.Length - 1; i >= 0; i--)
{
int d = GetDigit(arr[i], currentDigit);
if (d == digit)
{
output[count[d] - 1] = arr[i];
count[d]--;
}
}

for (int i = 0; i < arr.Length; i++)
{
if (GetDigit(arr[i], currentDigit) == digit)
{
arr[i] = output[i];
}
}
}

private int FindMaxValue(int[] arr)
{
int max = arr[0];
for (int i = 1; i < arr.Length; i++)
{
if (arr[i] > max)
{
max = arr[i];
}
}
return max;
}

private int GetNumDigits(int number)
{
return number == 0 ? 1 : (int)Math.Floor(Math.Log10(number) + 1);
}

private int GetDigit(int number, int digit)
{
return (int)(number / Math.Pow(10, digit)) % 10;
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BucketSort
public class BucketSort
{
private static BucketSort instance;
private static readonly object padlock = new object();

private BucketSort() { }

public static BucketSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BucketSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Bucket Sort, similar to Radix Sort, is conducive to parallelization due to its division of elements into buckets. Each bucket can be sorted independently, allowing for parallel processing");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;
List<int>[] buckets = new List<int>[n];

for (int i = 0; i < n; i++)
{
buckets[i] = new List<int>();
}

int maxValue = FindMaxValue(arr);

for (int i = 0; i < n; i++)
{
int bucketIndex = (arr[i] * n) / (maxValue + 1);
buckets[bucketIndex].Add(arr[i]);
}

Thread[] threads = new Thread[n];

for (int i = 0; i < n; i++)
{
threads[i] = new Thread(() => SortBucket(buckets[i]));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

int index = 0;
for (int i = 0; i < n; i++)
{
foreach (var item in buckets[i])
{
arr[index++] = item;
}
}
}

private void SortBucket(List<int> bucket)
{
bucket.Sort();
}

private int FindMaxValue(int[] arr)
{
int max = arr[0];
for (int i = 1; i < arr.Length; i++)
{
if (arr[i] > max)
{
max = arr[i];
}
}
return max;
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BingoSort
public class BingoSort
{
private static BingoSort instance;
private static readonly object padlock = new object();

private BingoSort() { }

public static BingoSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BingoSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Bingo Sort, also known as the \"Stupid Sort,\" is a highly inefficient sorting algorithm that continuously shuffles the array until it becomes sorted. Due to its nature of repeatedly shuffling, it isn't suitable for parallelization, especially in the context of multithreading.\r\n\r\nThe process of continuously shuffling the array until it's sorted doesn't lend itself well to parallelization, as each shuffle operation is dependent on the previous state of the array. Additionally, using multiple threads to shuffle the array simultaneously could result in race conditions and unpredictable behavior, making the algorithm's effectiveness even worse.");
}
public void Sort(int[] arr)
{
Random rnd = new Random();

while (!IsSorted(arr))
{
for (int i = 0; i < arr.Length; i++)
{
int randomIndex = rnd.Next(arr.Length);
int temp = arr[i];
arr[i] = arr[randomIndex];
arr[randomIndex] = temp;
}
}
}

private bool IsSorted(int[] arr)
{
for (int i = 0; i < arr.Length - 1; i++)
{
if (arr[i] > arr[i + 1])
{
return false;
}
}
return true;
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//ShellSort
public class ShellSort
{
private static ShellSort instance;
private static readonly object padlock = new object();

private ShellSort() { }

public static ShellSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new ShellSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Shell Sort, also known as the diminishing increment sort, is an in-place comparison sort that starts by sorting pairs of elements far apart from each other, then progressively reducing the gap between elements to be compared. Parallelizing Shell Sort can be a bit tricky due to its step-wise nature, as each step depends on the previous one. However, an attempt can be made by dividing the array into segments and then sorting each segment concurrently in separate threads.");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

for (int gap = n / 2; gap > 0; gap /= 2)
{
Thread[] threads = new Thread[numThreads];

for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => SortSegment(arr, threadIndex, numThreads, gap));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private void SortSegment(int[] arr, int start, int step, int gap)
{
for (int i = start + gap; i < arr.Length; i += step)
{
int temp = arr[i];
int j;
for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
{
arr[j] = arr[j - gap];
}
arr[j] = temp;
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//ODDEVENSORT

public class OddEvenSort
{
private static OddEvenSort instance;
private static readonly object padlock = new object();

private OddEvenSort() { }

public static OddEvenSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new OddEvenSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("The Odd-Even Sort is a relatively simple sorting algorithm that iterates through the array and compares adjacent elements, swapping them if they are in the wrong order. The algorithm continues this process in alternating odd and even phases until the array is sorted. However, parallelizing Odd-Even Sort is challenging due to its dependency on the previous iteration's results.");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

for (int phase = 0; phase < n; phase++)
{
Thread[] threads = new Thread[numThreads];

for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => OddEvenSortSegment(arr, threadIndex, numThreads, phase));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private void OddEvenSortSegment(int[] arr, int start, int step, int phase)
{
int n = arr.Length;
for (int i = start + phase; i < n - 1; i += step)
{
if (i % 2 == 0) // even phase
{
if (arr[i] > arr[i + 1])
{
int temp = arr[i];
arr[i] = arr[i + 1];
arr[i + 1] = temp;
}
}
else // odd phase
{
if (i < n - 1 && arr[i] > arr[i + 1])
{
int temp = arr[i];
arr[i] = arr[i + 1];
arr[i + 1] = temp;
}
}
}
}


//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BrickSort
public class BrickSort
{
private static BrickSort instance;
private static readonly object padlock = new object();

private BrickSort() { }

public static BrickSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BrickSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Brick Sort, also known as Odd-Even Sort or Cocktail Sort, is a variation of the Bubble Sort algorithm. It sorts the array by comparing adjacent elements in two directions: first, from left to right, then from right to left. This process continues until the array is sorted.\r\n\r\nImplementing multi-threading for Brick Sort involves dividing the array into segments and sorting each segment concurrently using multiple threads. However, parallelizing Brick Sort is challenging due to its dependency on previous iterations and the nature of its comparisons.");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;
bool swapped = true;

while (swapped)
{
swapped = false;

// Sort from left to right (even phase)
for (int i = 0; i < n - 1; i += 2)
{
Thread[] threads = new Thread[numThreads];

for (int j = 0; j < numThreads; j++)
{
int threadIndex = j; // Capture the thread index for each iteration
threads[j] = new Thread(() => SwapElements(arr, threadIndex, numThreads, i, i + 1));
threads[j].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

if (arr[i] > arr[i + 1])
{
Swap(ref arr[i], ref arr[i + 1]);
swapped = true;
}
}

// Sort from right to left (odd phase)
for (int i = 1; i < n - 1; i += 2)
{
Thread[] threads = new Thread[numThreads];

for (int j = 0; j < numThreads; j++)
{
int threadIndex = j; // Capture the thread index for each iteration
threads[j] = new Thread(() => SwapElements(arr, threadIndex, numThreads, i, i + 1));
threads[j].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

if (arr[i] > arr[i + 1])
{
Swap(ref arr[i], ref arr[i + 1]);
swapped = true;
}
}
}
}

private void SwapElements(int[] arr, int start, int step, int i, int j)
{
for (int k = start; k < arr.Length; k += step)
{
if (arr[k] > arr[k + 1])
{
Swap(ref arr[k], ref arr[k + 1]);
}
}
}

private void Swap(ref int a, ref int b)
{
int temp = a;
a = b;
b = temp;
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//TreeSort
public class TreeNode
{
public int Value;
public TreeNode Left, Right;

public TreeNode(int value)
{
Value = value;
Left = Right = null;
}
}

public class TreeSort
{
private static TreeSort instance;
private static readonly object padlock = new object();

private TreeSort() { }

public static TreeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new TreeSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Tree Sort is a sorting algorithm that builds a binary search tree from the elements of an array, and then performs an in-order traversal of the tree to retrieve the elements in sorted order. Parallelizing Tree Sort involves constructing the binary search tree concurrently using multiple threads.");
}

public void Sort(int[] arr, int numThreads)
{
TreeNode root = null;

// Construct the binary search tree using multiple threads
Thread[] threads = new Thread[arr.Length];

for (int i = 0; i < arr.Length; i++)
{
threads[i] = new Thread(() => root = Insert(root, arr[i]));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

// Perform in-order traversal to retrieve sorted elements
int index = 0;
InOrderTraversal(root, arr, ref index);
}

private TreeNode Insert(TreeNode root, int value)
{
if (root == null)
{
return new TreeNode(value);
}

if (value < root.Value)
{
root.Left = Insert(root.Left, value);
}
else if (value > root.Value)
{
root.Right = Insert(root.Right, value);
}

return root;
}

private void InOrderTraversal(TreeNode root, int[] arr, ref int index)
{
if (root != null)
{
InOrderTraversal(root.Left, arr, ref index);
arr[index++] = root.Value;
InOrderTraversal(root.Right, arr, ref index);
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//TagSort
public class TagSort
{
private static TagSort instance;
private static readonly object padlock = new object();

private TagSort() { }

public static TagSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new TagSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Tag Sort, also known as the Pancake Sort, is a sorting algorithm that repeatedly flips elements in the array to sort it. Parallelizing Tag Sort involves dividing the array into segments and sorting each segment concurrently using multiple threads");
}
public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

for (int i = 0; i < n; i++)
{
Thread[] threads = new Thread[numThreads];

for (int j = 0; j < numThreads; j++)
{
int threadIndex = j; // Capture the thread index for each iteration
threads[j] = new Thread(() => FlipSegment(arr, threadIndex, numThreads, n - i));
threads[j].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private void FlipSegment(int[] arr, int start, int step, int k)
{
int n = arr.Length;
for (int i = start; i < n - k; i += step)
{
int left = i;
int right = i + k - 1;

while (left < right)
{
int temp = arr[left];
arr[left] = arr[right];
arr[right] = temp;
left++;
right--;
}
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//StoogeSort

public class StoogeSort
{
private static StoogeSort instance;
private static readonly object padlock = new object();

private StoogeSort() { }

public static StoogeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new StoogeSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Stooge Sort is a recursive sorting algorithm that is not commonly used due to its inefficiency for large datasets. The algorithm sorts an array by recursively sorting the initial two-thirds and last two-thirds of the array, then sorting the initial two-thirds again to ensure the entire array is sorted. Parallelizing Stooge Sort might not offer significant performance improvements due to its recursive nature and the sequential dependency on its subproblems.");
}
public void Sort(int[] arr, int numThreads)
{
StoogeSortRecursive(arr, 0, arr.Length - 1, numThreads);
}

private void StoogeSortRecursive(int[] arr, int start, int end, int numThreads)
{
if (start >= end)
{
return;
}

if (end - start + 1 <= 2)
{
if (arr[start] > arr[end])
{
int temp = arr[start];
arr[start] = arr[end];
arr[end] = temp;
}
return;
}

int third = (end - start + 1) / 3;

Thread[] threads = new Thread[numThreads];

threads[0] = new Thread(() => StoogeSortRecursive(arr, start, end - third, numThreads));
threads[1] = new Thread(() => StoogeSortRecursive(arr, start + third, end, numThreads));
threads[2] = new Thread(() => StoogeSortRecursive(arr, start, end - third, numThreads));

foreach (Thread t in threads)
{
t.Start();
}

foreach (Thread t in threads)
{
t.Join();
}

StoogeSortRecursive(arr, start, end - third, numThreads);
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//GnomeSort

public class GnomeSort
{
private static GnomeSort instance;
private static readonly object padlock = new object();

private GnomeSort() { }

public static GnomeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new GnomeSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Gnome Sort is a relatively simple and straightforward sorting algorithm. It works by moving through the array and swapping adjacent elements if they are in the wrong order, similar to the way a garden gnome sorts a line of flower pots.\r\n\r\nHowever, Gnome Sort is not inherently amenable to parallelization due to its linear nature, where the algorithm moves through the array sequentially and adjusts elements one by one.\r\n\r\nIt's important to note that parallelizing sorting algorithms like Gnome Sort might not offer significant performance improvements due to their inherent sequential dependencies and limited scope for effective parallelization.");
}
public void Sort(int[] arr, int numThreads)
{
int index = 0;

while (index < arr.Length)
{
if (index == 0)
{
index++;
}

if (arr[index] >= arr[index - 1])
{
index++;
}
else
{
// Swapping elements
Swap(ref arr[index], ref arr[index - 1]);
index--;

if (index % numThreads == 0)
{
// Use multithreading to continue sorting
Thread[] threads = new Thread[numThreads];
for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => GnomeSortStep(arr, threadIndex, numThreads));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}
}
}

private void GnomeSortStep(int[] arr, int start, int step)
{
for (int i = start; i < arr.Length - 1; i += step)
{
if (arr[i] > arr[i + 1])
{
Swap(ref arr[i], ref arr[i + 1]);
}
}
}

private void Swap(ref int a, ref int b)
{
int temp = a;
a = b;
b = temp;
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//PermutationSort

public class PermutationSort
{
private static PermutationSort instance;
private static readonly object padlock = new object();

private PermutationSort() { }

public static PermutationSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new PermutationSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Permutation Sort is a sorting algorithm based on generating permutations of the elements and comparing each permutation to the original array to find the sorted permutation. However, this approach makes it highly inefficient and impractical for sorting larger arrays due to its factorial time complexity.\r\n\r\nParallelizing Permutation Sort is challenging due to its nature of generating and checking permutations, which inherently involves sequential operations. Additionally, the number of permutations grows factorially with the size of the array, making it unsuitable for efficient parallelization.\r\n\r\nGiven the impracticality and inefficiency of Permutation Sort for larger arrays, attempting to parallelize this algorithm might not offer significant performance improvements.");
}
public void Sort(int[] arr, int numThreads)
{
int[] originalArray = new int[arr.Length];
Array.Copy(arr, originalArray, arr.Length);

bool sorted = false;

while (!sorted)
{
// Check if the current permutation is sorted
sorted = IsSorted(arr);

// Generate permutations concurrently using multiple threads
Thread[] threads = new Thread[numThreads];
for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => GeneratePermutation(arr, threadIndex, numThreads));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}

// Copy the sorted permutation back to the original array
Array.Copy(arr, originalArray, arr.Length);
}

private bool IsSorted(int[] arr)
{
for (int i = 0; i < arr.Length - 1; i++)
{
if (arr[i] > arr[i + 1])
{
return false;
}
}
return true;
}

private void GeneratePermutation(int[] arr, int start, int step)
{
// Logic to generate permutations
// This is a placeholder method and needs actual permutation generation logic
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BogoSort

public class BogoSort
{
private static BogoSort instance;
private static readonly object padlock = new object();

private BogoSort() { }

public static BogoSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BogoSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Bogo Sort, also known as Stupid Sort or Monkey Sort, is an intentionally inefficient and random sorting algorithm. It works by continuously shuffling the elements of an array randomly and checking if the array is sorted. If not, it continues shuffling and checking until it finds a sorted arrangement. However, due to its random nature, Bogo Sort has an average-case time complexity of O((n+1)!) where 'n' is the number of elements in the array, making it highly impractical for any practical use, especially for larger arrays.\r\n\r\nImplementing Bogo Sort with multi-threading is technically challenging and not recommended due to its random nature and lack of predictability. Parallelizing it involves generating random permutations simultaneously using multiple threads, checking if each permutation is sorted, and this process would continue until a sorted arrangement is found. However, due to the randomness and inefficiency of Bogo Sort, it would be incredibly inefficient and impractical to implement it in a multi-threaded environment.");
}
public void Sort(int[] arr, int numThreads)
{
bool sorted = false;

while (!sorted)
{
// Check if the current permutation is sorted
sorted = IsSorted(arr);

// Generate permutations concurrently using multiple threads
Thread[] threads = new Thread[numThreads];
for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => ShuffleArray(arr, threadIndex, numThreads));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private bool IsSorted(int[] arr)
{
for (int i = 0; i < arr.Length - 1; i++)
{
if (arr[i] > arr[i + 1])
{
return false;
}
}
return true;
}

private void ShuffleArray(int[] arr, int start, int step)
{
Random rand = new Random();

// Perform array shuffling (permutation generation)
// This is a placeholder method and needs actual shuffling logic
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//PancakeSort

public class PancakeSort
{
private static PancakeSort instance;
private static readonly object padlock = new object();

private PancakeSort() { }

public static PancakeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new PancakeSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Pancake Sort is a sorting algorithm that sorts an array by continuously flipping portions of the array. The primary operation in Pancake Sort is flipping the array up to a certain position, bringing the largest unsorted element to the front, and then flipping the entire array to place the element in its correct position. The algorithm repeats these steps until the array is sorted.\r\n\r\nImplementing Pancake Sort with multi-threading involves dividing the flipping operations into segments and performing these segments concurrently using multiple threads. However, parallelizing Pancake Sort might be challenging due to the sequential nature of flipping operations and dependencies on previous flips.");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

for (int i = n; i > 1; i--)
{
int maxIndex = FindMaxIndex(arr, i);

if (maxIndex != i - 1)
{
if (maxIndex != 0)
{
Flip(arr, maxIndex);
}

Flip(arr, i - 1);
}
}
}

private int FindMaxIndex(int[] arr, int n)
{
int maxIndex = 0;
for (int i = 0; i < n; i++)
{
if (arr[i] > arr[maxIndex])
{
maxIndex = i;
}
}
return maxIndex;
}

private void Flip(int[] arr, int k)
{
int start = 0;
while (start < k)
{
int temp = arr[start];
arr[start] = arr[k];
arr[k] = temp;
start++;
k--;
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BitonicSort

public class BitonicSort
{
private static BitonicSort instance;
private static readonly object padlock = new object();

private BitonicSort() { }

public static BitonicSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BitonicSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Bitonic Sort is a parallel sorting algorithm that relies on the concept of a bitonic sequence. A bitonic sequence is a sequence that first increases and then decreases, or vice versa. The Bitonic Sort algorithm first creates bitonic sequences from the input array and then merges these sequences together to form a sorted sequence.\r\n\r\nImplementing Bitonic Sort with multi-threading involves dividing the array into segments, creating bitonic sequences within these segments concurrently using multiple threads, and then merging these sequences to obtain the sorted array. However, it's important to note that efficiently parallelizing Bitonic Sort might require synchronization and merging steps, which could introduce complexities");
}
public void Sort(int[] arr, int numThreads)
{
BitonicSortRecursive(arr, 0, arr.Length, 1, numThreads);
}

private void BitonicSortRecursive(int[] arr, int low, int count, int direction, int numThreads)
{
if (count > 1)
{
int k = count / 2;

Thread[] threads = new Thread[numThreads];
for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => BitonicMerge(arr, low + threadIndex * k, k, direction));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

BitonicSortRecursive(arr, low, k, direction, numThreads);
BitonicSortRecursive(arr, low + k, k, -direction, numThreads);
}
}

private void BitonicMerge(int[] arr, int low, int count, int direction)
{
if (count > 1)
{
int k = count / 2;
for (int i = low; i < low + k; i++)
{
CompareAndExchange(arr, i, i + k, direction);
}

BitonicMerge(arr, low, k, direction);
BitonicMerge(arr, low + k, k, direction);
}
}

private void CompareAndExchange(int[] arr, int i, int j, int direction)
{
if ((arr[i] > arr[j] && direction == 1) || (arr[i] < arr[j] && direction == -1))
{
int temp = arr[i];
arr[i] = arr[j];
arr[j] = temp;
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//CycleSort

public class CycleSort
{
private static CycleSort instance;
private static readonly object padlock = new object();

private CycleSort() { }

public static CycleSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new CycleSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Cycle Sort is an in-place sorting algorithm known for its minimal writes to the array and its relatively small number of memory accesses. It works by placing each element in its correct position within the sorted array, handling cycles or rotations in the array to achieve this.\r\n\r\nImplementing Cycle Sort with multi-threading is challenging due to its sequential nature and dependency on each element's correct positioning within the array. Parallelizing Cycle Sort might involve dividing the array into segments and concurrently sorting these segments using multiple threads. However, this approach might not provide significant performance improvements due to the inherent sequential nature of Cycle Sort.");
}
public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

for (int start = 0; start < n - 1; start++)
{
int item = arr[start];

int pos = start;
for (int i = start + 1; i < n; i++)
{
if (arr[i] < item)
{
pos++;
}
}

if (pos == start)
{
continue;
}

while (item == arr[pos])
{
pos++;
}

if (pos != start)
{
int temp = item;
item = arr[pos];
arr[pos] = temp;
}

while (pos != start)
{
pos = start;
for (int i = start + 1; i < n; i++)
{
if (arr[i] < item)
{
pos++;
}
}

while (item == arr[pos])
{
pos++;
}

if (item != arr[pos])
{
int temp = item;
item = arr[pos];
arr[pos] = temp;
}
}
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//CockTailSort

public class CocktailSort
{
private static CocktailSort instance;
private static readonly object padlock = new object();

private CocktailSort() { }

public static CocktailSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new CocktailSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Cocktail Sort, also known as Bidirectional Bubble Sort or Shaker Sort, is a variation of Bubble Sort. It works by repeatedly stepping through the array in both directions, swapping adjacent elements if they are in the wrong order, similar to Bubble Sort. However, Cocktail Sort also moves in the opposite direction on each pass, efficiently moving large elements toward the end and small elements toward the beginning.\r\n\r\nImplementing Cocktail Sort with multi-threading involves dividing the array into segments and concurrently sorting these segments using multiple threads. However, parallelizing Cocktail Sort might face challenges due to the sequential nature of the sorting process and the dependencies between adjacent elements.");
}

public void Sort(int[] arr, int numThreads)
{
bool swapped = true;
int start = 0;
int end = arr.Length;

while (swapped)
{
swapped = false;

// Forward pass (Bubble sort from start to end)
for (int i = start; i < end - 1; ++i)
{
if (arr[i] > arr[i + 1])
{
Swap(ref arr[i], ref arr[i + 1]);
swapped = true;
}
}

// If no elements were swapped, the array is sorted
if (!swapped)
{
break;
}

swapped = false;
end--; // Reduce the end pointer

// Backward pass (Bubble sort from end to start)
for (int i = end - 1; i >= start; --i)
{
if (arr[i] > arr[i + 1])
{
Swap(ref arr[i], ref arr[i + 1]);
swapped = true;
}
}

start++; // Increase the start pointer
}
}

private void Swap(ref int a, ref int b)
{
int temp = a;
a = b;
b = temp;
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//PigeonholeSort

public class PigeonholeSort
{
private static PigeonholeSort instance;
private static readonly object padlock = new object();

private PigeonholeSort() { }

public static PigeonholeSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new PigeonholeSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Pigeonhole Sort, also known as Bucket Sort, is a sorting algorithm suitable for sorting lists where the range of elements is relatively small. It works by creating an auxiliary array of pigeonholes (buckets), each capable of storing multiple elements. Then, it distributes the elements from the input array into these pigeonholes based on their values and finally gathers them back into the original array, effectively sorting it.\r\n\r\nParallelizing Pigeonhole Sort involves dividing the array into segments and sorting these segments concurrently using multiple threads. However, due to the dependency on properly allocating elements into their respective pigeonholes, parallelizing this algorithm might face challenges.");
}

public void Sort(int[] arr, int numThreads)
{
int min = arr[0];
int max = arr[0];
int n = arr.Length;

for (int i = 1; i < n; i++)
{
if (arr[i] < min)
{
min = arr[i];
}
if (arr[i] > max)
{
max = arr[i];
}
}

int range = max - min + 1;

int[] pigeonholes = new int[range];

// Distribute elements into pigeonholes
for (int i = 0; i < n; i++)
{
pigeonholes[arr[i] - min]++;
}

int index = 0;

// Gather elements from pigeonholes back into the array
for (int i = 0; i < range; i++)
{
while (pigeonholes[i] > 0)
{
arr[index++] = i + min;
pigeonholes[i]--;
}
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//CombSort

public class CombSort
{
private static CombSort instance;
private static readonly object padlock = new object();

private CombSort() { }

public static CombSort GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new CombSort();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Comb Sort is an improvement over Bubble Sort known for its better average-case performance. It works by comparing elements that are distant from each other and swapping them if they are in the wrong order. Similar to Bubble Sort, it repeatedly performs these comparisons and swaps until the array is sorted.\r\n\r\nImplementing Comb Sort with multi-threading involves dividing the array into segments and concurrently sorting these segments using multiple threads. However, parallelizing Comb Sort might face challenges due to the sequential nature of the comparisons and swaps within the algorithm.");
}

public void Sort(int[] arr, int numThreads)
{
int n = arr.Length;

int gap = n;
bool swapped = true;

while (gap != 1 || swapped)
{
gap = GetNextGap(gap);

swapped = false;

Thread[] threads = new Thread[numThreads];
for (int i = 0; i < numThreads; i++)
{
int threadIndex = i; // Capture the thread index for each iteration
threads[i] = new Thread(() => CombSortPass(arr, gap, threadIndex, numThreads, ref swapped));
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}
}
}

private int GetNextGap(int gap)
{
gap = (gap * 10) / 13;
return gap < 1 ? 1 : gap;
}

private void CombSortPass(int[] arr, int gap, int start, int step, ref bool swapped)
{
int n = arr.Length;

for (int i = start; i < n - gap; i += step)
{
int j = i + gap;
if (arr[i] > arr[j])
{
Swap(ref arr[i], ref arr[j]);
swapped = true;
}
}
}

private void Swap(ref int a, ref int b)
{
int temp = a;
a = b;
b = temp;
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//BinarySearch

public class BinarySearch
{

private static BinarySearch instance;
private static readonly object padlock = new object();

private BinarySearch() { }

public static BinarySearch GetInstance()
{
lock (padlock)
{
if (instance == null)
{
instance = new BinarySearch();
}
return instance;
}
}

public void help()
{
Console.WriteLine("Binary Search is a search algorithm that efficiently finds the position of a target value within a sorted array. It works by repeatedly dividing the search interval in half and comparing the target value with the middle element of the array. Based on this comparison, the algorithm eliminates half of the remaining elements and continues the search in the remaining part until it finds the target value or determines that it's not present in the array.\r\n\r\nImplementing Binary Search with multi-threading is possible by dividing the search space among multiple threads to concurrently search different segments of the array. However, Binary Search itself is a very fast algorithm and dividing its execution across multiple threads might not significantly enhance its performance. Moreover, due to its divide-and-conquer nature, handling concurrent operations may introduce complexities without substantial gains in speed.");
}
public int Search(int[] arr, int target, int numThreads)
{
int start = 0;
int end = arr.Length - 1;
int result = -1;

bool[] found = new bool[numThreads]; // Array to store if the target is found by each thread
int[] indices = new int[numThreads]; // Array to store the index found by each thread

int segmentSize = arr.Length / numThreads;

Thread[] threads = new Thread[numThreads];

for (int i = 0; i < numThreads; i++)
{
int threadIndex = i;
threads[i] = new Thread(() =>
{
int segmentStart = threadIndex * segmentSize;
int segmentEnd = (threadIndex == numThreads - 1) ? arr.Length - 1 : segmentStart + segmentSize - 1;

int localResult = -1;
while (segmentStart <= segmentEnd)
{
int mid = segmentStart + (segmentEnd - segmentStart) / 2;

if (arr[mid] == target)
{
localResult = mid;
break;
}

if (arr[mid] < target)
{
segmentStart = mid + 1;
}
else
{
segmentEnd = mid - 1;
}
}

found[threadIndex] = localResult != -1;
indices[threadIndex] = localResult;
});
threads[i].Start();
}

foreach (Thread t in threads)
{
t.Join();
}

for (int i = 0; i < numThreads; i++)
{
if (found[i])
{
result = indices[i];
break;
}
}

return result;
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//Huffman

class HuffmanNode
{
public char Character { get; set; }
public int Frequency { get; set; }
public HuffmanNode Left { get; set; }
public HuffmanNode Right { get; set; }
}

class Huffman
{
private Dictionary<char, int> CountFrequencies(string input)
{
return input.GroupBy(c => c)
.ToDictionary(g => g.Key, g => g.Count());
}

private HuffmanNode BuildTree(Dictionary<char, int> frequencies)
{
var priorityQueue = new SortedDictionary<int, List<HuffmanNode>>();

foreach (var entry in frequencies)
{
var node = new HuffmanNode { Character = entry.Key, Frequency = entry.Value };
if (!priorityQueue.ContainsKey(entry.Value))
priorityQueue[entry.Value] = new List<HuffmanNode>();

priorityQueue[entry.Value].Add(node);
}

while (priorityQueue.Count > 1)
{
var pair = priorityQueue.First();
var first = pair.Value.First();
pair.Value.RemoveAt(0);

if (pair.Value.Count == 0)
priorityQueue.Remove(pair.Key);

var pair2 = priorityQueue.First();
var second = pair2.Value.First();
pair2.Value.RemoveAt(0);

if (pair2.Value.Count == 0)
priorityQueue.Remove(pair2.Key);

var merged = new HuffmanNode
{
Character = '\0',
Frequency = first.Frequency + second.Frequency,
Left = first,
Right = second
};

if (!priorityQueue.ContainsKey(merged.Frequency))
priorityQueue[merged.Frequency] = new List<HuffmanNode>();

priorityQueue[merged.Frequency].Add(merged);
}

return priorityQueue.First().Value.First();
}

private Dictionary<char, string> GenerateCodes(HuffmanNode root)
{
var codes = new Dictionary<char, string>();
GenerateCodesRecursive(root, "", codes);
return codes;
}

private void GenerateCodesRecursive(HuffmanNode node, string code, Dictionary<char, string> codes)
{
if (node == null)
return;

if (node.Character != '\0')
{
codes[node.Character] = code;
return;
}

GenerateCodesRecursive(node.Left, code + "0", codes);
GenerateCodesRecursive(node.Right, code + "1", codes);
}

public string Compress(string input)
{
var frequencies = CountFrequencies(input);
var root = BuildTree(frequencies);
var codes = GenerateCodes(root);

var encodedStringBuilder = new StringBuilder();
foreach (var c in input)
{
encodedStringBuilder.Append(codes[c]);
}

return encodedStringBuilder.ToString();
}

public string Decompress(string input, HuffmanNode root)
{
var result = new StringBuilder();
var currentNode = root;

foreach (var bit in input)
{
if (bit == '0')
currentNode = currentNode.Left;
else if (bit == '1')
currentNode = currentNode.Right;

if (currentNode.Left == null && currentNode.Right == null)
{
result.Append(currentNode.Character);
currentNode = root;
}
}

return result.ToString();
}

public void help()
{
Console.WriteLine("The Huffman coding algorithm is a widely used method for lossless data compression. It works by assigning variable-length codes to input characters, with shorter codes assigned to more frequent characters. This approach results in efficient encoding, where frequently occurring characters are represented by shorter codes, reducing the overall size of the encoded data.\r\n\r\nHere's a high-level explanation of the Huffman algorithm:\r\n\r\nFrequency Calculation: The algorithm begins by calculating the frequency of each character in the input data.\r\n\r\nBuilding a Huffman Tree: Create a binary tree where each leaf node represents a character along with its frequency, and internal nodes represent merged frequencies. This tree is constructed in such a way that more frequent characters have shorter paths from the root of the tree.\r\n\r\nAssigning Codes: Traverse the tree to assign unique binary codes to each character based on their positions in the tree. Characters found at the left branch receive a '0', and those on the right branch receive a '1'. This creates unique codes for each character in the input data.");
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//GreedySearch With rate maze
class MazeSolver
{
private static MazeSolver _instance = null;
private static readonly object _lock = new object();

private MazeSolver() { }

public static MazeSolver GetInstance()
{
if (_instance == null)
{
lock (_lock)
{
if (_instance == null)
{
_instance = new MazeSolver();
}
}
}
return _instance;
}

public void help()
{
Console.WriteLine("Sure, the Greedy Best-First Search is an informed search algorithm that uses heuristics to find the most promising path toward the goal in a search space. When applied to maze solving, it traverses the maze by always choosing the path that seems to lead most directly toward the goal, without considering the overall path cost.\r\n\r\nHere's an overview of Greedy Best-First Search:\r\n\r\nHeuristic Function: It employs a heuristic function that estimates the cost from the current state to the goal state without considering the actual path cost. In maze solving, this heuristic function can be the Euclidean distance or Manhattan distance from the current cell to the goal.\r\n\r\nPriority Queue: It uses a priority queue (usually implemented using a heap) to store and explore nodes. The priority queue orders nodes based on the heuristic value; nodes with lower heuristic values (closer to the goal) are given higher priority.\r\n\r\nTraversal: The algorithm starts at the initial position and iteratively explores the next most promising node based on the heuristic function until it reaches the goal");
}


public bool SolveMaze(int[,] maze, (int, int) start, (int, int) goal)
{
int rows = maze.GetLength(0);
int cols = maze.GetLength(1);

if (!IsValidCell(start, rows, cols) || !IsValidCell(goal, rows, cols))
{
Console.WriteLine("Invalid start or goal position");
return false;
}

bool[,] visited = new bool[rows, cols];
PriorityQueue<(int, int)> priorityQueue = new PriorityQueue<(int, int)>();
priorityQueue.Enqueue(start, Heuristic(start, goal));

while (priorityQueue.Count > 0)
{
var current = priorityQueue.Dequeue();

if (current == goal)
{
Console.WriteLine("Goal reached!");
return true;
}

visited[current.Item1, current.Item2] = true;

var neighbors = GetNeighbors(current, rows, cols);
foreach (var neighbor in neighbors)
{
if (!visited[neighbor.Item1, neighbor.Item2] && maze[neighbor.Item1, neighbor.Item2] != 1)
{
visited[neighbor.Item1, neighbor.Item2] = true;
priorityQueue.Enqueue(neighbor, Heuristic(neighbor, goal));
}
}
}

Console.WriteLine("No path to the goal!");
return false;
}

private bool IsValidCell((int, int) cell, int rows, int cols)
{
int row = cell.Item1;
int col = cell.Item2;
return row >= 0 && row < rows && col >= 0 && col < cols;
}

private List<(int, int)> GetNeighbors((int, int) cell, int rows, int cols)
{
int row = cell.Item1;
int col = cell.Item2;
List<(int, int)> neighbors = new List<(int, int)>();

if (IsValidCell((row - 1, col), rows, cols))
neighbors.Add((row - 1, col));
if (IsValidCell((row + 1, col), rows, cols))
neighbors.Add((row + 1, col));
if (IsValidCell((row, col - 1), rows, cols))
neighbors.Add((row, col - 1));
if (IsValidCell((row, col + 1), rows, cols))
neighbors.Add((row, col + 1));

return neighbors;
}

private double Heuristic((int, int) current, (int, int) goal)
{
// Euclidean distance heuristic
int dx = current.Item1 - goal.Item1;
int dy = current.Item2 - goal.Item2;
return Math.Sqrt(dx * dx + dy * dy);
}
}

class PriorityQueue<T>
{
private SortedDictionary<double, Queue<T>> _queue = new SortedDictionary<double, Queue<T>>();

public int Count => _queue.Count;

public void Enqueue(T item, double priority)
{
if (!_queue.ContainsKey(priority))
_queue[priority] = new Queue<T>();

_queue[priority].Enqueue(item);
}

public T Dequeue()
{
var item = _queue.First();
var queue = item.Value;

var result = queue.Dequeue();
if (queue.Count == 0)
_queue.Remove(item.Key);

return result;
}
}
//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
//GreedySearch Puzzle
class PuzzleSolver
{
private static PuzzleSolver _instance = null;
private static readonly object _lock = new object();

private PuzzleSolver() { }

public static PuzzleSolver GetInstance()
{
if (_instance == null)
{
lock (_lock)
{
if (_instance == null)
{
_instance = new PuzzleSolver();
}
}
}
return _instance;
}

public void help()
{
Console.WriteLine("Greedy Best-First Search is an informed search algorithm used to solve problems like puzzles, where the objective is to find the goal state from an initial state by considering the most promising paths based on a heuristic function.\r\n\r\nFor example, let's consider the 8-puzzle problem—a sliding puzzle with numbered tiles in a 3x3 grid, where one tile is empty and the goal is to rearrange the tiles from an initial configuration to reach a specified goal state.\r\n\r\nHere's an overview of using Greedy Best-First Search for solving the 8-puzzle:\r\n\r\nState Representation: Represent the puzzle states using data structures (e.g., arrays, matrices) where each state is a unique configuration of the puzzle.\r\n\r\nHeuristic Function: Define a heuristic function that estimates how close a state is to the goal state. For the 8-puzzle, a common heuristic is the Manhattan distance—sum of the distances of each tile from its goal position.\r\n\r\nPriority Queue: Use a priority queue to store and explore states. Prioritize the states based on the heuristic value; states with lower heuristic values (closer to the goal) are given higher priority.\r\n\r\nTraversal: Begin with the initial state and iteratively explore the next most promising state based on the heuristic function until the goal state is reached.\r\n\r\nRegarding the Singleton pattern and multi-threading, applying them to this context might be complex due to the nature of puzzle solving. The search algorithm explores states based on heuristic values, and parallelizing this process might not be straightforward, as each step often depends on the previous state and requires careful synchronization.");
}

public bool SolvePuzzle(int[,] initial, int[,] goal)
{
// Implement your Greedy Best-First Search algorithm here
// Consider representing puzzle states, heuristic function (e.g., Manhattan distance),
// priority queue, and traversal logic to explore states.
// Note: This example provides a basic structure and requires the implementation of the algorithm.
throw new NotImplementedException();
}

private int CalculateHeuristic(int[,] current, int[,] goal)
{
// Calculate heuristic function (Manhattan distance) here
// Return the heuristic value
throw new NotImplementedException();
}
}

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@









































internal class Program
{
static void Main(string[] args)
{
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}


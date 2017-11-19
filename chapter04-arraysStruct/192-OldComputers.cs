/*
Create a C# program that can store up to 600 records of classical computers. 
For each computer, you must keep the following data:

• Brand Name (eg Amstrad)

• Model (eg CPC664)

• Year (eg 1984)

• RAM (set of 2 data: the measure unit, eg Kb, and size, eg 64)

• Comments

The program should allow the user the following operations:

1 - Add a new computer data (the brand must not be empty, the model should not 
occupy more than 50 letters, and if any of them is not valid, it must be 
entered again. If the year is before 1900, it should be stored as 0, to 
indicate that it is not valid).

2 - Show all brands and models of computers stored. Each computer (brand and 
model) should appear on one line, separated by a hyphen (eg "Amstrad - CPC664"). 
The program should pause after displaying each block of 24 computers, display 
the message "Press Enter to continue" and wait until the user presses Enter.
The user should be notified if there is no data.

3 - Search for computers that contain a certain text (as part of its brand, 
model or comments, case insensitive). If the year is 0, it should display: 
"Year: unknown." Data must be displayed on separate lines, with an extra blank 
line after each computer. The user should be notified if none is found.

4 - Update a record (the program will ask for the number, will display the 
previous value of each field and the user can press Enter not to modify any of 
the data). The user should be warned (but not asked again) if he enters an 
incorrect record number. It is not necessary to validate any of the fields.

5 - Delete some data, in the position indicated by the user. The user should be 
warned (but not asked again) if he enters an incorrect record number.

6 - Insert data in a position chosen by the user (by moving the rest of the 
records to the right). The user should be warned (but not asked again) if he 
enters an incorrect record number.

7 - Sort the data alphabetically by brand+model.

8 - Remove extra spaces (initial and final spaces in all the brands, models and 
comments. For example, a comment like " Test Data " would become "Test Data".

Q - Quit (end the application; as we do not store the information, will be lost).
*/

// Gonzalo Martinez
// Preliminary version, not checked

using System;

struct Ram
{
    public string measure;
    public ushort size;
}
struct Computer
{
    public string brand;
    public string model;
    public ushort year;
    public Ram memory;
    public string comments;
}

public class Ex192
{
    public static void Main()
    {
        const int SIZE = 600;
        Computer[] computers = new Computer[SIZE];
        string option;
        bool finished = false;
        int count = 0;
        
        do
        {
            Console.WriteLine("1.Add data");
            Console.WriteLine("2.Show brands");
            Console.WriteLine("3.Search computers");
            Console.WriteLine("4.Update information");
            Console.WriteLine("5.Delete data");
            Console.WriteLine("6.Insert data");
            Console.WriteLine("7.Sort alphabetically");
            Console.WriteLine("8.Remove extra spaces");
            Console.WriteLine("Q.Exit");
            Console.WriteLine();
            
            Console.Write("Choose an option: ");
            option = Console.ReadLine();
            
            switch(option)
            {
                // To add data
                case "1":
                    if(count < SIZE)
                    {
                        do
                        {
                            Console.Write("Enter the brand: ");
                            computers[count].brand = Console.ReadLine();
                        }while(computers[count].brand == "");
                        
                        do
                        {
                            Console.Write("Enter the model: ");
                            computers[count].model = Console.ReadLine();
                        }while(computers[count].model.Length > 50);
                        
                        Console.Write("Enter the year: ");
                        computers[count].year = 
                            Convert.ToUInt16(Console.ReadLine());
                        if(computers[count].year < 1900)
                            computers[count].year = 0;
                        
                        Console.Write("Enter the type of memory: ");
                        computers[count].memory.measure = Console.ReadLine();
                        
                        Console.Write("Enter the size of memory: ");
                        computers[count].memory.size = 
                            Convert.ToUInt16(Console.ReadLine());
                            
                        Console.Write("Enter the comments: ");
                        computers[count].comments = Console.ReadLine();
                        
                        count++;
                    }
                    else
                    {
                        Console.WriteLine("Database full");
                        Console.WriteLine();
                    }
                    break;
                case "2":
                    if(count == 0)
                        Console.WriteLine("No data saved");
                    else
                    {
                        for(int i = 0; i < count; i++)
                        {
                            Console.WriteLine(computers[i].brand + " - " + 
                                computers[i].model);
                            if(i % 24 == 23)
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                        }
                    }
                    break;
                case "3":
                    bool datafound = false;
                    Console.Write("Item to search? ");
                    string str = Console.ReadLine().ToLower();
                    for(int i = 0; i < count; i++)
                    {
                        if(computers[i].brand.ToLower().Contains(str) || 
                            computers[i].model.ToLower().Contains(str) ||
                            computers[i].comments.ToLower().Contains(str))
                        {
                            datafound = true;
                            Console.WriteLine("Computer {0}", i + 1);
                            Console.WriteLine("Brand: {0}", computers[i].brand);
                            Console.WriteLine("Model: {0}", computers[i].model);
                            if(computers[i].year == 0)
                                Console.WriteLine("Year unknown");
                            else
                                Console.WriteLine("Year: {0}", 
                                    computers[i].year);
                            Console.WriteLine("Memory: {0} {1}", 
                                computers[i].memory.size, 
                                computers[i].memory.measure);
                            Console.WriteLine("Comments: {0}", 
                                computers[i].comments);
                            Console.WriteLine();
                        }
                    }
                    if(!datafound)
                        Console.WriteLine("Data not found");
                    break;
                case "4":
                    Console.Write("Number of data? ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    num--;
                    if(num >= count || num < 0)
                        Console.WriteLine("Not a valid record");
                    else
                    {    
                        Console.WriteLine("Computer {0}", num + 1);
                        Console.WriteLine("Enter the new brand (it was {0})", 
                            computers[num].brand);
                        string answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].brand = answer;
                            
                        Console.WriteLine("Enter the new model (it was {0})", 
                            computers[num].model);
                        answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].model = answer;
                            
                        Console.WriteLine("Enter the new year (it was {0})", 
                            computers[num].year);
                        answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].year = Convert.ToUInt16(answer);
                            
                        Console.WriteLine("Enter the new measure (it was {0})", 
                            computers[num].memory.measure);
                        answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].memory.measure = answer;
                            
                        Console.WriteLine("Enter the new size (it was {0})", 
                            computers[num].memory.size);
                        answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].memory.size = 
                                Convert.ToUInt16(answer);
                            
                        Console.WriteLine("Enter the new comment (it was {0})", 
                            computers[num].comments);
                        answer = Console.ReadLine();
                        if(answer != "")
                            computers[num].comments = answer;
                    }
                    break;
                case "5":
                    Console.Write("Number of data? ");
                    int pos = Convert.ToInt32(Console.ReadLine());
                    pos--;
                    if(pos >= count || pos < 0)
                        Console.WriteLine("Not a valid record");
                    else
                    {    
                        for(int i = pos; i < count - 1; i++)
                        {
                            computers[i] = computers[i+1];
                        }
                        count--;
                    }
                    break;
                case "6":
                    Console.Write("Position to insert data? ");
                    pos = Convert.ToInt32(Console.ReadLine());
                    pos--;
                    if(pos >= count || pos < 0)
                        Console.WriteLine("Not a valid record");
                    else
                    {
                        for(int i = pos; i < count - 1; i++)
                        {
                            computers[i] = computers[i + 1];
                        }
                        Console.WriteLine("Computer {0}", pos + 1);
                        Console.WriteLine("Brand: {0}", computers[pos].brand);
                        Console.WriteLine("Model: {0}", computers[pos].model);
                        Console.WriteLine("Year unknown");
                        Console.WriteLine("Year: {0}", 
                            computers[pos].year);
                        Console.WriteLine("Memory: {0} {1}", 
                            computers[pos].memory.size, 
                            computers[pos].memory.measure);
                        Console.WriteLine("Comments: {0}", 
                            computers[pos].comments);
                    }
                    break;
                case "7":
                    for(int i = 0; i < count - 1; i++)
                    {
                        for(int j = i + 1; j < count; j++)
                        {
                            if(String.Compare(computers[i].brand, 
                                computers[j].brand, true) > 0 && 
                                String.Compare(computers[i].model, 
                                computers[j].model, true) > 0)
                            {
                                Computer temp = computers[i];
                                computers[i] = computers[j];
                                computers[j] = temp;
                            }
                        }
                    }
                    break;
                case "8":
                    for(int i = 0; i < count; i++)
                    {
                        computers[i].brand.TrimStart().TrimEnd();
                        computers[i].model.TrimStart().TrimEnd();
                        computers[i].comments.TrimStart().TrimEnd();
                    }
                    break;
                case "q":
                case "Q":
                    finished = true;
                    break;
            }
        }while(!finished);
        Console.WriteLine("Bye!");
    }
}

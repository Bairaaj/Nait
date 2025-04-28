// LabExam02 - Practice Solution 1241
// Author : cmpe
// This solution uses a NuGet package called Bogus to generate random data for the Person class.
// This may require a Build, or Rebuild to get the Bogus package to download and install.
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Bogus;
using static System.Diagnostics.Trace;

namespace zDemo_Exam02_Practice
{
  public partial class Form1 : Form
  {
    BindingSource _bs = new BindingSource();
    List<Person> Simontown = new List<Person>();
    List<Person> Stevenville = new List<Person>();
    public Form1()
    {
      InitializeComponent();
      Text = "zDemo_Exam02_Practice";
      _dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
      _dgv.RowHeadersVisible = false;
      _dgv.Font = new Font(familyName: "Consolas", emSize: 14);
      _dgv.DataSource = _bs;
      KeyPreview = true;
      KeyDown += Form1_KeyDown;
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      // Aggregates : Min Max Average Sum Count
      // Predicate, non-IEnumerable : Any, All, Exists, RemoveAll, TrueForAll
      // Predicate, IEnumerable : FindAll, Where, OrderBy
      // Set operations : Concat Intersect Except Union Distinct
      // Misc : First Last forEach BinarySearch Skip Take Select
      // ToX : ToList ToDictionary** Know the 2 overloads
      if (e.KeyCode == Keys.A)
      {
        // Clear and Add 100 new persons to both Lists, show SimonTown persons in DGV
        Simontown.Clear();
                Stevenville.Clear();
        while ( Simontown.Count < 100)
        {
          Simontown.Add(new Person());
                    Stevenville.Add(new Person());
        }

        // Do this, assigning the collection of interest to the BindingSource, for whatever collection you want to display
        _bs.DataSource = Simontown;
        _bs.ResetBindings(false);

      }
      if (e.KeyCode == Keys.S)
      {
                // Aggregates : Min Max Average Sum Count
                // Write to the console :
                // Minimum iValue in Simontown
                // Average dValue in Stevenville
                // Number of Simontown persons with Level of "pro"
                // Sum of Stevenville persons First and Last name lengths
                int min = Simontown.Min(x => x.iValue);

                int minv = Simontown[0].iValue;
                for(int i = 0; i < Simontown.Count; i++)
                {
                    minv = Math.Min(Simontown[i].iValue, minv);
                }


                double avg = Stevenville.Average(x => x.dValue);

                double totalcount = 0;
                double avgg = 0;
                foreach (Person person in Stevenville)
                {
                    totalcount += person.dValue;
                }
                avgg = totalcount / Stevenville.Count;



                List<Person> level = Simontown.FindAll(x => x.Level == "pro");
                List<Person> Lev = new List<Person>();
                foreach(Person person in Simontown)
                {
                    if(person.Level == "pro")
                    {
                        Lev.Add(person);
                    }
                }

                int flength = 0;
                Stevenville.ForEach(x => flength += x.First.Length + x.Last.Length);

                int fllength = 0;
                foreach(Person people in Stevenville)
                {
                    fllength += people.First.Length + people.Last.Length;
                }
                
            
                Console.WriteLine(min);
                Console.WriteLine(minv);
                Console.WriteLine(avg);
                Console.WriteLine(avgg);
                Console.WriteLine(level.Count);
                Console.WriteLine(Lev.Count);
                Console.WriteLine(fllength);
                Console.WriteLine(flength);

      }
      if (e.KeyCode == Keys.D)
      {
                // Predicate, non-IEnumerable : Any, All, Exists, RemoveAll, TrueForAll
                // if any Simontown persons have a iValue less than 500, remove all Simontown persons First name letter less than M
                //   Show Simontown to DGV
                // Write to the console : 
                //  t/f if a Stevenville person is a "pro" and has an iValue greater than 500
                //  t/f if all Simontown persons have an iValue that is even
                List<Person> temp = new List<Person>();

                //Simontown.Any(x => x.iValue < 500);
                
                Simontown.RemoveAll(x => 
                    
                    x.iValue < 500 || (x.First.First() < 'M' && x.iValue < 500)
                );

                if (Stevenville.Any(x => x.Level == "pro" && x.iValue > 500))
                {
                    Console.WriteLine("T");
                }
                else
                    Console.WriteLine("f");

                if (Simontown.TrueForAll(x => x.iValue % 2 == 0))
                {
                    Console.WriteLine("T");
                }
                else
                    Console.WriteLine("f");

                _bs.DataSource = Simontown;
                _bs.ResetBindings(false);

            }
      if (e.KeyCode == Keys.F)
      {
                // Set operations : Concat Intersect Except Union Distinct
                // *Complete Person equality semantics so persons with the same Last initial are considered equal
                // Make a new list of the unique combination of Simontown and Stevenville persons, display to DGV

                List<Person> unique = Simontown.Concat(Stevenville).ToList();



                List<Person> temp = unique.Distinct().ToList();
               
                _bs.DataSource = temp;
                _bs.ResetBindings(false);

            }
      if (e.KeyCode == Keys.G)
      {
                // Set operations : Concat Intersect Except Union Distinct
                // Predicate, IEnumerable : FindAll, Where, OrderBy
                // *Complete Person equality semantics so persons with the same Last initial are considered equal
                // Make a new list of the persons common to both Simontown and Stevenville, display to DGV
                // Do not use ToList
                List<Person> peoples = new List<Person>(Simontown.Concat(Stevenville).Distinct());
                _bs.DataSource = peoples;
                _bs.ResetBindings(false);

            }
      if (e.KeyCode == Keys.H)
      {
                // Set operations : Concat Intersect Except Union Distinct
                // Predicate, IEnumerable : FindAll, Where, OrderBy
                // *Complete Person equality semantics so persons with the same Last initial are considered equal
                // Make an IEnumerable of Simontown persons with iValue less than 400
                // Make an IEnumerable of Stevenville persons with First initial more than 'J'
                // Combine these collections, and order them by Last name into a single new List,
                // do NOT use ToList(), display to DGV
                IEnumerable<Person> people = Simontown.FindAll(x => x.iValue < 400);
                IEnumerable<Person> peoples = Stevenville.FindAll(x => x.First.First() == 'J');

               

                List<Person> tess = new List<Person>(people.Concat(peoples).OrderBy(x=> x.First));
                _bs.DataSource = tess;
                _bs.ResetBindings(false);

            }
      if (e.KeyCode == Keys.J)
      {
                // Misc : First Last forEach BinarySearch Skip Take Select
                // ToX : ToList ToDictionary** Know the 2 overloads

                // Make an IEnumerable that is the combination of Simontown and Stevenville
                // Using a ForEach(), iterate and write to the console on one line comma separated First names

                // Create a dictionary of key = string ( Level ) and value = int ( occurances of Level ), init to empty
                // using a foreach(), iterate and populate the dictionary - Level and #ofPerson in that Level
                // display dictionary to DGV - assign dictionary directly to DGV
                IEnumerable<Person> people = Simontown.Concat(Stevenville);

                
                foreach(Person person in people)
                {
                    Console.WriteLine(person.First + ", ");
                }

                Dictionary<string, int> keyValues = new Dictionary<string, int>();
               
                foreach(Person peoples in people)
                {
                    if(!keyValues.ContainsKey(peoples.Level))
                    {
                        keyValues.Add(peoples.Level, 1);
                    }
                    else
                    {
                        keyValues[peoples.Level]++;
                    }
                }

                List<KeyValuePair<string, int>> tess = keyValues.ToList();
                _bs.DataSource = tess;
                _bs.ResetBindings(false);

            }
      if (e.KeyCode == Keys.K)
      {
                // Misc : First Last forEach BinarySearch Skip Take Select
                // ToX : ToList ToDictionary** Know the 2 overloads

                // Make an IEnumerable that is the UNIQUE combination of Simontown and Stevenville

                // Create a dictionary of key = int ( iValue ) and value = string ( concatenated First names with that iValue ), init to empty
                // using a foreach(), iterate and populate the dictionary - iValue and All_First_names with that iValue

                // without using Sort() or ToList(), transform the dictionary to be sorted by iValue
                // display dictionary to DGV - assign dictionary directly to DGV
                IEnumerable<Person> people = Simontown.Union(Stevenville);

                Dictionary<int, string> keyValuePairs = new Dictionary<int, string>();

                foreach (Person person in people)
                {
                    if(!keyValuePairs.ContainsKey(person.iValue))
                    {
                        keyValuePairs.Add(person.iValue, $"{person.First}, {person.iValue}");
                    }
                    else
                    {
                        keyValuePairs[person.iValue] = person.First;
                    }
                }

                List<KeyValuePair<int, string>> keyValuePairs1 = keyValuePairs.OrderBy(x => x.Value).ThenBy(y => y.Key).ToList();   
                _bs.DataSource = keyValuePairs1;
                _bs.ResetBindings(false);
            }
      if (e.KeyCode == Keys.L)
      {
                // Misc : First Last forEach BinarySearch Skip Take Select
                // Stack, Queue, LinkedList
                // Make a Stack, Queue and LinkedList of string, then useing foreach() with Simontown+Take+Select
                //   extract 10 items, Select the Last name and add to each container, For the LinkedList optionally add in alpha order

                // Empty the Stack and Queue outputing the contents to the console comma separated
                // Using LinkedListNode<> iterate the LinkedList as above

                Stack<string> stack = new Stack<string>();
                Queue<string> q = new Queue<string>();
                LinkedList<string> list = new LinkedList<string>();
                List<string> strings = Simontown.Take(10).Select(x => x.Last).ToList();

                foreach (string s in strings)
                {
                    stack.Push(s);
                    q.Enqueue(s);
                    
                    if(list.Count <= 0)
                    {
                        list.AddFirst(s);
                    }
                    else
                    {
                        list.AddLast(s);

                    }
                }
                while(stack.Count > 0)
                {
                    string z = stack.Pop();

                    Console.Write(z + ", ");
                }
                Console.WriteLine();
                Console.WriteLine();
                while(q.Count > 0) 
                {
                    string z = q.Dequeue();
                    Console.Write(z + ", ");
                }
                Console.WriteLine();
                Console.WriteLine();
                for (LinkedListNode<string> node = list.First; node != null; node = node.Next)
                {
                    Console.Write(node.Value + ", ");
                }
                Console.WriteLine();

            }

      // Example of using Invoke+Action to call Goo() in a Threadsafe way ( thread to UI thread request ).
      Invoke(new Action( () => { Goo(); }));
    }
    public void Goo()
    {
      WriteLine($"Goo Invoked");
    }
  }
  class Person : IComparable
  {
    public enum ESize { Tiny, Small, Medium, Large, Huge}
    static Faker _faker = new Faker();
    static List<string> _level = new List<string>() { "novice", "intermediate", "pro", "expert" };
    public string First { get; private set; }
    public string Last { get; private set; }
    public double dValue { get; private set; }
    public string Level { get; private set; }
    public int iValue { get; private set; }
    public Person()
    {
      First = _faker.Name.FirstName();
      Last = _faker.Name.LastName();
      dValue = _faker.Random.Double(0, 20);
      Level = _faker.PickRandom(_level);
      iValue = _faker.Random.Number(100, 1000);
      _faker.PickRandom<ESize>();
    }
        public override bool Equals(object obj)
        {
            if (!(obj is Person p))
                return false;

            return this.Last.First() == p.Last.First();
        }
        public int CompareTo(object obj)
        {
            if(!(obj is Person person))
                return -1;

            return 1;
        }
        public override int GetHashCode()
        {
            return 1;
        }
        public override string ToString()
    {
      return $"{First}:{Last}:{dValue}:{Level}:{iValue}";
    }
  }
}

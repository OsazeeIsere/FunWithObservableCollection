using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace FunWithObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //make a collection to observe and add new person object
            ObservableCollection<Person> people = new ObservableCollection<Person>();
            {
                new Person { FirstName = "Jason", LastName = "Isere", Age = 11 };
                new Person { FirstName = "Joan", LastName = "Isere", Age = 8 };
                new Person { FirstName = "Osas", LastName = "Isere",Age= 12 };

            };
            people.Add(new Person { FirstName = "Joy", LastName = "Jacob", Age = 3 });

            //wire up the collection change
            people.CollectionChanged += people_CollectionChanged;
            Console.ReadLine();
        }

        static void people_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //what was the action that caused the event
            Console.WriteLine("Action for this event {0}", e.Action);

            //they removed something
            if(e.Action==System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Here are the old items");
                foreach(Person p in e.OldItems)
                {
                    Console.WriteLine(p.ToString());
                }
                Console.WriteLine();

                //they added something
                if(e.Action==System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach(Person p in e.NewItems)
                    {
                        Console.WriteLine(p.ToString());

                    }
                    Console.WriteLine();
                }
            }
        }
        public enum NotifyCollectionChangedAction
        {
            Add=0,
            Remove=1,
            Replavce=2,
            Move=3,
            Reset=4,
        }
    }
}

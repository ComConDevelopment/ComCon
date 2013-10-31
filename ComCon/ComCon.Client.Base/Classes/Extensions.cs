using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace ComCon.Client.Base.Classes
{
    public static class Extensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            ObservableCollection<T> tempCollection = new ObservableCollection<T>();
            foreach (T item in enumerable)
            {
                tempCollection.Add(item);
            }
            return tempCollection;
        }
    }
}

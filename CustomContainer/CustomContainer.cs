using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomContainer
{
    internal class CustomContainer<T> : IEnumerable<T>, IComparable<CustomContainer<T>>, IEquatable<CustomContainer<T>>
    {
        public List<T> children {  get; set; }
        public CustomContainer(T arg)
        {
            children = new List<T>();
            children.Add(arg);
        }
        public CustomContainer(IEnumerable<T> args)
        {
            children = new List<T>();
            children.AddRange(args);
        }
        public void Add(T arg) 
        { 
            children.Add(arg);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)children).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)children).GetEnumerator();
        }
        public int CompareTo(CustomContainer<T>? other)
        {
            if (other == null || other.children == null)
            {
                return 1;
            }
            if(children == null)
            {
                return -1;
            }
            if(children.Count != other.children.Count)
            {
                return children.Count - other.children.Count;
            }
            else
            {
                for(int i = 0; i < children.Count(); i++)
                {
                    if (other.children[i] == null)
                    {
                        return 1;
                    }
                    else if (children[i] == null)
                    {
                        return -1;
                    }
                    else if (children[i].GetHashCode() != other.children[i].GetHashCode())
                    {
                        return children[i].GetHashCode() - other.children[i].GetHashCode();
                    }
                }
                return 0;
            }
        }
        public bool Equals(CustomContainer<T>? other)
        {
            if(other == null || other.children == null)
            { 
                return false; 
            }
            else if(children == null)
            { 
                return false; 
            }
            else
            {
                return children.SequenceEqual(other.children);
            }
        }
        public override string ToString()
        {
            string result = "";
            foreach(var child in children)
            {
                result = child.ToString() + ", ";
            }
            return result;
        }
        public void Print()
        {
            foreach(var child in children)
            {
                Console.WriteLine(child.ToString());
            }
        }
        public T this[int i]
        {
            get { return children[i]; }
            set { children[i] = value; }
        }
    }
}

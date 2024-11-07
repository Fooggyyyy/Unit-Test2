using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace Programm
{
    public class RegisterClass
    {
        public bool AddUser(string name, string phone, string gmail)
        {
            if (name.Length < 4)
                throw new Exception("Имя слишком короткое!!!");
            if (phone.Any(c => char.IsLetter(c)))
                throw new Exception("Номер телефона введен не корректно!!!");
            if (!gmail.Contains("@"))
                throw new Exception("Не корректно введен электронный адрес!!!");

            return true;
        }
    }
    [Serializable]
    public class Items<T>
    {
        List<T> ListItems = new List<T>();
        
        public Items() { }
        public Items(List<T> list) { ListItems = list; }

        public T this[int index] { get { return ListItems[index]; } set { ListItems[index] = value; } }

        public void Add(T item) { ListItems.Add(item); }
        public void Delete(T item) { ListItems.Remove(item); }
        public int Count() { return ListItems.Count(); }
        public bool Has(T item) { return ListItems.Contains(item); }
        public void Clear() { ListItems.Clear(); }
    }

    public class People
    {
        private string? _name;
        private int _age;

        public string? Name => _name;
        public int Age => _age;

        public People() { }
        public People(string _name, int _age)
        {
            this._name = _name;
            this._age = _age;
        }

        public void ReName(string _name)
        {
            this._name = _name;
        }

        public void ReAge(int _age) 
        {
            this._age = _age;
        
        }
        public void ClearPeople()
        {
            this._age = 0;
            this._name = "";
        }

        public bool SameName(People people)
        {
            if(people.Name == this._name)
                return true;
            return false;
        }
        public bool SameAge(People people)
        {
            if (people.Age == this._age)
                return true;
            return false;
        }
    }
    public static class EasyClass
    {
        public static double Get_SQRT(int x) { return Math.Sqrt(x); }
        public static string SayHello(string item)
        {
            if(item == null)
                throw new ArgumentNullException("Строка пустая");
            return "Hello, " + item;
        }
    }
    public static class Calc
    {
        
        public static int Sum(int x, int y) { return x + y; }
        public static int Minus(int x, int y) { return x - y; }
        static void Main(string[] args)
        {
         
        }
    }
}
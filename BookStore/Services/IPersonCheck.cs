using BookStore.Models;
using System.IO;
using System.Text.Json;

namespace BookStore.Services
{
    public interface IPersonCheck
    {
        bool IsChecked(string name);
    }

    public class PersonCheck : IPersonCheck
    {
        public bool IsChecked(string name)
        {
            Person p = new Person()
            {
                Id = 1,
                Name = "Вася",
                DateOfBirth = DateTime.Now                
            };            

            if (p.Name == name) return true;
            else return false;
        }
    }
}

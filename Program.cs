using System;
using System.Linq;
using Todo.Models;

namespace Todo
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateMenu();
        }

        static void CreateMenu() {
            Console.WriteLine("Press 1 to Enter New ToDo Item\nPress 2 to get list of Todo Items\nPress 3 to delete record\nPress 4 to update record\nPress 5 to exit");
            int input = int.Parse(Console.ReadLine());
            switch(input) {
                case 1: 
                    Console.WriteLine("Enter Item name");
                    var item = Console.ReadLine();
                    CreateNewItem(item);
                    break;
                case 2:
                    GetAllItems();
                    break;
                case 3:
                    Console.WriteLine("Enter Item Id to delete");
                    int id = int.Parse(Console.ReadLine());
                    DeleteRecord(id);
                    break;
                case 4:
                    Console.WriteLine("Enter Item Id to update");
                    int i = int.Parse(Console.ReadLine());
                    UpdateRecord(i);
                    break;
                default:
                    break;
                
            }
        }

        static void CreateNewItem(string item){
            using(var dbContext = new todoContext()) {
                dbContext.Add(new Item{
                    ItemName=item,
                    CreatedDate = DateTime.Now,
                    IsCompleted = false
                });
                dbContext.SaveChanges();
                Console.WriteLine("Item added successfully");
                CreateMenu();
            }
        }

        static void GetAllItems(){
            using(var dbContext = new todoContext()) {
                var itemList = dbContext.Items.ToList();
                foreach(var todo in itemList) {
                    Console.WriteLine("{0}: {1}", todo.Id, todo.ItemName);
                }
                CreateMenu();
            }
        }

        static void DeleteRecord(int id) {
            using(var dbContext = new todoContext()) {
                var item = dbContext.Items.FirstOrDefault(x=>x.Id==id);
                if(item==null) 
                {
                    Console.WriteLine("Item with entered id is not found!");
                }
                else 
                {
                    dbContext.Remove(item);
                    dbContext.SaveChanges();
                    Console.WriteLine("Item deleted successfully!");
                }
                CreateMenu();
            }
        }

        static void UpdateRecord(int id) {
            using(var dbContext = new todoContext()) {
                var item = dbContext.Items.FirstOrDefault(x=>x.Id==id);
                if(item==null) 
                {
                    Console.WriteLine("Item with entered id is not found!");
                }
                else 
                {
                    Console.WriteLine("Please enter updated item name");
                    var itemname = Console.ReadLine();
                    item.ItemName=itemname;
                    dbContext.Items.Update(item);
                    dbContext.SaveChanges();
                    Console.WriteLine("Item updated successfully!");
                }
                CreateMenu();
            }
        }
    }
}

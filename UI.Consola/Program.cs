using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var op = "";
            do
            {
                Console.WriteLine("Menu\n=====================================================================");
                Console.WriteLine("L - Listar \nM - Modificar \nD - Borrar \nC - Nuevo \nS - Salir");

                var band = true;

                do
                {
                    op = Console.ReadLine();
                    if (op != "M" && op != "D" && op != "C" && op != "S" && op != "L")
                    {
                        Console.WriteLine("ingrese valor correcto");
                        band = true;
                    }
                    else
                    {
                        band = false;
                    }
                } while (band);

                switch (op)
                {
                    case "M":
                        Edit();
                        break;
                    case "D":
                        Delete();
                        break;
                    case "C":
                        Create();
                        break;
                    case "L":
                        Listar();
                        break;
                    default:
                        break;
                }
            } while (op != "S");
        }

        public static string ReadId()
        {
            Console.WriteLine("Ingrese Id Categoria");
            var id = "";
            var band = true;
            do
            {
                id = Console.ReadLine();
                /*
                if (id < 0 )
                {
                    Console.WriteLine("Ingrese Valor Correcto");
                }
                else
                {
                    band = false;
                }
                */
            } while (!band);
            return id;
        }

        public static void Edit()
        {
            
            var customerServices = new CustomerServices();
                var id = ReadId();

                var band1 = true;
                var customer = customerServices.GetOne(ReadId());
                do
                {
                    
                    if (customer != null)
                    {
                        
                        band1 = false;
                        Console.WriteLine("Ingrese nuevo Numbre compania");
                        customer.CompanyName = Console.ReadLine();
                        Console.WriteLine("inrgese nombre del contacto");
                        customer.ContactName = Console.ReadLine();
                        Console.WriteLine("Ingrese nombre ciudad");
                        customer.City = Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("No existe cliente");
                        id = ReadId();
                    }

                } while (band1);
            customerServices.Update(customer);
        }

        public static void Delete()
        {
            var customerServices = new CustomerServices();
            var id = ReadId();
            if (customerServices.Delete(id))
            {
                Console.WriteLine("Cliente Borrado correctamente");
            }
            else
            {
                Console.WriteLine("No se pudo borrar el cliente");
            }
                           
        }

        public static void Listar()
        {
            var customerServices = new CustomerServices();
            var customers = customerServices.GetAll();

            foreach (var item in customers)
            {
                Console.WriteLine($"{item.CustomerID} {item.CompanyName} {item.ContactName} {item.City}");
            }
            Console.WriteLine("\n\n");
        }

        public static void Create()
        {
                var customerServices = new CustomerServices();
                var newCustomer = new Customer();

                Console.WriteLine("ingrese ID");
                newCustomer.CustomerID = Console.ReadLine();
                Console.WriteLine("ingrese nombre de la nombre de la compania");
                newCustomer.CompanyName = Console.ReadLine();
                Console.WriteLine("ingrese nombre de contacto");
                newCustomer.ContactName = Console.ReadLine();
                Console.WriteLine("ingrese ciudad:");
                newCustomer.City = Console.ReadLine();

                customerServices.Save(newCustomer);

                Console.WriteLine("Categoria guardada correctamente \n\n");
        }



    }
}


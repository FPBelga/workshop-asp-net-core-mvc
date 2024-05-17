using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="Nome é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} Tamanho do nome deve está entre {2} e {1}")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Email é obrigatório")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Entre com email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Data de aniversário é obrigatório")]
        [Display(Name = "Data Aniversário")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "Salario é obrigatório")]
        [Display(Name = "Salario Base")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} O salario deve ser entre {1} to {2}")]
        public double BaseSalary { get; set; }
        
        public Department Department { get; set; }
        
        public int DepartmentId { get; set; }
        
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthdate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            Birthdate = birthdate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) 
        {
            Sales.Add(sr);
        }
        public void RemoveSales(SalesRecord sr) 
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) 
        { 
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final)
                        .Sum(sr => sr.Amount);
        }


    }
}

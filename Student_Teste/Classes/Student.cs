using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Teste.Classes
{
    internal class Student
    {
        public int Id { get; set; }
        public string Peca { get; set; }
        public string Tipo { get; set; }

        public Student(int id, string peca, string tipo)
        {
            Id = id;
            Peca = peca;
            Tipo = tipo;
        }
    }
}

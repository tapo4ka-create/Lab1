using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogic
{
    public class TeacherManager
    {
        private List<Teacher> teachers = new List<Teacher>();
        private int nextId = 1;

        //создание получается
        public void AddTeacher(string name, string subject, int experience)
        {
            teachers.Add(new Teacher
            {
                Id = nextId++,
                Name = name,
                Subject = subject,
                Experience = experience
            });
        }
        //чтение получается
        public List<Teacher> GetAllWorkers()
        {
            return teachers;
        }
        //удаление получается
        public bool RemoveTeacher(int id)
        {
            var teacher = teachers.Find(t => t.Id == id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
                return true;
            }
            return false;
        }
        //изменение получается
        public bool UpdateTeacher(int id, string name, string subject, int experience)
        {
            var teacher = teachers.Find(t => t.Id == id);
            if (teacher != null)
            {
                teacher.Name = name;
                teacher.Subject = subject;
                teacher.Experience = experience;
                return true;
            }
            return false;
        }
        //группировка по предметам
        public Dictionary<string, List<Teacher>> GroupBySubject()
        {
            var result = new Dictionary<string, List<Teacher>>();
            foreach (var teacher in teachers)
            {
                if (!result.ContainsKey(teacher.Subject))
                    result[teacher.Subject] = new List<Teacher>();
                result[teacher.Subject].Add(teacher);
            }
            return result;
        }
        //группировка по стажу
        public List<Teacher> GetTeachersByExperience(int minExperience)
        {
            return teachers.FindAll(t => t.Experience >= minExperience);
        }










    }
}


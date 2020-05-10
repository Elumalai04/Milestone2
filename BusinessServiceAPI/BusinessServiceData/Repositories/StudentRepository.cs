using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BusinessServiceDomain;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessServiceData.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly BusinessServiceDbContext _dbContext;

        public StudentRepository(BusinessServiceDbContext context)
        {
            _dbContext = context;
        }

        public async Task<StudentViewModel> GetAsync(int id)
        {
            //If the value is a simple get from a single table
            //return await _dbContext.Student.FirstOrDefaultAsync(e => e.Id == id);

            //If the there is a foriegn key value
            return await (
                         from student in _dbContext.StudentViewModels
                         join school in _dbContext.SchoolViewModels on student.SchoolId equals school.Id into temp
                         from m in temp
                         where student.Id == id

                         select new StudentViewModel
                         {
                             Id = student.Id,
                             Name = student.Name,
                             Gender = student.Gender,
                             DateOfBirth = student.DateOfBirth,
                             Email = student.Email,
                             Address = student.Address,
                             PhoneNumber = student.PhoneNumber,
                             SchoolId = student.SchoolId,
                             SchoolName = m.Name
                         }
                                 ).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            return await (from student in _dbContext.StudentViewModels
                          join school in _dbContext.SchoolViewModels on student.SchoolId equals school.Id into temp
                          from m in temp

                          select new StudentViewModel
                          {
                              Id = student.Id,
                              Name = student.Name,
                              Gender = student.Gender,
                              DateOfBirth = student.DateOfBirth,
                              Email = student.Email,
                              Address = student.Address,
                              PhoneNumber = student.PhoneNumber,
                              SchoolId = student.SchoolId,
                              SchoolName = m.Name
                          }
                                 ).ToListAsync();

            //For selectig all from single table
            //return await _dbContext.Student.ToListAsync();
        }

        public async Task<int> InsertAsync(StudentViewModel student)
        {
            _dbContext.StudentViewModels.Add(student);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(StudentViewModel student)
        {
            _dbContext.Update(student);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            var student = _dbContext.StudentViewModels.FirstOrDefault(e => e.Id == id);
            _dbContext.StudentViewModels.Remove(student);
            return await _dbContext.SaveChangesAsync();
        }
    }
}

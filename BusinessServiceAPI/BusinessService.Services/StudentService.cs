using BusinessServiceData.Repositories;
using BusinessServiceDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessService.Services
{
   
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public async Task<StudentViewModel> GetAsync(int id)
        {
            return await studentRepository.GetAsync(id);
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllAsync()
        {
            return await studentRepository.GetAllAsync();
        }

        public async Task<int> InsertAsync(StudentViewModel student)
        {
            return await studentRepository.InsertAsync(student);
        }

        public async Task<int> UpdateAsync(StudentViewModel student)
        {
            return await studentRepository.UpdateAsync(student);
        }
        public async Task<int> DeleteAsync(int id)
        {
            return await studentRepository.DeleteAsync(id);
        }
    }





}

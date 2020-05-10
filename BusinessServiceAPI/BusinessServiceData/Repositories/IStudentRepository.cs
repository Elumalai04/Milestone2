using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessServiceDomain;

namespace BusinessServiceData.Repositories
{
       public interface IStudentRepository
    {
        Task<StudentViewModel> GetAsync(int id);

        Task<IEnumerable<StudentViewModel>> GetAllAsync();

        Task<int> InsertAsync(StudentViewModel student);

        Task<int> UpdateAsync(StudentViewModel student);

        Task<int> DeleteAsync(int id);
    }
}

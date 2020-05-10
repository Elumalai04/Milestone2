using BusinessServiceDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessService.Services
{
    public interface IStudentService
    {
        Task<StudentViewModel> GetAsync(int id);

        Task<IEnumerable<StudentViewModel>> GetAllAsync();

        Task<int> InsertAsync(StudentViewModel student);

        Task<int> UpdateAsync(StudentViewModel student);

        Task<int> DeleteAsync(int id);
    }
}

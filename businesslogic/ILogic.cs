using BusinessLogic.DTO;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface ILogic
    {
        Task<IEnumerable<ModelDTO>> GetModelsAsync();
        Task<ModelDTO> AddModelAsync(ModelDTO modelDto);
        Task DeleteModelAsync(int id);
    }
}

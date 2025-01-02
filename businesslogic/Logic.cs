using DataAccess;
using DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BusinessLogic.DTO;

namespace BusinessLogic
{
    public class Logic : ILogic
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public Logic(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModelDTO>> GetModelsAsync()
        {
            var models = await _context.Models.ToListAsync();
            return _mapper.Map<IEnumerable<ModelDTO>>(models); // Use AutoMapper to map to DTOs
        }

        public async Task<ModelDTO> AddModelAsync(ModelDTO modelDto)
        {
            var model = _mapper.Map<Model>(modelDto); // Map DTO to entity
            _context.Models.Add(model);
            await _context.SaveChangesAsync();
            return _mapper.Map<ModelDTO>(model); // Map back to DTO
        }

        public async Task DeleteModelAsync(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model != null)
            {
                _context.Models.Remove(model);
                await _context.SaveChangesAsync();
            }
        }
        }
    }

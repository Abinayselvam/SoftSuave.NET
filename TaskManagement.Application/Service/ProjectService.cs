using AutoMapper;
using TaskManagement.Common.DTOs.RequestDTO;
using TaskManagement.Common.DTOs.ResponseDTO;
using TaskManagement.Data.Entities;
using TaskManagement.Data.IRepositories;

namespace TaskManagement.Application.Service
{
    public class ProjectService
    {
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AddProjectResponseDTO> AddProjectAsync(AddProjectRequestDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            await _repository.AddAsync(project);
            return _mapper.Map<AddProjectResponseDTO>(project);
        }

        public async Task<List<AddProjectResponseDTO>> GetProjectsAsync()
        {
            var projects = await _repository.GetAllAsync();
            return _mapper.Map<List<AddProjectResponseDTO>>(projects);
        }

        public async Task<AddProjectResponseDTO?> GetByIdAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return null;
            return _mapper.Map<AddProjectResponseDTO>(project);
        }

        public async Task<AddProjectResponseDTO?> UpdateAsync(int id, AddProjectRequestDto dto)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return null;

            _mapper.Map(dto, project);
            await _repository.UpdateAsync(project);
            return _mapper.Map<AddProjectResponseDTO>(project);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return false;

            await _repository.DeleteAsync(project);
            return true;
        }

        public async Task<List<AddProjectResponseDTO>> GetActiveProjectsAsync()
        {
            var projects = await _repository.GetActiveProjectsAsync();
            return _mapper.Map<List<AddProjectResponseDTO>>(projects);
        }
    }




}

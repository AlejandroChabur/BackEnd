using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class IdentificationTypeService
    {
        private readonly IdentificationTypeRepository _identificationTypeRepository;

        public IdentificationTypeService(IdentificationTypeRepository identificationTypeRepository)
        {
            _identificationTypeRepository = identificationTypeRepository;
        }

        public async Task<IdentificationType> GetIdentificationTypeByIdAsync(int id)
        {
            return await _identificationTypeRepository.GetIdentificationTypeByIdAsync(id);
        }

        public async Task CreateIdentificationTypeAsync(IdentificationType identificationType)
        {
            await _identificationTypeRepository.CreateIdentificationTypeAsync(identificationType);
        }

        public async Task<IEnumerable<IdentificationType>> GetAllIdentificationTypesAsync()
        {
            return await _identificationTypeRepository.GetAllIdentificationTypesAsync();
        }

        public async Task UpdateIdentificationTypeAsync(IdentificationType identificationType)
        {
            await _identificationTypeRepository.UpdateIdentificationTypeAsync(identificationType);
        }

        public async Task DeleteIdentificationTypeAsync(int id)
        {
            await _identificationTypeRepository.DeleteIdentificationTypeAsync(id);
        }
    }
}

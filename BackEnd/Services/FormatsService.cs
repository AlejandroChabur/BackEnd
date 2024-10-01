using BackEnd.Model;
using BackEnd.Repository;

namespace BackEnd.Services
{
    public class FormatsService
    {
        private readonly FormatsRepository _formatsRepository;

        public FormatsService(FormatsRepository formatsRepository)
        {
            _formatsRepository = formatsRepository;
        }

        public async Task<Formats> GetFormatByIdAsync(int id)
        {
            return await _formatsRepository.GetFormatByIdAsync(id);
        }

        public async Task CreateFormatAsync(Formats format)
        {
            await _formatsRepository.CreateFormatAsync(format);
        }

        public async Task<IEnumerable<Formats>> GetAllFormatsAsync()
        {
            return await _formatsRepository.GetAllFormatsAsync();
        }

        public async Task UpdateFormatAsync(Formats format)
        {
            await _formatsRepository.UpdateFormatAsync(format);
        }

        public async Task DeleteFormatAsync(int id)
        {
            await _formatsRepository.DeleteFormatAsync(id);
        }
    }
}

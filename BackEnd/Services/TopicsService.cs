using BackEnd.Model;
using BackEnd.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface ITopicsService
    {
        Task<IEnumerable<Topics>> GetAllTopicsAsync();
        Task<Topics> GetTopicByIdAsync(int id);
        Task CreateTopicAsync(Topics topic);
        Task UpdateTopicAsync(Topics topic);
        Task DeleteTopicAsync(int id);
    }

    public class TopicsService
    {
        private readonly TopicsRepository _topicsRepository;

        public TopicsService(TopicsRepository topicsRepository)
        {
            _topicsRepository = topicsRepository;
        }

        public async Task<IEnumerable<Topics>> GetAllTopicsAsync()
        {
            return await _topicsRepository.GetAllTopicsAsync();
        }

        public async Task<Topics> GetTopicByIdAsync(int id)
        {
            return await _topicsRepository.GetTopicByIdAsync(id);
        }

        public async Task CreateTopicAsync(Topics topic)
        {
            await _topicsRepository.CreateTopicAsync(topic);
        }

        public async Task UpdateTopicAsync(Topics topic)
        {
            await _topicsRepository.UpdateTopicAsync(topic);
        }

        public async Task DeleteTopicAsync(int id)
        {
            await _topicsRepository.DeleteTopicAsync(id);
        }
    }
}

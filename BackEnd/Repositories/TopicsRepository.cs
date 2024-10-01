using BackEnd.Context;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public interface ITopicsRepository
    {
        Task<IEnumerable<Topics>> GetAllTopicsAsync();
        Task<Topics> GetTopicByIdAsync(int id);
        Task CreateTopicAsync(Topics topic);
        Task UpdateTopicAsync(Topics topic);
        Task DeleteTopicAsync(int id);
    }
    public class TopicsRepository : ITopicsRepository
    {
        private readonly TestDbContext _context;

        public TopicsRepository(TestDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Topics>> GetAllTopicsAsync()
        {
            return await _context.Topics
                //.Include(t => t.BooksXTopics)
                .Where(s => s.IsDeleted)
                .ToListAsync();
        }

        public async Task<Topics> GetTopicByIdAsync(int id)
        {
            var topic = await _context.Topics
                .Where(s => s.IsDeleted)
                //.Include(t => t.BooksXTopics)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (topic == null)
            {
                throw new KeyNotFoundException($"Topic with ID {id} not found.");
            }

            return topic; // Devolver la instancia del tema encontrado
        }

        public async Task CreateTopicAsync(Topics topic)
        {
            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTopicAsync(Topics topic)
        {
            var existingTopic = await _context.Topics.FindAsync(topic.Id);

            if (existingTopic != null)
            {
                existingTopic.TopicName = topic.TopicName;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Topic with ID {topic.Id} not found.");
            }
        }

        public async Task DeleteTopicAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic != null)
            {
                _context.Topics.Remove(topic);
                await _context.SaveChangesAsync();
            }
        }
    }
}

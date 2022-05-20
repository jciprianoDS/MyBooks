using MyBooks.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyBooks.Data.Services
{
    public class LogsService
    {
        private AppDBContext _context;
        public LogsService(AppDBContext context)
        {
            _context = context;
        }

        public List<Log> GetAllLogsFromDB() => _context.Logs.ToList();
    }
}

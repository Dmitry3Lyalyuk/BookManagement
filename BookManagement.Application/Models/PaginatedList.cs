using Microsoft.EntityFrameworkCore;

namespace BookManagement.Application.Models
{
    public class PaginatedList<T>
    {
        public IReadOnlyCollection<T> Items { get; }
        public int PageNumber { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public PaginatedList(IReadOnlyCollection<T> items, int pagenumber, int count, int pagesize)
        {
            Items = items;
            PageNumber = pagenumber;
            TotalPages = (int)Math.Ceiling(count / (double)pagesize);
            TotalCount = count;
        }

        public bool HasPreviusPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();

            var item = await source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedList<T>(item, pageNumber, count, pageSize);
        }

    }
}

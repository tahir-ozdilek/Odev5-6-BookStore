﻿using BookStorePtk.DBOperations;

namespace BookStorePtk.Applications.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public DeleteBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(book => book.Id == BookId);

            if (book is null)
                throw new InvalidOperationException("Book doesn't exist!");


            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}

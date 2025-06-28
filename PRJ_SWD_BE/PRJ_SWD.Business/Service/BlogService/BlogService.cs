using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRJ_SWD.DAL.DTO;
using PRJ_SWD.DAL.Models;
using PRJ_SWD.DAL.Repository;

namespace PRJ_SWD.Business.Service.BlogService
{
    public class BlogService : IBlogService
    {
        public BlogRepository repository;
        public BlogService(BlogRepository repository)
        {
            this.repository = repository;
        }
        public Blog AddReservation(Blog reservation)
        {
            throw new NotImplementedException();
        }

        public Blog DeleteReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<BlogDTO> GetAllReservations()
        {
          return  repository.List();
        }

        public Blog GetReservationById(int id)
        {
           return repository.GetById(id);
        }

        public Blog UpdateReservation(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}

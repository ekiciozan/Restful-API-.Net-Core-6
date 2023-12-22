
using RestfulWebApiEx.Models;
using RestfulWebApiEx.Repository;

namespace RestfulWebApiEx.Service
{
    public class PostManager : IPostService
    {
        private readonly IGenericRepository<Posts> _repository;
        public PostManager(IGenericRepository<Posts> repository)
        {
            _repository = repository ;
        }
        //Dependecy Injection ile Inject ettik. 
        public Posts Create(Posts post)
        {
            //Logic işlemler yapılabilir , kontroller eklenebilir.
            return  _repository.Add(post);
        }

        public Posts GetPost(int id)
        {
            //boşsa şunu gödner gibi işlemler yapılabilir.
            return _repository.GetById(id);
        }

        public List<Posts> GetAll()
        {
             return _repository.GetAll();
        }

        public Posts DeleteProduct(int id)
        {
            //boşsa şunu gödner gibi işlemler yapılabilir.
            var deletePost = _repository.GetById(id);
            return _repository.Delete(deletePost);
        }

        public Posts Update(int id , Posts post)
        {
            return _repository.UpdateById(post,id);
        }
    }
}
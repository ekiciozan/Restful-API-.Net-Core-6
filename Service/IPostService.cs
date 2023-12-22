
using RestfulWebApiEx.Models;

namespace RestfulWebApiEx.Service
{
    public interface IPostService
    {
        Posts Create(Posts post);//Postları create edecek olan method.
        Posts GetPost(int id);//Postu dönecek olan method
        List<Posts> GetAll(); //Tüm hepsini getir
        Posts DeleteProduct(int id);//Delete edecek method tanımı
        Posts Update(int id,Posts post);//Postu dönecek olan method

    }
}
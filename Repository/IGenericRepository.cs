using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulWebApiEx.Models;
using System.Collections.Generic;

namespace RestfulWebApiEx.Repository
{
    //GenericRepo olsuturduk <T> ile. Yani Posts Tablosu içinde aynı işlemi yapabilecek Y tablosu için de.
    //Gönderilen T sınıf olacak ve newlenebilir olacak. Kısıtı ekeldik where ile.
    public interface IGenericRepository<T> where T: class, new() 
    {
        //CRUD
        // T tipinde bir Add methodu ve T tipinde bir parametre alıyor.
        // Posts Add (Posts entity) gibi.
        T Add (T entity);
        T Delete (T entity);

        T GetById(int id);

        //Liste dönüyor T tipinde.
        List<T> GetAll();

        T UpdateById(T entity, int id);
        
    }
}
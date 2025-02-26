using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Nutrition.Models.DataBase
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        // Buscar todos os registros de forma síncrona
        public IEnumerable<T> All()
        {
            return _dbSet.ToList();  // Método síncrono ToList()
        }

        public IQueryable<T> AllNotList()
        {
            return _dbSet;
        }

        // Buscar por ID de forma síncrona
        public T GetById(int id)
        {
            return _dbSet.Find(id);  // Método síncrono Find()
        }

        // Adicionar um novo registro de forma síncrona
        public void Add(T entity)
        {
            _dbSet.Add(entity);  // Método síncrono Add()
            _context.SaveChanges();  // Método síncrono SaveChanges()
        }

        // Atualizar um registro existente de forma síncrona
        public void Update(T entity)
        {
            _dbSet.Update(entity);  // Método síncrono Update()
            _context.SaveChanges();  // Método síncrono SaveChanges()
        }

        // Excluir um registro por ID de forma síncrona
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);  // Método síncrono Find()
            if (entity != null)
            {
                _dbSet.Remove(entity);  // Método síncrono Remove()
                _context.SaveChanges();  // Método síncrono SaveChanges()
            }
        }

        // Buscar o primeiro item que satisfaça um critério de forma síncrona
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);  // Método síncrono FirstOrDefault()
        }

        // Verificar se existe algum registro que satisfaça um critério de forma síncrona
        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);  // Método síncrono Any()
        }

        // Buscar registros que satisfaçam um critério de forma síncrona
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();  // Método síncrono Where() e ToList()
        }

        // Contar o número de registros de forma síncrona
        public int Count()
        {
            return _dbSet.Count();  // Método síncrono Count()
        }

        // Realizar paginação de forma síncrona
        public IEnumerable<T> GetPaged(int page, int pageSize)
        {
            return _dbSet.Skip((page - 1) * pageSize).Take(pageSize).ToList();  // Métodos síncronos Skip() e Take()
        }

        // Ordenar os registros de forma síncrona
        public IEnumerable<T> GetOrdered<TKey>(Expression<Func<T, TKey>> orderBy, bool descending = false)
        {
            return descending ?
                _dbSet.OrderByDescending(orderBy).ToList() :  // Método síncrono OrderByDescending()
                _dbSet.OrderBy(orderBy).ToList();  // Método síncrono OrderBy()
        }
    }

    public interface IRepository<T> where T : class
    {
        // Método para buscar todos os registros
        IEnumerable<T> All();
        IQueryable<T> AllNotList();

        // Método para buscar por ID
        T GetById(int id);

        // Método para adicionar um novo registro
        void Add(T entity);

        // Método para atualizar um registro existente
        void Update(T entity);

        // Método para excluir um registro por ID
        void Delete(int id);

        // Método para buscar o primeiro item que satisfaça um critério
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        // Método para verificar se existe algum registro que satisfaça um critério
        bool Exists(Expression<Func<T, bool>> predicate);

        // Método para buscar registros que satisfaçam um critério
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        // Método para contar o número de registros
        int Count();

        // Método para realizar paginação
        IEnumerable<T> GetPaged(int page, int pageSize);

        // Método para ordenar os registros
        IEnumerable<T> GetOrdered<TKey>(Expression<Func<T, TKey>> orderBy, bool descending = false);

    }
}

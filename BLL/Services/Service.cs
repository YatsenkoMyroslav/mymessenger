using AutoMapper;
using DAL.Repository;

namespace BLL.Services;

public class Service<T1, T2> : IService<T1, T2>
    where T2 : class
    where T1 : class
    {

        protected IRepository<T1> repository;
        protected IMapper mapper;
        public Service(IRepository<T1> repository)
        {
            this.repository = repository;
            MapperConfiguration configuration = new MapperConfiguration(opt =>
            {
                opt.CreateMap<T1, T2>();
                opt.CreateMap<T2, T1>();
            });
            mapper = new Mapper(configuration);
        }

        public Task<T2> AddAsync(T2 entity)
        {
            return Task.Run(() =>
            {
                T1 newEntity = mapper.Map<T2, T1>(entity);
                repository.Add(newEntity);
                return mapper.Map<T1, T2>(newEntity);
            });
        }

        public Task<T2> DeleteAsync(int id)
        {
            return Task.Run(() =>
            {
                T1 entity = repository.GetById(id);
                if (entity != null)
                {
                    repository.Remove(entity);
                }
                return mapper.Map<T1, T2>(entity);
            });
        }

        public Task<IEnumerable<T2>> GetAllAsync()
        {
            return Task.Run(() =>
            {
                var allItems = (IEnumerable<T2>)repository
                        .GetAll()
                        .Select(x => mapper.Map<T1, T2>(x));
                return allItems;
            });
        }

        public Task UpdateAsync(T2 entity)
        {
            return Task.Run(() =>
            {
                T1 t1Entity = mapper.Map<T2, T1>(entity);
                repository.Update(t1Entity);
            });
        }
        public void Update(T2 entity)
        {
            repository.Update(mapper.Map<T2, T1>(entity));
        }

        public Task AddRangeAsync(IEnumerable<T2> list)
        {
            return Task.Run(() =>
            {
                foreach (var item in list)
                {
                    T1 newItem = mapper.Map<T2, T1>(item);
                    repository.Add(newItem);
                }
            });
        }
        public T2 Get(int id)
        {
            return mapper.Map<T1, T2>(repository.GetById(id));
        }

        public Task<T2> GetAsync(int id)
        {
            return Task.Run(() => Get(id));
        }
    }
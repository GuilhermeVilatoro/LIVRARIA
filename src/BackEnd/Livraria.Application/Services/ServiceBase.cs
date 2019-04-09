using AutoMapper;
using Livraria.Application.Services.Interfaces;
using Livraria.Domain.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.Application.Services
{
    public class ServiceBase<TViewModel, TModel> : IServiceBase<TViewModel> where TViewModel : class where TModel : class
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<TModel> _repository;

        public ServiceBase(IMapper mapper,
            IRepositoryBase<TModel> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public void Add(TViewModel entityViewModel)
        {
            var entity = _mapper.Map<TModel>(entityViewModel);
            _repository.Add(entity);
        }

        public void Update(TViewModel entityViewModel)
        {
            var entity = _mapper.Map<TModel>(entityViewModel);
            _repository.Update(entity);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(TViewModel entityViewModel)
        {
            var entity = _mapper.Map<TModel>(entityViewModel);
            _repository.Delete(entity);
        }

        public TViewModel GetById(int id)
        {
            var entityViewModel = _repository.GetById(id);
            return _mapper.Map<TViewModel>(entityViewModel);
        }

        public IEnumerable<TViewModel> GetAll()
        {
            return _repository.GetAll().Select(x => _mapper.Map<TViewModel>(x));
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.AppServices
{
    public interface ILivroAppService
    {
        Task<IEnumerable<LivroViewModel>> GetAllAsync(string search);
        Task<LivroViewModel> GetByIdAsync(int id);
        Task<int> AddAsync(LivroViewModel livroViewModel);
        Task EditAsync(LivroViewModel livroViewModel);
        Task RemoveAsync(LivroViewModel livroViewModel);
    }
}
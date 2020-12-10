using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Models;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class AutorRepository : CrudRepository<AutorEntity>, IAutorRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public AutorRepository(
            BibliotecaContext bibliotecaContext) 
            : base(bibliotecaContext)
        {
            _bibliotecaContext = bibliotecaContext;
        }

        public override async Task<IEnumerable<AutorEntity>> GetAllAsync(string search)
        {
            //brincadeiras de relatórios com Linqs
            //await AutorComMaiorQuantidadeDeLivrosAsync();
            //await AutorComLivroPublicadoMaisRecenteAsync();

            if (string.IsNullOrWhiteSpace(search))
            {
                return _bibliotecaContext.Autores;
            }

            //Utilizem o mouseover para através da opção "DebugView/Query" visualizar a query gerada pelo Linq
            var result = _bibliotecaContext.Autores.Where(x => x.Nome.Contains(search));

            //Como alternativa, a query tbm pode ser acessada pelo método de extensão abaixo
            var sql = result.ToQueryString();

            return result;
        }

        //métodos deixados de exemplo
        public async Task<AutorEntity> AutorComMaiorQuantidadeDeLivrosAsync()
        {
            var autorEntity =
                await _bibliotecaContext
                    .Autores
                    .OrderByDescending(x => x.Livros.Count)
                    .FirstOrDefaultAsync();

            return autorEntity;
        }

        //métodos deixados de exemplo
        public async Task<AutorEntity> AutorComLivroPublicadoMaisRecenteAsync()
        {
            var autorEntity =
                await _bibliotecaContext
                    .Autores
                    .SelectMany(x => x.Livros)
                    .OrderByDescending(x => x.Publicacao)
                    .Select(x => x.Autor)
                    .FirstOrDefaultAsync();

            //MoreLinq
            return autorEntity;
        }
    }
}

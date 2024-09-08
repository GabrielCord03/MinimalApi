﻿using MinimalApi.Model;

namespace MinimalApi.Services
{
        public interface IServiceVoo
        {
            Task<IEnumerable<Voo>> GetVoosAsync(string Origem, string Destino, DateTime DataEmbarque, DateTime? DataRetorno);
            Task<Voo> GetVooByIdAsync(int id);
            Task AddVooAsync(Voo voo);
            Task UpdateVooAsync(Voo voo);
            Task DeleteVooAsync(int id);
        }
}

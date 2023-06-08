using BarbeariaDomain.Entities;
using BarbeariaData;

namespace BarbeariaData.Contexto
{
    public class BarbeariaService
    {
        private readonly BarberShopContext dbContext;

        public BarbeariaService(BarberShopContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AgendarCorte(int clienteId, int funcionarioId, int servicoId, DateTime dataHora)
        {
            var cliente = dbContext.Clientes.Find(clienteId);
            if (cliente == null)
            {
                // Tratar o cliente não encontrado
                return;
            }

            var agendamento = new Agendamento
            {
                
               
                DataHora = dataHora,
                
            };

            dbContext.Agendamentos.Add(agendamento);
            dbContext.SaveChanges();
        }
    }
}

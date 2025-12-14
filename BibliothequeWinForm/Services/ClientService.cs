using BibliothequeWinForm.Data;
using BibliothequeWinForm.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliothequeWinForm.Services
{
    public class ClientService
    {
        private readonly BibliothequeContext context = new BibliothequeContext();

        public void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public List<Client> GetAllClients()
        {
            return context.Clients.ToList();
        }

        public Client GetClientById(int id)
        {
            return context.Clients.Find(id);
        }

        public void UpdateClient(Client client)
        {
            context.Entry(client).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client != null)
            {
                context.Clients.Remove(client);
                context.SaveChanges();
            }
        }
    }
}

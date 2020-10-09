using LocadoraDeFilmes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocadoraDeFilmes.Services
{
    public interface IClienteService
    {
        List<Cliente> GetClientes();
        Cliente InsertCliente(Cliente NewCliente);
        Cliente DeleteCliente(int Id);
        Cliente UpdateCliente(Cliente NewCliente);
    }
}

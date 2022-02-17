using AutoMapper;
using CRUDCliente.Core.Abstractions.Clientes.GetClientes;
using CRUDCliente.Domain.Clientes;

namespace CRUDCliente.Core.Handlers.Clientes.GetClientes.Perfil
{
    public class GetClientesResponsePerfil : Profile
    {
        public GetClientesResponsePerfil()
        {
            CreateMap<Cliente, GetClientesResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.Celular));
        }
    }
}
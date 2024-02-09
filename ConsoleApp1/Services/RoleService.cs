
using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;

namespace ConsoleApp1.Services;

internal class RoleService
{
    private readonly RoleRepository _roleRepository;

    public RoleService(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public RoleEntity CreateRole(string role)
    {
        var roleEntity = _roleRepository.Get(x => x.Role == role);
        roleEntity ??= _roleRepository.Create(new RoleEntity { Role = role });

        return roleEntity;
    }

    public RoleEntity GetRoleByName(string role) 
    {
        var roleEntity = _roleRepository.Get(x => x.Role == role);
        return roleEntity;
    }

    public RoleEntity GetRoleById(string role)
    {
        var roleEntity = _roleRepository.Get(x => x.Role == role);
        return roleEntity;
    }

    public IEnumerable<RoleEntity> GetAllRoles() 
    { 
        var roles = _roleRepository.GetAll();
        return roles;
    }

    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        var updatedRoleEntity = _roleRepository.Update(x => x.Id == roleEntity.Id, roleEntity);
        return updatedRoleEntity;
    }

    public void DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
    }
}

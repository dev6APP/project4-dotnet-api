using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public interface IUnitOfWork
    {
        IGenericRepository<Admin> AdminRepository { get; }
        IGenericRepository<Language> LanguageRepository { get; }
        IGenericRepository<FieldOwner> FieldOwnerRepository { get; }
        IGenericRepository<Farm> FarmRepository { get; }
        IGenericRepository<Field> FieldRepository { get; }
        IGenericRepository<PhotoData> PhotoDataRepository { get; }
        IGenericRepository<Boundary> BoundaryRepository { get; }
        IGenericRepository<Worker> WorkerRepository { get; }
        IGenericRepository<Permission> PermissionRepository { get; }
        IGenericRepository<Coordinate> CoordinateRepository { get; }
        IGenericRepository<FarmStaff> FarmStaffRepository { get; }


        Task SaveChangesAsync();
    }
}

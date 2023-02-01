using BackEnd.DAL.Repositories;
using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BackEndContext _context;
        public UnitOfWork(BackEndContext context)
        {
            _context = context;
        }

        private IGenericRepository<Admin> adminRepository;
        public IGenericRepository<Admin> AdminRepository
        {
            get
            {
                if (adminRepository == null)
                {
                    adminRepository = new AdminRepository(_context);
                }

                return adminRepository;
            }
        }

        private IGenericRepository<Language> languageRepository;
        public IGenericRepository<Language> LanguageRepository
        {
            get
            {
                if (languageRepository == null)
                {
                    languageRepository = new LanguageRepository(_context);
                }

                return languageRepository;
            }
        }

        private IGenericRepository<FieldOwner> fieldOwnerRepository;
        public IGenericRepository<FieldOwner> FieldOwnerRepository
        {
            get
            {
                if (fieldOwnerRepository == null)
                {
                    fieldOwnerRepository = new FieldOwnerRepository(_context);
                }

                return fieldOwnerRepository;
            }
        }

        private IGenericRepository<Field> fieldRepository;
        public IGenericRepository<Field> FieldRepository
        {
            get
            {
                if (fieldRepository == null)
                {
                    fieldRepository = new FieldRepository(_context);
                }

                return fieldRepository;
            }
        }

        private IGenericRepository<Boundary> boundaryRepository;
        public IGenericRepository<Boundary> BoundaryRepository
        {
            get
            {
                if (boundaryRepository == null)
                {
                    boundaryRepository = new BoundaryRepository(_context);
                }

                return boundaryRepository;
            }
        }

        private IGenericRepository<FarmStaff> farmStaffRepository;
        public IGenericRepository<FarmStaff> FarmStaffRepository
        {
            get
            {
                if (farmStaffRepository == null)
                {
                    farmStaffRepository = new FarmStaffRepository(_context);
                }

                return farmStaffRepository;
            }
        }

        private IGenericRepository<PhotoData> photoDataRepository;
        public IGenericRepository<PhotoData> PhotoDataRepository
        {
            get
            {
                if (photoDataRepository == null)
                {
                    photoDataRepository = new PhotoDataRepository(_context);
                }

                return photoDataRepository;
            }
        }

        private IGenericRepository<Farm> farmRepository;
        public IGenericRepository<Farm> FarmRepository
        {
            get
            {
                if (farmRepository == null)
                {
                    farmRepository = new FarmRepository(_context);
                }

                return farmRepository;
            }
        }

        private IGenericRepository<Worker> workerRepository;
        public IGenericRepository<Worker> WorkerRepository
        {
            get
            {
                if (workerRepository == null)
                {
                    workerRepository = new WorkerRepository(_context);
                }

                return workerRepository;
            }
        }

        private IGenericRepository<Permission> permissionRepository;
        public IGenericRepository<Permission> PermissionRepository
        {
            get
            {
                if (permissionRepository == null)
                {
                    permissionRepository = new PermissionRepository(_context);
                }

                return permissionRepository;
            }
        }



        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
using System;
using Code2.Models;

namespace Code2.Repositories;

public interface IFacultyRepository
{
    Task<IEnumerable<Faculty>> GetAllFacultiesAsync();
    Task AddAsync(Faculty faculty);
    Task<Faculty> GetByIdAsync(int id);
}
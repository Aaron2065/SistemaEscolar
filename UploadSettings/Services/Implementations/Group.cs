using Microsoft.EntityFrameworkCore;
using SchoolData;
using SchoolService.DTOs;
using SchoolData.Models;
using SchoolService.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolService.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationDbContext _context;

        public GroupService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GroupReadDTO>> GetAllAsync()
        {
            return await _context.Groups
                .Select(g => new GroupReadDTO
                {
                    IdGradeGroup = g.IdGradeGroup,
                    Grade = g.Grade,
                    GroupClass = g.GroupClass,
                    IdTutor = g.IdTutor
                })
                .ToListAsync();
        }

        public async Task<GroupReadDTO> GetByIdAsync(int id)
        {
            var g = await _context.Groups.FindAsync(id);
            if (g == null)
                throw new KeyNotFoundException("Grupo no encontrado");

            return new GroupReadDTO
            {
                IdGradeGroup = g.IdGradeGroup,
                Grade = g.Grade,
                GroupClass = g.GroupClass,
                IdTutor = g.IdTutor
            };
        }

        public async Task AddAsync(GroupCreateDTO dto)
        {
            var group = new Group
            {
                Grade = dto.Grade,
                GroupClass = dto.GroupClass,
                IdTutor = dto.IdTutor
            };

            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, GroupCreateDTO dto)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group == null)
                throw new KeyNotFoundException("Grupo no encontrado");

            group.Grade = dto.Grade;
            group.GroupClass = dto.GroupClass;
            group.IdTutor = dto.IdTutor;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<GroupReadDTO>> GetGroupsWithTutorAndCoursesAsync()
        {
            return await _context.Groups
                .Include(g => g.Tutor)
                .Include(g => g.IdCourse)
                .Select(g => new GroupReadDTO
                {
                    IdGradeGroup = g.IdGradeGroup,
                    Grade = g.Grade,
                    GroupClass = g.GroupClass,
                    IdTutor = g.IdTutor,
                    TutorName = g.Tutor.Employee.Name,
                    IdCourses = g.IdCourse.Select(c => c.IdCourse).ToList()
                })
                .ToListAsync();
        }
    }
}

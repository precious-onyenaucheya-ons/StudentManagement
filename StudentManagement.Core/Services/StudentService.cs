using AutoMapper;
using StudentManagement.Core.IServices;
using StudentManagement.Data.IRepositories;
using StudentManagement.Dtos.StudentDtos;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentManagement.Core.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public async Task AddStudentAsync(StudentRequestDto studentRequestDto)
        {
            var student = _mapper.Map<Student>(studentRequestDto);
            student.CreatedDate = DateTime.Now;
            student.LastUpdatedDate = DateTime.Now;
            try
            {
                await _studentRepository.AddStudentAsync(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public async Task ModifyStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new Exception();
            }
            else
            {
                try
                {
                    await _studentRepository.ModifyStudentAsync(student);
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return _mapper.Map<IEnumerable<StudentResponseDto>>(students);
        }

        public async Task<StudentResponseDto> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);
            if(student == null)
            {
                throw new ArgumentException(nameof(student));
            }
            return _mapper.Map<StudentResponseDto>(student);
        }
        public async Task RemoveStudentAsync(int id)
        {
            try
            {
                await _studentRepository.RemoveStudentAsync(id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

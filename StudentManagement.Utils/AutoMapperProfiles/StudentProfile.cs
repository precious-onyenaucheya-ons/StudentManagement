using AutoMapper;
using StudentManagement.Dtos.StudentDtos;
using StudentManagement.Models;


namespace StudentManagement.Utils.AutoMapperProfiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentResponseDto>().ReverseMap();
            CreateMap<StudentRequestDto, Student>().ReverseMap();
        }
    }
}

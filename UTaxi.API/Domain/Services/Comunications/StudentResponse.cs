using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class StudentResponse : BaseResponse
    {
        public Student Student { get; set; }
        public StudentResponse(bool success, string message, Student student) : base(success, message)
        {
            Student = student;
        }
        public StudentResponse(Student student):this(true,string.Empty,student){}
        public StudentResponse(string message):this(false,message,null){}
    }
}
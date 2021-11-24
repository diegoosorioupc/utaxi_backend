using UTaxi.API.Domain.Models;

namespace UTaxi.API.Domain.Services.Comunications
{
    public class SaveStudentResponse : BaseResponse
    {
        public Student Student { get; private set; }
        public SaveStudentResponse(bool success, string message, Student student) : base(success, message)
        {
            Student = student;
        }
        public SaveStudentResponse(Student student) : this(true, string.Empty, student){}
        public SaveStudentResponse(string message) : this(false, message, null){}
    }
}
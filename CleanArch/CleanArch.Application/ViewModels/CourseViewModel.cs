using CleanArch.Domain.Models;

namespace CleanArch.Application.ViewModels
{
    public class CourseViewModel
    {
        public IEnumerable<Course> courses { get; set; }
    }
}

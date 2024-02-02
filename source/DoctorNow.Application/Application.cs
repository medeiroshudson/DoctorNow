using System.Reflection;

namespace DoctorNow.Application;

public static class Application
{
    public static Assembly GetExecutingAssembly() => Assembly.GetExecutingAssembly();
}
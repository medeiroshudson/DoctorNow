using System.Reflection;

namespace DoctorNow.Infrastructure;

public static class Infrastructure
{
    public static Assembly GetExecutingAssembly() => Assembly.GetExecutingAssembly();
}
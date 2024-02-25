using System.Reflection;

namespace DoctorNow.Infrastructure;

public static class Infrastructure
{
    public static Assembly Assembly => Assembly.GetExecutingAssembly();
}
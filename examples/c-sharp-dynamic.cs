using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Data structure
        var codeSample1_Data = new { a = 6, b = 2 };

        // Code logic (using string interpolation)
        var codeSample1_Logic = $@"
            Console.WriteLine('data=' + JsonSerializer.Serialize(data));
            var a = data.a;
            var b = data.b;
            Console.WriteLine('a=' + a);
            Console.WriteLine('b=' + b);
            Console.WriteLine('a+b=' + (a + b));
            Console.WriteLine('a-b=' + (a - b));
            Console.WriteLine('a*b=' + (a * b));
            Console.WriteLine('a/b=' + (a / b));
        ";

        // Run the code
        RunDynamicCode(codeSample1_Logic, codeSample1_Data);
    }

    static void RunDynamicCode(string code, object data)
    {
        try
        {
            Console.WriteLine('-----------------\nInput:');
            Console.WriteLine($"Running the below code:\n--\n{code}\n--\nWith the following data:\n{JsonSerializer.Serialize(data)}");
            Console.WriteLine('-----------------\nOutput:');

            var dynamicMethod = new DynamicMethod("ExecuteCode", typeof(void), new[] { typeof(object) });
            var generator = dynamicMethod.GetILGenerator();

            // Load the data argument onto the stack
            generator.Emit(OpCodes.Ldarg_0);

            // Unbox the data object
            generator.Emit(OpCodes.Unbox_Any, data.GetType());

            // Compile the code
            var compileResult = CSharpCodeProvider.CompileAssemblyFromSource(
                new CompilerParameters(),
                new[] { code });

            // Invoke the compiled code with the data object
            var methodInfo = compileResult.CompiledAssembly.GetType("Script").GetMethod("Main");
            methodInfo.Invoke(null, new[] { data });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

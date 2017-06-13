using Microsoft.JScript;

namespace TianWen.Utility.Compiler
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Runtime.InteropServices;

    public class JsEngine
    {
        private static readonly object object_0 = new object();
        private const string string_0 = "class theEval{ public function Eval(str:String):String {return eval(str)}}";
        private const string string_1 = "theEval";
        private const string string_2 = "Eval";
        private static readonly Type type_0 = new object().GetType();

        static JsEngine()
        {
            smethod_0(ref object_0, ref type_0, "class theEval{ public function Eval(str:String):String {return eval(str)}}", "theEval");
        }

        public static object Eval(string expression)
        {
            return type_0.InvokeMember("Eval", BindingFlags.InvokeMethod, null, object_0, new object[] { expression });
        }

        public static object Eval(string expression, Type theType)
        {
            return Microsoft.JScript.Convert.Coerce(type_0.InvokeMember("Eval", BindingFlags.InvokeMethod, null, object_0, new object[] { expression }), theType);
        }

        public static object Eval(string expression, NameValueCollection paramCollection, System.Func<string, NameValueCollection, string, string> func = null)
        {
            if (func == null)
            {
                func = new System.Func<string, NameValueCollection, string, string>(ResolveExpression.Resolve);
            }
            string str = func(expression, paramCollection, null);
            return type_0.InvokeMember("Eval", BindingFlags.InvokeMethod, null, object_0, new object[] { str });
        }

        public static object Eval(string jsFunctionString, string jsFunctionClassName, string jsFunctionClassFuncName, object[] parameterObject)
        {
            object obj2 = null;
            Type type = null;
            smethod_0(ref obj2, ref type, jsFunctionString, jsFunctionClassName);
            return type.InvokeMember(jsFunctionClassFuncName, BindingFlags.InvokeMethod, null, obj2, parameterObject);
        }

        private void method_0()
        {
            string expression = "'2012-08-11'.substr(0,4)";
            Console.WriteLine(expression + "结果：" + Eval(expression));
            expression = "eval(1==0);";
            Console.WriteLine(expression + "结果：" + Eval(expression));
        }

        private void method_1()
        {
            string expression = "function aa(xx){ return xx+ 1;}   aa(${xx.bbb})";
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("xx.bbb", "'aaa'");
            Console.WriteLine(expression + "结果：" + Eval(expression, paramCollection, null));
        }

        private void method_2()
        {
            string expression = "function aa(xx){ return xx+ 1;}   aa(${_xx.bbb})";
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("_xx.bbb", "'aaa'");
            Console.WriteLine(expression + "结果：" + Eval(expression, paramCollection, null));
        }

        private void method_3()
        {
            string expression = "function aa(xx){ return xx+ 1;}   aa(${_xX.bBb})";
            NameValueCollection paramCollection = new NameValueCollection();
            paramCollection.Add("_xx.bbb", "'aaa'");
            Console.WriteLine(expression + "结果：" + Eval(expression, paramCollection, null));
        }

        private void method_4()
        {
            if (CodeDomProvider.IsDefinedLanguage("js"))
            {
                CodeDomProvider provider = CodeDomProvider.CreateProvider("js");
                Console.WriteLine("Language provider:  {0}", provider);
                Console.WriteLine();
                Console.WriteLine("  Default file extension:  {0}", provider.FileExtension);
                Console.WriteLine();
                CompilerParameters parameters = CodeDomProvider.GetCompilerInfo("js").CreateDefaultCompilerParameters();
                Console.WriteLine("  Compiler options:        {0}", parameters.CompilerOptions);
                Console.WriteLine("  Compiler warning level:  {0}", parameters.WarningLevel);
            }
            else
            {
                Console.WriteLine("There is no provider configured for input language \"{0}\".", "js");
            }
        }

        private static void smethod_0(ref object object_1, ref Type type_1, string string_3, string string_4)
        {
            if (object_1 == null)
            {
                object_1 = new object();
            }
            CodeDomProvider provider = new JScriptCodeProvider();
            CompilerParameters options = new CompilerParameters {
                GenerateInMemory = true
            };
            type_1 = provider.CompileAssemblyFromSource(options, new string[] { string_3 }).CompiledAssembly.GetType(string_4);
            object_1 = Activator.CreateInstance(type_1);
        }
    }
}


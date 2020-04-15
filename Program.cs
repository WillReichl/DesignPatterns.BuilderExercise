using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderExercise
{
    public class CodeBuilder
    {
        internal class Field
        {
            public string Name;
            public string Type;
        }
        
        private string ClassName;
        private List<Field> Fields;
        
        // TODO
        public CodeBuilder(string className)
        {
            this.ClassName = className;
            this.Fields = new List<Field>();
        }
        
        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            this.Fields.Add(new Field { Name = fieldName, Type = fieldType });
            return this;
        }
        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {this.ClassName}");
            sb.AppendLine("{");
            Fields.ForEach(x => 
            {
                sb.AppendLine($"  public {x.Type} {x.Name};");
            });
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
    }
}

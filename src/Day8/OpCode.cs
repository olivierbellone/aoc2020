using System.Collections.Generic;

namespace Day8
{
    public class OpCode
    {
        private static readonly IDictionary<string, OpCode> registry = new Dictionary<string, OpCode>();

        protected OpCode(string value)
        {
            Value = value;
            registry[value] = this;
        }

        public string Value { get; protected set; }

        public override string ToString() => Value;

        public static OpCode FromString(string value) => registry[value];

        public static readonly OpCode Acc = new OpCode("acc");
        public static readonly OpCode Jmp = new OpCode("jmp");
        public static readonly OpCode Nop = new OpCode("nop");
    }
}

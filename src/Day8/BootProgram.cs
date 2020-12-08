using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace Day8
{
    public class BootProgram
    {
        public BootProgram(IList<Instruction> instructions)
        {
            _instructions = instructions.Select(i => new Instruction(i.OpCode, i.Arg)).ToList();
        }

        public ImmutableList<Instruction> Instructions => _instructions.ToImmutableList();

        private readonly IList<Instruction> _instructions;

        public static BootProgram FromString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            var instructions = new List<Instruction>();

            foreach (string line in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
            {
                string[] elements = line.Split(" ");
                var opcode = OpCode.FromString(elements[0]);
                int arg = int.Parse(elements[1], CultureInfo.InvariantCulture);
                instructions.Add(new Instruction(opcode, arg));
            }

            return new BootProgram(instructions);
        }

        public void Patch(int ptrPatch, Instruction instruction)
        {
            if (ptrPatch < 0 || ptrPatch >= _instructions.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(ptrPatch));
            }

            _instructions[ptrPatch] = instruction;
        }
    }
}

using System;
using System.Collections.Generic;

namespace Day8
{
    public class Machine
    {
        public int Acc { get; private set; }

        private int _ptr;

        private readonly BootProgram _program;

        public Machine(BootProgram program) => _program = program;

        /// <summary>
        /// Runs the program, and returns <c>true</c> if the program reaches its end or
        /// <c>false</c> if the program is halted due to repeating a previously executed
        /// instruction.
        /// </summary>
        public bool Run()
        {
            var seen = new List<long>();

            while (!seen.Contains(_ptr))
            {
                if (_ptr == _program.Instructions.Count)
                {
                    return true;
                }

                seen.Add(_ptr);
                Instruction instruction = _program.Instructions[_ptr];

                if (instruction.OpCode == OpCode.Acc)
                {
                    Acc += instruction.Arg;
                    _ptr += 1;
                }
                else if (instruction.OpCode == OpCode.Jmp)
                {
                    _ptr += instruction.Arg;
                }
                else if (instruction.OpCode == OpCode.Nop)
                {
                    _ptr += 1;
                }
                else
                {
                    throw new InvalidOperationException($"Unknown opcode: {instruction.OpCode}");
                }
            }

            return false;
        }
    }
}

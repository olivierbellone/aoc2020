using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day8
{
    public static class Solver
    {
        public static long Part1(BootProgram program)
        {
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program));
            }

            var machine = new Machine(program);
            machine.Run();
            return machine.Acc;
        }

        public static long Part2(BootProgram program)
        {
            if (program == null)
            {
                throw new ArgumentNullException(nameof(program));
            }

            var machine = new Machine(program);
            int ptrPatch = -1;

            while (!machine.Run())
            {
                // Patch program
                var patchedProgram = new BootProgram(program.Instructions);
                while (true)
                {
                    ptrPatch += 1;
                    Instruction instruction = patchedProgram.Instructions[ptrPatch];

                    if (instruction.OpCode == OpCode.Jmp)
                    {
                        patchedProgram.Patch(ptrPatch, new Instruction(OpCode.Nop, instruction.Arg));
                        break;
                    }
                    else if (instruction.OpCode == OpCode.Nop)
                    {
                        patchedProgram.Patch(ptrPatch, new Instruction(OpCode.Jmp, instruction.Arg));
                        break;
                    }
                }

                // Initialize new machine with patched program
                machine = new Machine(patchedProgram);
            }

            return machine.Acc;
        }
    }
}

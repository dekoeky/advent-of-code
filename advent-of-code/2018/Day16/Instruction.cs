namespace advent_of_code._2018.Day16;

internal static class Instruction
{
    public static void Execute(Span<int> registers, OperationNames operation, int a, int b, int c)
    {
        int valueA, valueB, valueC;

        switch (operation)
        {
            // (add register) stores into register C the result of adding register A and register B.
            case OperationNames.addr:
                valueA = registers[a];
                valueB = registers[b];
                valueC = valueA + valueB;
                registers[c] = valueC;
                break;

            // (add immediate) stores into register C the result of adding register A and value B.
            case OperationNames.addi:
                valueA = registers[a];
                valueB = b;
                valueC = valueA + valueB;
                registers[c] = valueC;
                break;

            // (multiply register) stores into register C the result of multiplying register A and register B.
            case OperationNames.mulr:
                valueA = registers[a];
                valueB = registers[b];
                valueC = valueA * valueB;
                registers[c] = valueC;
                break;

            // (multiply immediate) stores into register C the result of multiplying register A and value B.
            case OperationNames.muli:
                valueA = registers[a];
                valueB = b;
                valueC = valueA * valueB;
                registers[c] = valueC;
                break;

            // (bitwise AND register) stores into register C the result of the bitwise AND of register A and register B.
            case OperationNames.banr:
                valueA = registers[a];
                valueB = registers[b];
                valueC = valueA & valueB;
                registers[c] = valueC;
                break;

            // (bitwise AND immediate) stores into register C the result of the bitwise AND of register A and value B.
            case OperationNames.bani:
                valueA = registers[a];
                valueB = b;
                valueC = valueA & valueB;
                registers[c] = valueC;
                break;

            // (bitwise OR register) stores into register C the result of the bitwise OR of register A and register B.
            case OperationNames.borr:
                valueA = registers[a];
                valueB = registers[b];
                valueC = valueA | valueB;
                registers[c] = valueC;
                break;

            // (bitwise OR immediate) stores into register C the result of the bitwise OR of register A and value B.
            case OperationNames.bori:
                valueA = registers[a];
                valueB = b;
                valueC = valueA | valueB;
                registers[c] = valueC;
                break;

            // (set register) copies the contents of register A into register C. (Input B is ignored.)
            case OperationNames.setr:
                registers[c] = registers[a];
                break;

            // (set immediate) stores value A into register C. (Input B is ignored.)
            case OperationNames.seti:
                registers[c] = a;
                break;

            // (greater-than immediate/register) sets register C to 1 if value A is greater than register B.
            // Otherwise, register C is set to 0.
            case OperationNames.gtir:
                valueA = a;
                valueB = registers[b];
                registers[c] = valueA > valueB
                    ? 1
                    : 0;
                break;

            // (greater-than register/immediate) sets register C to 1 if register A is greater than value B. Otherwise, register C is set to 0.
            case OperationNames.gtri:
                valueA = registers[a];
                valueB = b;
                registers[c] = valueA > valueB
                    ? 1
                    : 0;
                break;

            // (greater-than register/register) sets register C to 1 if register A is greater than register B. Otherwise, register C is set to 0.
            case OperationNames.gtrr:
                valueA = registers[a];
                valueB = registers[b];
                registers[c] = valueA > valueB
                    ? 1
                    : 0;
                break;

            // (equal immediate/register) sets register C to 1 if value A is equal to register B. Otherwise, register C is set to 0.
            case OperationNames.eqir:
                valueA = a;
                valueB = registers[b];
                registers[c] = valueA == valueB
                    ? 1
                    : 0;
                break;

            // (equal register/immediate) sets register C to 1 if register A is equal to value B. Otherwise, register C is set to 0.
            case OperationNames.eqri:
                valueA = registers[a];
                valueB = b;
                registers[c] = valueA == valueB
                    ? 1
                    : 0;
                break;

            // (equal register/register) sets register C to 1 if register A is equal to register B. Otherwise, register C is set to 0.
            case OperationNames.eqrr:
                valueA = registers[a];
                valueB = registers[b];
                registers[c] = valueA == valueB
                    ? 1
                    : 0;
                break;

            default:
                throw new InvalidOperationException();
        }
    }
}

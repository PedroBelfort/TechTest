using FluentAssertions;

namespace WordPuzzle.UnitTests
{
    public class WordPuzzleSolverTests
    {
        [Theory]
        [InlineData("SAME", "COST",0, "CAME")]
        [InlineData("CAME", "COST", 2, "CASE")]
        [InlineData("CASE", "COST", 3, "CAST")]
        [InlineData("CAST", "COST", 2, "CAST")]
        public void ReplaceCharBySameIndex_Should_Replace(string start, string end, int index, string expected)
        {
            var reference = string.Empty;

            WordPuzzleSolver solver = new WordPuzzleSolver();
            reference = solver.ReplaceCharBySameIndex(start, end, index);

            reference.Should().Be(expected);
        }


       

    }
}


// Substituir a primeira letra da start pela primeira letra da end.  SAME COST = CAME
// Verifica se tem na lista. (SIM)
// Se Sim adiciona a palavra na lsita de retorno e utilizamos essa palavra como referencia (CAME)
// Subistitua a segunda letra da palavra de referencia pela segunda letra da end = CAME COST = COME
// Verifica na lista (NAO)
// subistitu a terceira letra da referencia pela terceira letra do end = CAME COST = CASE
// Verifica na lista (SIM)
// Adiciona a palavra na lista e utilizama essa palavra como referencia (CASE)
// Subsititua a quarta quarta letra da referencia pela quarta letra da end. CASE COST = CAST
// Verifica se tem na lista (SIM)
//  Adiciona a palavra na lista e utilizama essa palavra como referencia (CAST)

//Volta pro inicio da palavra
//Verifica se as primeiras letras são iguais (SIM)
// Substitui a segunda letra da referencia com a segunda da end. CAST COST = COST
// As palavras são iguais (SIM)
// FIM
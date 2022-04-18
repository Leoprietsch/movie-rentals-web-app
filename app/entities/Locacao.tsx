import Cliente from "./Cliente";
import Filme from "./Filmes";

interface Locacao {
  id: number;
  cliente: Cliente;
  filme: Filme;
  dataLocacao: Date;
  dataDevolucao?: Date;
}

export default Locacao;

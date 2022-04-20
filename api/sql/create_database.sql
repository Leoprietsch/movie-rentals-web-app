CREATE DATABASE IF NOT EXISTS movie_rentals;
CREATE TABLE IF NOT EXISTS movie_rentals.cliente(
  id INT AUTO_INCREMENT PRIMARY KEY,
  nome VARCHAR(200),
  CPF VARCHAR(11),
  dataNascimento DATE
);
ALTER TABLE
  movie_rentals.cliente
ADD
  INDEX idx_CPF (CPF);
ALTER TABLE
  movie_rentals.cliente
ADD
  INDEX idx_NOME (NOME);
CREATE TABLE IF NOT EXISTS movie_rentals.filme(
    id INT PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    ClassificacaoIndicativa VARCHAR(11) NOT NULL,
    Lancamento TINYINT
  );
ALTER TABLE
  movie_rentals.filme
ADD
  INDEX idx_Lancamento (lancamento);
ALTER TABLE
  movie_rentals.filme
ADD
  INDEX idx_Titulo (titulo);
CREATE TABLE IF NOT EXISTS movie_rentals.locacao(
    id INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT,
    id_filme INT,
    dataLocacao DATETIME,
    dataDevolucao DATETIME,
    CONSTRAINT FK_Cliente FOREIGN KEY (id_cliente) REFERENCES cliente(id),
    CONSTRAINT FK_Filme FOREIGN KEY (id_filme) REFERENCES filme(id)
  );
ALTER TABLE
  movie_rentals.locacao
ADD
  INDEX FK_Cliente_idx (id_cliente);
ALTER TABLE
  movie_rentals.locacao
ADD
  INDEX FK_Filme_idx (id_filme);
import { Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import React, { useEffect, useState } from "react";

interface Filme {
  id: Number;
  titulo: String;
  classificacaoIndicativa: Number;
  lancamento: Boolean;
}

function Filmes() {
  const [filmes, setFilmes] = useState<Filme[]>([]);

  useEffect(() => {
    setFilmes([
      {
        id: 1,
        titulo: "Spider-man",
        classificacaoIndicativa: 10,
        lancamento: true,
      },
      {
        id: 2,
        titulo: "Spider-man 2",
        classificacaoIndicativa: 12,
        lancamento: false,
      },
      {
        id: 3,
        titulo: "Spider-man 3",
        classificacaoIndicativa: 14,
        lancamento: true,
      },
      {
        id: 4,
        titulo: "Spider-man 4",
        classificacaoIndicativa: 16,
        lancamento: false,
      },
      {
        id: 5,
        titulo: "Spider-man 5",
        classificacaoIndicativa: 18,
        lancamento: true,
      },
    ]);
  }, [filmes]);

  const columns: ColumnsType<Filme> = [
    {
      title: "Título",
      dataIndex: "titulo",
      key: "titulo",
    },
    {
      title: "Classificação Indicativa",
      dataIndex: "classificacaoIndicativa",
      key: "classificacaoIndicativa",
    },
    {
      title: "Lançamento",
      dataIndex: "lancamento",
      key: "lancamento",
      render: (texto, filme) => {
        if (filme.lancamento) return "Sim";
        else return "Não";
      },
    },
  ];

  return (
    <>
      <Title>Filmes</Title>
      <Table columns={columns} dataSource={filmes} />
    </>
  );
}

export default Filmes;

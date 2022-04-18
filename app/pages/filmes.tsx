import { Button, Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import { VideoCameraAddOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import Filme from "../entities/Filmes";
import { getAll } from "../apiClients/filmesClient";

function Filmes() {
  const [filmes, setFilmes] = useState<Filme[]>([]);

  useEffect(() => {
    getAll()
      .then((response: any) => {
        setFilmes(response.data);
        console.log(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

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
      render: (lancamento: boolean) => {
        if (lancamento) return "Sim";
        else return "Não";
      },
    },
  ];

  return (
    <>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
        }}
      >
        <Title>Filmes</Title>
        <Button type="primary" size="large" icon={<VideoCameraAddOutlined />}>
          Importar filmes
        </Button>
      </div>
      <Table columns={columns} dataSource={filmes} />
    </>
  );
}

export default Filmes;

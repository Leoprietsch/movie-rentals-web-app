import { Button, Space, Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import { UserAddOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import Locacao from "../../entities/Locacao";
import { useRouter } from "next/router";
import { devolve, exclude, getAll } from "../../apiClients/locacoesClient";
import Cliente from "../../entities/Cliente";
import Filme from "../../entities/Filmes";

function Locacoes() {
  const [locacoes, setLocacoes] = useState<Locacao[]>([]);
  const router = useRouter();

  useEffect(() => {
    getAll()
      .then((response: any) => {
        setLocacoes(response.data);
      })
      .catch((e: Error) => {
        console.log(e);
      });
  }, []);

  const handleExclusion = (id: number) => {
    exclude(id).then(() => {
      let locacoesList = locacoes.filter((locacao) => locacao.id !== id);
      setLocacoes(locacoesList);
    });
  };

  const handleDevolution = (id: number) => {
    devolve(id).then(() => {
      getAll()
        .then((response: any) => {
          setLocacoes(response.data);
        })
        .catch((e: Error) => {
          console.log(e);
        });
    });
  };

  const colunas: ColumnsType<Locacao> = [
    {
      title: "Cliente",
      dataIndex: "cliente",
      key: "cliente",
      render: (cliente: Cliente) => cliente.nome,
    },
    {
      title: "Filme",
      dataIndex: "filme",
      key: "filme",
      render: (filme: Filme) => filme.titulo,
    },
    {
      title: "Data de Locação",
      dataIndex: "dataLocacao",
      key: "dataLocacao",
      render: (value, locacao: Locacao) => {
        return new Date(locacao?.dataLocacao).toLocaleString("pt-br", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
          hour: "2-digit",
          minute: "2-digit",
        });
      },
    },
    {
      title: "Data de Devolução",
      dataIndex: "dataDevolucao",
      key: "dataDevolucao",
      render: (value, locacao: Locacao) => {
        return !locacao?.dataDevolucao
          ? null
          : new Date(locacao?.dataDevolucao).toLocaleString("pt-br", {
              day: "2-digit",
              month: "2-digit",
              year: "numeric",
              hour: "2-digit",
              minute: "2-digit",
            });
      },
    },
    {
      title: "Ações",
      dataIndex: "id",
      key: "acoes",
      render: (id) => {
        return (
          <Space size="middle">
            <Button onClick={() => handleDevolution(id)}>Devolver</Button>
            <Button onClick={() => router.push(`/locacoes/editar/${id}`)}>
              Editar
            </Button>
            <Button danger onClick={() => handleExclusion(id)}>
              Excluir
            </Button>
          </Space>
        );
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
        <Title>Locações</Title>
        <Button
          type="primary"
          size="large"
          icon={<UserAddOutlined />}
          onClick={() => router.push("/locacoes/cadastrar")}
        >
          Cadastrar locação
        </Button>
      </div>

      <Table columns={colunas} dataSource={locacoes} />
    </>
  );
}

export default Locacoes;

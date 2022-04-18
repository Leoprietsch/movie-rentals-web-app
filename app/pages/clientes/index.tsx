import { Button, Space, Table } from "antd";
import { ColumnsType } from "antd/lib/table";
import Title from "antd/lib/typography/Title";
import { UserAddOutlined } from "@ant-design/icons";
import React, { useEffect, useState } from "react";
import Cliente from "../../entities/Cliente";
import { useRouter } from "next/router";

function Clientes() {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  const router = useRouter();

  useEffect(() => {
    setClientes([
      {
        id: 1,
        nome: "Leonardo Oliveira",
        cpf: "85953547072",
        dataNascimento: new Date(),
      },
    ]);
  }, []);

  const colunas: ColumnsType<Cliente> = [
    {
      title: "Nome",
      dataIndex: "nome",
      key: "nome",
    },
    {
      title: "CPF",
      dataIndex: "cpf",
      key: "cpf",
    },
    {
      title: "Data de Nascimento",
      dataIndex: "dataNascimento",
      key: "dataNascimento",
      render: (value, cliente: Cliente) => {
        return cliente?.dataNascimento?.toLocaleString("pt-br", {
          day: "2-digit",
          month: "2-digit",
          year: "numeric",
        });
      },
    },
    {
      title: "Ações",
      dataIndex: "acoes",
      key: "acoes",
      render: (value, cliente: Cliente) => {
        return (
          <Space size="middle">
            <a href={`/clientes/editar/${cliente.id}`}>Editar</a>
            <a>Excluir</a>
          </Space>
        );
      },
    },
  ];

  return (
    <>
      <Title>Clientes</Title>
      <Button
        style={{ margin: "20px" }}
        type="primary"
        size="large"
        icon={<UserAddOutlined />}
        onClick={() => router.push("/clientes/cadastrar")}
      >
        Cadastrar cliente
      </Button>
      <Table columns={colunas} dataSource={clientes} />
    </>
  );
}

export default Clientes;
